using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_App.Custom_Controls;
using SIGEEA_App.User_Controls;
using SIGEEA_App.User_Controls.Clientes;
using System.Collections.ObjectModel;
using SIGEEA_BL.Seguridad;
using MahApps.Metro.Controls;
namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwAbonoFactura.xaml
    /// </summary>
    public partial class wnwAbonoFactura : MetroWindow
    {
        public wnwAbonoFactura(int pkFactura)
        {
            InitializeComponent();

            lista = facMant.ObtenerFactura(pkFactura);
            ListaMetodos();

        }
        string metodoPago, moneda;
        int idCliente;
        List<String> ListarMetodosDePago = new List<String>();
        SIGEEA_spListarFacturaPendientePorFacturaResult lista = new SIGEEA_spListarFacturaPendientePorFacturaResult();
        MonedaMantenimiento mon = new MonedaMantenimiento();
        ClienteMantenimiento cliMant = new ClienteMantenimiento();
        FacturaClienteMantenimiento facMant = new FacturaClienteMantenimiento();
        double Total;
        string saldo = "";
        public string SepararMiles(double Cantidad)
        {
            return Cantidad.ToString("N2");
        }
        public void ListaMetodos()
        {
            ListarMetodosDePago.Add("1.Efectivo");
            ListarMetodosDePago.Add("2.Tarjeta");
            ListarMetodosDePago.Add("3.Cheque");
            ListarMetodosDePago.Add("4.Deposito");
            txtNumero0.Visibility = Visibility.Hidden;
            txtNumero.Visibility = Visibility.Hidden;
            cmbMetodoPago.ItemsSource = ListarMetodosDePago;
            cmbMoneda.ItemsSource = mon.ListarMonedas();
            for(int i = 0; i< lista.Saldo.Length; i++)
            {
                if (lista.Saldo[i] == '.') saldo += '.'; else saldo += lista.Saldo[i];
            }
            txtMontoaCancelar.Text = saldo[0] + SepararMiles(Convert.ToDouble(saldo.Remove(0,1)));
            idCliente = lista.PK_Id_Cliente;
            SIGEEA_spObtenerCategoriaClienteResult categoria = cliMant.ObtenerCategoriaCliente(idCliente);
            lista.FecProPago_CreCliente = lista.FecProPago_CreCliente.AddDays(Convert.ToDouble(categoria.RanPagos_CatCliente));
            txtFechaProximoPago.Text = lista.FecProPago_CreCliente.ToShortDateString();
            txtFechaLimitePago.Text = lista.FecLimPago_CreCliente.ToShortDateString();
        }
        private void cmbMetodoPago_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            metodoPago = this.cmbMetodoPago.SelectedItem.ToString();
            if (metodoPago[0].ToString() == "1")
            {
                txtNumero0.Visibility = Visibility.Hidden;
                txtNumero.Visibility = Visibility.Hidden;
            }
            else if (metodoPago[0].ToString() == "2")
            {
                txtNumero0.Visibility = Visibility.Hidden;
                txtNumero.Visibility = Visibility.Hidden;
            }
            else if (metodoPago[0].ToString() == "3")
            {
                txtNumero0.Visibility = Visibility.Visible;
                txtNumero.Visibility = Visibility.Visible;
                txtNumero0.Text = "Numero de Cheque:";
            }
            else if (metodoPago[0].ToString() == "4")
            {
                txtNumero0.Visibility = Visibility.Visible;
                txtNumero.Visibility = Visibility.Visible;
                txtNumero0.Text = "Numero de Cuenta:";
            }
        }

        private void cmbMoneda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            moneda = this.cmbMoneda.SelectedItem.ToString();
            CalculaNuevoSaldo();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            if(cmbMetodoPago.SelectedValue != null)
            {
                wnwCancelarFacturaCliente nueva = new wnwCancelarFacturaCliente(pkIdEmpleado: UsuarioGlobal.InfoUsuario.PK_Id_Empleado, pkIdCliente: lista.PK_Id_FacCliente, Tipo: "Abono", pkIdEmpresa: 1, ptipoPedido: null, nueva: null, pMontoTotal: Total.ToString(), pDescuentoTotal: null, pMontoNetoTotal: saldo, pMonedaTotal: moneda, pObservaciones: null, pMontoAbono: txtMontoAbono.Text, pfechaProPago: lista.FecProPago_CreCliente, pfechaLimPago: lista.FecLimPago_CreCliente, pmetodoPago: metodoPago, pnumero: txtNumero.Text);
                nueva.ShowDialog();
                this.Close();
            }else
            {
                MessageBox.Show("Debe seleccionar un metodo de pago");
            }
            
        }

        private void txtMontoAbono_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculaNuevoSaldo();
        }

        public void CalculaNuevoSaldo()
        {
            if (txtMontoAbono.Text != "")
            {
                if (lista.Saldo[0].ToString() == "$")
                {
                    if (moneda == "Colón")
                    {
                        Total = Convert.ToDouble(saldo.Remove(0, 1).ToString()) - (Convert.ToDouble(txtMontoAbono.Text) / mon.PrecioVenta(moneda));
                    }
                    else Total = Convert.ToDouble(saldo.Remove(0, 1).ToString()) - Convert.ToDouble(txtMontoAbono.Text);
                    txtNuevoSaldo.Text = string.Concat("$", Math.Round(Convert.ToDouble(SepararMiles(Total)), 2));
                }
                else {
                    if (moneda == "Colón")
                    {
                        Total = Convert.ToDouble(saldo.Remove(0, 1).ToString()) - Convert.ToDouble(txtMontoAbono.Text);
                    }
                    else if (moneda == "Dolar")
                    {
                        Total = Convert.ToDouble(saldo.Remove(0, 1).ToString()) - (Convert.ToDouble(txtMontoAbono.Text) * mon.PrecioVenta(moneda));
                    }
                    txtNuevoSaldo.Text = string.Concat("¢", Math.Round(Convert.ToDouble(SepararMiles(Total)),2));
                }
            }

        }
    }
}
