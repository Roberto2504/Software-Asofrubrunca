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
using System.Collections.ObjectModel;
using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_App.User_Controls.Clientes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwDatosFacturaCliente.xaml
    /// </summary>
    public partial class wnwDatosFacturaCliente : MetroWindow
    {
        public wnwDatosFacturaCliente(int pkIdEmpleado, int pkIdCliente, string Tipo, int pkIdEmpresa, string ptipoPedido, ObservableCollection<uc_DetProducto> nueva, string pMontoTotal, string pDescuentoTotal, string pMontoNetoTotal, string pMonedaTotal)
        {
            InitializeComponent();
            foreach (uc_DetProducto detProducto in nueva)

            {
                listaDetProducto.Add(detProducto);

            }
            IdEmpleado = pkIdEmpleado;
            IdCliente = pkIdCliente;
            tipoFactura = Tipo;
            IdEmpresa = pkIdEmpresa;
            tipoPedido = ptipoPedido;
            montoTatal = pMontoTotal;
            descuentoTotal = pDescuentoTotal;
            montoNetoTotal = pMontoNetoTotal;
            moneda = pMonedaTotal;
            txtbTipoFactura.Text = Tipo;
            ClienteMantenimiento cliMant = new ClienteMantenimiento();
            if (tipoFactura == "Contado")
            {
                grdPago.Visibility = Visibility.Visible;

            }
            else if (tipoFactura == "Crédito")
            {

                DateTime hoy = DateTime.Now;
                DateTime hoy1 = DateTime.Now;
                SIGEEA_spObtenerCategoriaClienteResult categoria = cliMant.ObtenerCategoriaCliente(IdCliente);
                proximoPago = hoy.AddDays(Convert.ToDouble(categoria.RanPagos_CatCliente));
                proximoLimite = hoy1.AddDays(Convert.ToDouble(categoria.TieMaximo_CatCliente));
                fechaProPago = proximoPago.ToShortDateString();
                fechaLimite = proximoLimite.ToShortDateString();
                txtFechaLimitePago.Text = fechaLimite;
                txtFechaProximoPago.Text = fechaProPago;
                txtMontoaCancelar.Text = pMontoNetoTotal;
                grdAbono.Visibility = Visibility.Visible;
               
            }
            else if (tipoFactura == "Proforma")
            {
                grdPago.Visibility = Visibility.Visible;
            }
            ListaMetodos();
        }
        int IdEmpleado, IdCliente, IdEmpresa;
        string tipoFactura, tipoPedido, montoTatal, descuentoTotal, montoNetoTotal, moneda, observaciones, MontoAbono, fechaProPago, fechaLimite, metodoPago, numero, montoAbono;
        DateTime proximoPago;
        DateTime proximoLimite;
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

        ObservableCollection<uc_DetProducto> listaDetProducto = new ObservableCollection<uc_DetProducto>();
        List<String> ListarMetodosDePago = new List<String>();
        public void ListaMetodos()
        {
            ListarMetodosDePago.Add("1.Efectivo");
            ListarMetodosDePago.Add("2.Tarjeta");
            ListarMetodosDePago.Add("3.Cheque");
            ListarMetodosDePago.Add("4.Deposito");
            txtNumero0.Visibility = Visibility.Hidden;
            txtNumero.Visibility = Visibility.Hidden;
            cmbMetodoPago.ItemsSource = ListarMetodosDePago;
        }
        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            if (tipoFactura == "Contado")
            {
                if (txtObservaciones.Text != "")
                {
                    wnwCancelarFacturaCliente nueva = new wnwCancelarFacturaCliente(pkIdEmpleado: IdEmpleado, pkIdCliente: IdCliente, Tipo: tipoFactura, pkIdEmpresa: 1, ptipoPedido: tipoPedido, nueva: listaDetProducto, pMontoTotal: montoTatal, pDescuentoTotal: descuentoTotal, pMontoNetoTotal: montoNetoTotal, pMonedaTotal: moneda, pObservaciones: txtObservaciones.Text, pMontoAbono: montoNetoTotal, pfechaProPago: DateTime.Now, pfechaLimPago: DateTime.Now, pmetodoPago: metodoPago, pnumero: txtNumero.Text);
                    nueva.ShowDialog();
                    this.Close();
                }
            }
            else if (tipoFactura == "Crédito")
            {
                if (txtObservaciones.Text != "")
                {
                    
                    wnwCancelarFacturaCliente nueva = new wnwCancelarFacturaCliente(pkIdEmpleado: IdEmpleado, pkIdCliente: IdCliente, Tipo: tipoFactura, pkIdEmpresa: 1, ptipoPedido: tipoPedido, nueva: listaDetProducto, pMontoTotal: montoTatal, pDescuentoTotal: descuentoTotal, pMontoNetoTotal: montoNetoTotal, pMonedaTotal: moneda, pObservaciones: txtObservaciones.Text, pMontoAbono: MontoAbono, pfechaProPago: proximoPago, pfechaLimPago: proximoLimite, pmetodoPago: metodoPago, pnumero: txtNumero.Text);
                    nueva.ShowDialog();
                    this.Close();
                }
            }
            else if (tipoFactura == "Proforma")
            {
                if (txtObservaciones.Text != "")
                {
                    wnwCancelarFacturaCliente nueva = new wnwCancelarFacturaCliente(pkIdEmpleado: IdEmpleado, pkIdCliente: IdCliente, Tipo: tipoFactura, pkIdEmpresa: 1, ptipoPedido: tipoPedido, nueva: listaDetProducto, pMontoTotal: montoTatal, pDescuentoTotal: descuentoTotal, pMontoNetoTotal: montoNetoTotal, pMonedaTotal: moneda, pObservaciones: txtObservaciones.Text, pMontoAbono: 0.ToString(), pfechaProPago: DateTime.Now, pfechaLimPago: DateTime.Now, pmetodoPago: metodoPago, pnumero: txtNumero.Text);
                    nueva.ShowDialog();
                    this.Close();
                }
            }


        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
