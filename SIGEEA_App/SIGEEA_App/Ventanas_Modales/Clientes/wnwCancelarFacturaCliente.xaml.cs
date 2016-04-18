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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SIGEEA_App.User_Controls.Clientes;
using SIGEEA_BL;
using SIGEEA_BO;
using System.Collections.ObjectModel;

namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwCancelarFacturaCliente.xaml
    /// </summary>
    public partial class wnwCancelarFacturaCliente : MetroWindow
    {
        public wnwCancelarFacturaCliente(int pkIdEmpleado, int pkIdCliente, string Tipo, int pkIdEmpresa, string ptipoPedido, ObservableCollection<uc_DetProducto> nueva, string pMontoTotal, string pDescuentoTotal, string pMontoNetoTotal, string pMonedaTotal, string pObservaciones, string pMontoAbono, string pfechaProPago, string pmetodoPago, string pnumero)
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
            observaciones = pObservaciones;
            MontoAbono = pMontoAbono;
            fechaProPago = pfechaProPago;
            metodoPago = pmetodoPago;
            numero = pnumero;
            CargaInfoFactura();
           



        }
        int IdEmpleado, IdCliente, IdEmpresa;
        string tipoFactura, tipoPedido, montoTotal, descuentoTotal, montoNetoTotal, moneda, observaciones, MontoAbono, fechaProPago, metodoPago, numero;
        ObservableCollection<uc_DetProducto> listaDetProducto = new ObservableCollection<uc_DetProducto>();


        string Nombre, Cedula, Direccion, Telefono, Correo, Fecha, Hora;

       
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        public void InfoPago(string pObservaciones)
        {
            observaciones = pObservaciones;
        }
        public void InfoEmpresa()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

             Nombre = dc.SIGEEA_Empresas.First(c => c.PK_Id_Empresa == IdEmpresa).Nombre_Empresa;
            txbFactura.AppendText(Nombre);
            txbFactura.AppendText(Environment.NewLine);

             Cedula = "Ced. Juridica N°:" + dc.SIGEEA_Empresas.First(c => c.PK_Id_Empresa == IdEmpresa).CedJuridica_Empresa;
            txbFactura.AppendText(Cedula + "");
            txbFactura.AppendText(Environment.NewLine);

             Direccion = dc.SIGEEA_Empresas.First(c => c.PK_Id_Empresa == IdEmpresa).Direccion_Empresa;
            txbFactura.AppendText(Direccion + "");
            txbFactura.AppendText(Environment.NewLine);

             Telefono = dc.SIGEEA_Empresas.First(c => c.PK_Id_Empresa == IdEmpresa).Telefono_Empresa;
            txbFactura.AppendText("Teléfono: " + Telefono + "");
            txbFactura.AppendText(Environment.NewLine);

             Correo = dc.SIGEEA_Empresas.First(c => c.PK_Id_Empresa == IdEmpresa).Correo_Empresa;
            txbFactura.AppendText("Correo: " + Correo + "");
            txbFactura.AppendText(Environment.NewLine);

             Fecha =  DateTime.Now.ToShortDateString();
            txbFactura.AppendText("Fecha: "+Fecha + "");
            txbFactura.AppendText(Environment.NewLine);

             Hora = DateTime.Now.ToShortTimeString();
            txbFactura.AppendText("Hora: " + Hora + "");
            txbFactura.AppendText(Environment.NewLine);


        }
        public void CargarDetProducto()
        {
            if(tipoPedido== "NACIONAL")
            {
                foreach (uc_DetProducto detProducto in listaDetProducto)

                {
                    string linea = (detProducto.nomTipProducto + "    ¢" + detProducto.preNacProducto+ "        " + detProducto.canInvProducto + "         " + detProducto.Moneda + " " + detProducto.preBruProducto + "            " + detProducto.desProducto + "         " + detProducto.Moneda + " " + detProducto.preNetProducto);
                    txbFactura.AppendText(linea);
                    txbFactura.AppendText(Environment.NewLine);
                }
            }
            else
            {
                foreach (uc_DetProducto detProducto in listaDetProducto)

                {
                    string linea = (detProducto.nomTipProducto + "    $" + detProducto.preExtProducto + "        " + detProducto.canInvProducto + "         " + detProducto.Moneda + " " + detProducto.preBruProducto + "            " + detProducto.desProducto + "         " + detProducto.Moneda + " " + detProducto.preNetProducto);

                    txbFactura.AppendText(linea);
                    txbFactura.AppendText(Environment.NewLine);
                }
            }
            txbFactura.AppendText("MONTO TOTAL: "+moneda+" "+montoTotal);
            txbFactura.AppendText(Environment.NewLine);
            txbFactura.AppendText("DESCUENTO: " + descuentoTotal+ "%");
            txbFactura.AppendText(Environment.NewLine);
            txbFactura.AppendText("MONTO NETO TOTAL: " + moneda + " " + montoNetoTotal);

        }
        public void InfoEmpleado()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            string NombreEmpleado = "Atendido por: " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Empleados.First(d => d.PK_Id_Empleado == IdEmpleado).FK_Id_Persona)).PriNombre_Persona
                                    + " " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Empleados.First(d => d.PK_Id_Empleado == IdEmpleado).FK_Id_Persona)).PriApellido_Persona
                                    + " " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Empleados.First(d => d.PK_Id_Empleado == IdEmpleado).FK_Id_Persona)).SegApellido_Persona;
            txbFactura.AppendText(NombreEmpleado + ".");
            txbFactura.AppendText(Environment.NewLine);
        }
        public void InfoCliente()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            string NombreEmpleado = "Nombre Cliente: " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Clientes.First(d => d.PK_Id_Cliente == IdCliente).FK_Id_Persona)).PriNombre_Persona
                                    + " " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Clientes.First(d => d.PK_Id_Cliente == IdCliente).FK_Id_Persona)).PriApellido_Persona
                                    + " " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Clientes.First(d => d.PK_Id_Cliente == IdCliente).FK_Id_Persona)).SegApellido_Persona;
            txbFactura.AppendText(NombreEmpleado + ".");
            txbFactura.AppendText(Environment.NewLine);
           
            txbFactura.AppendText("TIPO DE FACTURA: " + tipoFactura.ToUpper());
            txbFactura.AppendText(Environment.NewLine);
            txbFactura.AppendText("Nombre    P/UNI   Cantidad   Monto    Descuento  Monto Neto  ");
            txbFactura.AppendText(Environment.NewLine);
           
        }
        public void CargarFinal()
        {

            txbFactura.AppendText(Environment.NewLine);
            txbFactura.AppendText("Metodo de Pago : " + metodoPago.ToUpper());
            txbFactura.AppendText(Environment.NewLine);
           
            if (metodoPago[0].ToString() == "3")
            {
                txbFactura.AppendText("Número de cheque : " + numero);
            }
            else if (metodoPago[0].ToString() == "4")
            {
                txbFactura.AppendText("Número de cuenta : " + numero);
            }
            txbFactura.AppendText(Environment.NewLine);
            txbFactura.AppendText("Saldo Anterior: "+ montoNetoTotal);
            txbFactura.AppendText(Environment.NewLine);
            txbFactura.AppendText("Pago Cliente: " + MontoAbono);
            string fin = (Convert.ToDouble(montoNetoTotal) - Convert.ToDouble(MontoAbono)).ToString();
            txbFactura.AppendText(Environment.NewLine);
            txbFactura.AppendText("Saldo Actual: " + fin);
            txbFactura.AppendText(Environment.NewLine);

        }
        public void CargaInfoFactura()
        {
            if (tipoFactura == "Proforma")
            {
                InfoEmpresa();
                InfoEmpleado();
                InfoCliente();
                CargarDetProducto();

            }
            else if (tipoFactura == "Credito")
            {
                //queda pendiente por dudas
            }
            else if (tipoFactura == "Contado")
            {
                InfoEmpresa();
                InfoEmpleado();
                InfoCliente();
                CargarDetProducto();
                CargarFinal();
            }
               
            
           
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            //int IdEmpleado, IdCliente, IdEmpresa;
            //string tipoFactura, tipoPedido, montoTatal, descuentoTotal, montoNetoTotal, moneda, observaciones, MontoAbono, fechaProPago, metodoPago, numero;
             ObservableCollection<SIGEEA_DetFacCliente> plistaDetProducto = new ObservableCollection<SIGEEA_DetFacCliente>();


            
            MonedaMantenimiento monMant = new MonedaMantenimiento();
            FacturaClienteMantenimiento facMant = new FacturaClienteMantenimiento();
            UnidadMedidaMantenimiento uniMedMant = new UnidadMedidaMantenimiento();
            SIGEEA_FacCliente nuevaFactura = new SIGEEA_FacCliente();
            nuevaFactura.FecEntrega_FacCliente = DateTime.Now;
            nuevaFactura.FecPago_FacCliente = DateTime.Now;
            nuevaFactura.Observaciones_FacCliente = observaciones;
            nuevaFactura.FK_Id_Cliente = IdCliente;
            nuevaFactura.Estado_FacCliente = string.Concat(tipoFactura[0].ToString(), tipoFactura[1].ToString());
            nuevaFactura.MonTotal_FacCliente = Convert.ToDouble(montoTotal);
            nuevaFactura.MonNeto_FacCliente = Convert.ToDouble(montoNetoTotal);
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
                else {
                    nuevoDetalle.PreUnidad_DetFacCliente = Convert.ToDouble(detFacCliente.preExtProducto);
                    nuevoDetalle.Moneda_DetFacCliente = "$";
                }
                
                nuevoDetalle.FK_Id_UniMedida = uniMedMant.PkUniMedida(detFacCliente.UniMedida)[0];
                nuevoDetalle.FK_Id_TipProducto = Convert.ToInt32(detFacCliente.IdTipProducto);
                plistaDetProducto.Add(nuevoDetalle);
            }
            SIGEEA_AboCliente nuevoAbono = new SIGEEA_AboCliente();
            
            nuevoAbono.Monto_AboCliente = Convert.ToDouble(montoTotal);
            nuevoAbono.Metodo_AboCliente = Convert.ToInt32(metodoPago[0].ToString());
            nuevoAbono.Numero_AboCliente = numero;
            nuevoAbono.Fecha_AboCliente = DateTime.Now;
            nuevoAbono.FK_Id_Moneda = monMant.PkMonedas(moneda)[0];
            nuevoAbono.FK_Id_Empleado = IdEmpleado;
            nuevoAbono.Estado_AboCliente = true;
            nuevoAbono.FK_Id_Cliente = IdCliente;
            
            if (tipoFactura == "Proforma")
            {
                facMant.RegistrarFactura(nuevaFactura, plistaDetProducto, null);

            }
            else if (tipoFactura == "Credito")
            {

            }
            else if (tipoFactura == "Contado")
            {
                facMant.RegistrarFactura(nuevaFactura, plistaDetProducto, nuevoAbono);
            }
            MessageBox.Show("Imprimiendo Factura");
        }

    }
}
