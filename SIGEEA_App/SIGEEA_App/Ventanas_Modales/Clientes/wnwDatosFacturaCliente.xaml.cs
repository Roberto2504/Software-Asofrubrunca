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
            montoTotal = pMontoTotal;
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
        string tipoFactura, tipoPedido, montoTotal, descuentoTotal, montoNetoTotal, moneda, fechaProPago, fechaLimite, metodoPago, MontoAbono;
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
                    wnwFacturaCliente nueva = new wnwFacturaCliente(pidFactura:ProcesarFactura(txtObservaciones.Text, DateTime.Now, DateTime.Now, txtNumero.Text, montoNetoTotal, IdCliente), pTipo:"Venta");
                    nueva.ShowDialog();
                    this.Close();
                }
            }
            else if (tipoFactura == "Crédito")
            {
                if (txtObservaciones.Text != "")
                {
                    
                    wnwFacturaCliente nueva = new wnwFacturaCliente(pidFactura: ProcesarFactura(txtObservaciones.Text, proximoPago, proximoLimite, txtNumero.Text, MontoAbono, IdCliente), pTipo: "Venta");
                    nueva.ShowDialog();
                    this.Close();
                }
            }
            else if (tipoFactura == "Proforma")
            {
                if (txtObservaciones.Text != "")
                {
                    wnwFacturaCliente nueva = new wnwFacturaCliente(pidFactura: ProcesarFactura(txtObservaciones.Text, DateTime.Now, DateTime.Now, txtNumero.Text, 0.ToString(), IdCliente), pTipo: "Venta");
                    nueva.ShowDialog();
                    this.Close();
                }
            }


        }
        MonedaMantenimiento monMant = new MonedaMantenimiento();
        UnidadMedidaMantenimiento uniMedMant = new UnidadMedidaMantenimiento();
        FacturaClienteMantenimiento facMant = new FacturaClienteMantenimiento();
        SIGEEA_spListarFacturaPendientePorFacturaResult lista = new SIGEEA_spListarFacturaPendientePorFacturaResult();
        double fin;
        private int  ProcesarFactura (string observaciones, DateTime fechaProPago, DateTime fechaLimite, string numero, string MontoAbono, int pkIdCliente)
        {
            int idFactura = 0;
            lista = facMant.ObtenerFactura(pkIdCliente);
            if (tipoFactura != "Abono")
            {
                if (tipoFactura != "Proforma")
                {
                    if (MontoAbono == null) MontoAbono = "0";
                    fin = Convert.ToDouble(montoNetoTotal.Remove(0, 1));
                }
            }
            else
            {
                fin = Convert.ToDouble(montoTotal);
            }
            if (tipoFactura != "Abono")
            {
                ObservableCollection<SIGEEA_DetFacCliente> plistaDetProducto = new ObservableCollection<SIGEEA_DetFacCliente>();
                SIGEEA_FacCliente nuevaFactura = new SIGEEA_FacCliente();
                nuevaFactura.FecEntrega_FacCliente = DateTime.Now;
                nuevaFactura.FecPago_FacCliente = DateTime.Now;
                nuevaFactura.Observaciones_FacCliente = observaciones;
                nuevaFactura.FK_Id_Cliente = IdCliente;
                nuevaFactura.MonTotal_FacCliente = Convert.ToDouble(montoTotal.Remove(0, 1));
                nuevaFactura.MonNeto_FacCliente = Convert.ToDouble(montoNetoTotal.Remove(0, 1));
                nuevaFactura.Descuento_FacCliente = Convert.ToDouble(descuentoTotal);
                nuevaFactura.FK_Id_Moneda = monMant.PkMonedas(moneda)[0];
                nuevaFactura.FK_Id_Empresa = IdEmpresa;
                nuevaFactura.FK_Id_Empleado = IdEmpleado;
                foreach (uc_DetProducto detFacCliente in listaDetProducto)
                {
                    SIGEEA_DetFacCliente nuevoDetalle = new SIGEEA_DetFacCliente();
                    nuevoDetalle.MonTotal_DetFacCliente = Convert.ToDouble(detFacCliente.preBruProducto);
                    nuevoDetalle.MonNeto_DetFacCliente = Convert.ToDouble(detFacCliente.preNetProducto);
                    nuevoDetalle.CanProducto_DetFacCliente = Convert.ToDouble(detFacCliente.canInvProducto);
                    nuevoDetalle.Descuento_DetFacCliente = Convert.ToDouble(detFacCliente.desProducto);
                    if (tipoPedido == "NACIONAL")
                    {
                        nuevoDetalle.PreUnidad_DetFacCliente = Convert.ToDouble(detFacCliente.preNacProducto);
                        nuevoDetalle.Moneda_DetFacCliente = "¢";
                    }
                    else
                    {
                        nuevoDetalle.PreUnidad_DetFacCliente = Convert.ToDouble(detFacCliente.preExtProducto);
                        nuevoDetalle.Moneda_DetFacCliente = "$";
                    }
                    nuevoDetalle.FK_Id_UniMedida = uniMedMant.PkUniMedida(detFacCliente.UniMedida)[0];
                    nuevoDetalle.FK_Id_TipProducto = Convert.ToInt32(detFacCliente.IdTipProducto);
                    plistaDetProducto.Add(nuevoDetalle);
                }
                if (tipoFactura == "Proforma")
                {
                    nuevaFactura.Estado_FacCliente = "PR";
                    idFactura =  facMant.RegistrarFactura(nuevaFactura, plistaDetProducto, null, null);
                }
                else if (tipoFactura == "Crédito")
                {
                    nuevaFactura.Estado_FacCliente = "CR";
                    SIGEEA_CreCliente nuevoCredito = new SIGEEA_CreCliente();
                    nuevoCredito.Estado_CreCliente = true;
                    nuevoCredito.Fecha_CreCliente = DateTime.Now;
                    nuevoCredito.Monto_CreCliente = Convert.ToDouble(montoNetoTotal.Remove(0, 1));
                    nuevoCredito.Saldo_CreCliente = Convert.ToDouble(montoNetoTotal.Remove(0, 1));
                    nuevoCredito.FecProPago_CreCliente = fechaProPago;
                    nuevoCredito.FecLimPago_CreCliente = fechaLimite;
                    nuevoCredito.FK_Id_Cliente = IdCliente;
                    nuevoCredito.FK_Id_Moneda = monMant.PkMonedas(moneda)[0];
                    idFactura = facMant.RegistrarFactura(nuevaFactura, plistaDetProducto, pAboCliente: null, pCreCliente: nuevoCredito);
                }
                else if (tipoFactura == "Contado")
                {
                    SIGEEA_AboCliente nuevoAbono = new SIGEEA_AboCliente();
                    nuevoAbono.Monto_AboCliente = Convert.ToDouble(montoNetoTotal.Remove(0, 1));
                    nuevaFactura.Estado_FacCliente = "CO";
                    nuevoAbono.Metodo_AboCliente = Convert.ToInt32(metodoPago[0].ToString());
                    nuevoAbono.Numero_AboCliente = numero;
                    nuevoAbono.Fecha_AboCliente = DateTime.Now;
                    nuevoAbono.FK_Id_Moneda = monMant.PkMonedas(moneda)[0];
                    nuevoAbono.FK_Id_Empleado = IdEmpleado;
                    nuevoAbono.Estado_AboCliente = true;
                    nuevoAbono.FK_Id_Cliente = IdCliente;
                    idFactura = facMant.RegistrarFactura(nuevaFactura, plistaDetProducto, nuevoAbono, null);
                }
            }
            else
            {
                SIGEEA_CreCliente nuevoCredito = new SIGEEA_CreCliente();
                if (fin == 0)
                {
                    nuevoCredito.Estado_CreCliente = false;
                }
                else
                {
                    nuevoCredito.Estado_CreCliente = true;
                }
                nuevoCredito.PK_Id_CreCliente = lista.PK_Id_CreCliente;
                nuevoCredito.Saldo_CreCliente = fin;
                nuevoCredito.FecProPago_CreCliente = fechaProPago;
                SIGEEA_AboCliente nuevoAbono = new SIGEEA_AboCliente();
                nuevoAbono.Monto_AboCliente = Convert.ToDouble(MontoAbono);
                nuevoAbono.Metodo_AboCliente = Convert.ToInt32(metodoPago[0].ToString());
                nuevoAbono.Numero_AboCliente = numero;
                nuevoAbono.Fecha_AboCliente = DateTime.Now;
                nuevoAbono.FK_Id_Moneda = monMant.PkMonedas(moneda)[0];
                nuevoAbono.FK_Id_Empleado = IdEmpleado;
                nuevoAbono.Estado_AboCliente = true;
                nuevoAbono.FK_Id_Cliente = lista.PK_Id_Cliente;
                nuevoAbono.FK_Id_FacCliente = lista.PK_Id_FacCliente;
                facMant.RegitrarAbono(nuevoAbono, nuevoCredito);
            }
            return idFactura;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
