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
        public wnwCancelarFacturaCliente(int pkIdEmpleado, int pkIdCliente, string Tipo, int pkIdEmpresa, string ptipoPedido, ObservableCollection<uc_DetProducto> nueva, string pMontoTotal, string pDescuentoTotal, string pMontoNetoTotal, string pMonedaTotal, string pObservaciones, string pMontoAbono, DateTime pfechaProPago, DateTime pfechaLimPago, string pmetodoPago, string pnumero)
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
            fechaLimite = pfechaLimPago;
            observaciones = pObservaciones;
            MontoAbono = pMontoAbono;
            fechaProPago = pfechaProPago;
            metodoPago = pmetodoPago;
            numero = pnumero;
            CargarFinal();




        }
        int IdEmpleado, IdCliente, IdEmpresa;
        string tipoFactura, tipoPedido, montoTotal, descuentoTotal, montoNetoTotal, moneda, observaciones, MontoAbono, metodoPago, numero, NombreEmpleado, NombreCliente;
        DateTime fechaProPago, fechaLimite;
        ObservableCollection<uc_DetProducto> listaDetProducto = new ObservableCollection<uc_DetProducto>();
        MonedaMantenimiento monMant = new MonedaMantenimiento();
        FacturaClienteMantenimiento facMant = new FacturaClienteMantenimiento();
        UnidadMedidaMantenimiento uniMedMant = new UnidadMedidaMantenimiento();
        ClienteMantenimiento cliMant = new ClienteMantenimiento();
        string Nombre, Cedula, Direccion, Telefono, Correo, Fecha, Hora;
        double fin;

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


            Cedula = "Ced. Juridica N°:" + dc.SIGEEA_Empresas.First(c => c.PK_Id_Empresa == IdEmpresa).CedJuridica_Empresa;


            Direccion = dc.SIGEEA_Empresas.First(c => c.PK_Id_Empresa == IdEmpresa).Direccion_Empresa;


            Telefono = dc.SIGEEA_Empresas.First(c => c.PK_Id_Empresa == IdEmpresa).Telefono_Empresa;


            Correo = dc.SIGEEA_Empresas.First(c => c.PK_Id_Empresa == IdEmpresa).Correo_Empresa;


            Fecha = DateTime.Now.ToShortDateString();

            Hora = DateTime.Now.ToShortTimeString();



        }
        public void CargarDetProducto()
        {


        }
        public void InfoEmpleado()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            NombreEmpleado = "Atendido por: " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Empleados.First(d => d.PK_Id_Empleado == IdEmpleado).FK_Id_Persona)).PriNombre_Persona
                                   + " " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Empleados.First(d => d.PK_Id_Empleado == IdEmpleado).FK_Id_Persona)).PriApellido_Persona
                                   + " " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Empleados.First(d => d.PK_Id_Empleado == IdEmpleado).FK_Id_Persona)).SegApellido_Persona;

        }
        public void InfoCliente()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            NombreCliente = "Nombre Cliente: " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Clientes.First(d => d.PK_Id_Cliente == IdCliente).FK_Id_Persona)).PriNombre_Persona
                                    + " " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Clientes.First(d => d.PK_Id_Cliente == IdCliente).FK_Id_Persona)).PriApellido_Persona
                                    + " " + dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == (dc.SIGEEA_Clientes.First(d => d.PK_Id_Cliente == IdCliente).FK_Id_Persona)).SegApellido_Persona;

        }
        public void CargarFinal()
        {
            InfoEmpresa();
            InfoEmpleado();
            InfoCliente();

            Run run;

            Paragraph parrafoEncabezado = new Paragraph();
            parrafoEncabezado.TextAlignment = TextAlignment.Center;
            parrafoEncabezado.FontFamily = new FontFamily("Agency FB");
            parrafoEncabezado.FontSize = 18;

            parrafoEncabezado.Inlines.Add(new Run(Nombre));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run(Cedula + ""));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run(Direccion + ""));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run("Teléfono: " + Telefono + ""));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run("Correo: " + Correo + ""));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run("Fecha: " + Fecha + ""));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run("Hora: " + Hora + ""));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run(NombreEmpleado + "."));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run(NombreCliente + "."));


            txbFactura.Document.Blocks.Add(parrafoEncabezado);
            run = new Run();
            Paragraph parrafoFactura = new Paragraph();
            parrafoFactura.TextAlignment = TextAlignment.Left;
            parrafoFactura.FontFamily = new FontFamily("Agency FB");
            parrafoFactura.FontSize = 16;

            parrafoFactura.Inlines.Add("NÚMERO DE FACTURA: " + (facMant.ObtenerIdUltimaFactura().PKFactura + 1).ToString());
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            if (tipoFactura == "Crédito")
            {

                parrafoFactura.Inlines.Add("FECHA LIMITE DE PAGO: " + fechaLimite.ToShortDateString().ToUpper());
                parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
                parrafoFactura.Inlines.Add("PROXIMO PAGO: " + fechaProPago.ToShortDateString().ToUpper());
                parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            }

            parrafoFactura.Inlines.Add("Nombre P/ UNI   Cantidad Monto    Descuento Monto Neto");
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            parrafoFactura.Inlines.Add("_______________________________________________________");
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            if (tipoPedido == "NACIONAL")
            {
                foreach (uc_DetProducto detProducto in listaDetProducto)

                {
                    string linea = (detProducto.nomTipProducto + "    ¢" + detProducto.preNacProducto + "        " + detProducto.canInvProducto + "         " + detProducto.Moneda + " " + detProducto.preBruProducto + "            " + detProducto.desProducto + "         " + detProducto.Moneda + " " + detProducto.preNetProducto);
                    parrafoFactura.Inlines.Add(linea);
                    parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
                }
            }
            else
            {
                foreach (uc_DetProducto detProducto in listaDetProducto)

                {
                    string linea = (detProducto.nomTipProducto + "    $" + detProducto.preExtProducto + "        " + detProducto.canInvProducto + "         " + detProducto.Moneda + " " + detProducto.preBruProducto + "            " + detProducto.desProducto + "         " + detProducto.Moneda + " " + detProducto.preNetProducto);
                    parrafoFactura.Inlines.Add(linea);
                    parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
                }
            }


            parrafoFactura.Inlines.Add("_______________________________________________________");
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            run = new Run();
            run.FontWeight = FontWeights.Bold;
            run.FontSize = 20;
            parrafoFactura.Inlines.Add("MONTO TOTAL: " + moneda + " " + montoTotal);
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            parrafoFactura.Inlines.Add("DESCUENTO: " + descuentoTotal + "%");
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            parrafoFactura.Inlines.Add("MONTO NETO TOTAL: " + moneda + " " + montoNetoTotal);
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));


            parrafoFactura.Inlines.Add("Metodo de Pago : " + metodoPago.ToUpper());
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));

            txbFactura.AppendText("Metodo de Pago : " + metodoPago.ToUpper());
            txbFactura.AppendText(Environment.NewLine);

            if (metodoPago[0].ToString() == "3")
            {
                parrafoFactura.Inlines.Add("Número de cheque : " + numero);
                parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            }
            else if (metodoPago[0].ToString() == "4")
            {
                parrafoFactura.Inlines.Add("Número de cuenta : " + numero);
                parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            }
            parrafoFactura.Inlines.Add("Saldo Anterior: " + montoNetoTotal);
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));

            parrafoFactura.Inlines.Add("Pago Cliente: " + MontoAbono);
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));

            fin = Convert.ToDouble(montoNetoTotal) - Convert.ToDouble(MontoAbono);
            parrafoFactura.Inlines.Add("Saldo Actual: " + Math.Round(fin, 2));
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            parrafoFactura.Inlines.Add(new Run("Observaciones: " + observaciones));
            txbFactura.Document.Blocks.Add(parrafoFactura);

        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            //int IdEmpleado, IdCliente, IdEmpresa;
            //string tipoFactura, tipoPedido, montoTatal, descuentoTotal, montoNetoTotal, moneda, observaciones, MontoAbono, fechaProPago, metodoPago, numero;
            ObservableCollection<SIGEEA_DetFacCliente> plistaDetProducto = new ObservableCollection<SIGEEA_DetFacCliente>();

            SIGEEA_FacCliente nuevaFactura = new SIGEEA_FacCliente();
            nuevaFactura.FecEntrega_FacCliente = DateTime.Now;
            nuevaFactura.FecPago_FacCliente = DateTime.Now;
            nuevaFactura.Observaciones_FacCliente = observaciones;
            nuevaFactura.FK_Id_Cliente = IdCliente;

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
            if (tipoFactura == "Proforma")
            {
                nuevaFactura.Estado_FacCliente = "PR";
                facMant.RegistrarFactura(nuevaFactura, plistaDetProducto, null, null);

            }
            else if (tipoFactura == "Crédito")
            {
                nuevaFactura.Estado_FacCliente = "CR";
                SIGEEA_CreCliente nuevoCredito = new SIGEEA_CreCliente();
                nuevoCredito.Estado_CreCliente = true;
                nuevoCredito.Fecha_CreCliente = DateTime.Now;
                nuevoCredito.Monto_CreCliente = Convert.ToDouble(montoNetoTotal);
                nuevoCredito.Saldo_CreCliente = fin;
                nuevoCredito.FecProPago_CreCliente = fechaProPago;
                nuevoCredito.FecLimPago_CreCliente = fechaLimite;
                nuevoCredito.FK_Id_Cliente = IdCliente;
                nuevoCredito.FK_Id_Moneda = monMant.PkMonedas(moneda)[0];

                SIGEEA_AboCliente nuevoAbono = new SIGEEA_AboCliente();
                nuevoAbono.Monto_AboCliente = Convert.ToDouble(MontoAbono);
                nuevoAbono.Metodo_AboCliente = Convert.ToInt32(metodoPago[0].ToString());
                nuevoAbono.Numero_AboCliente = numero;
                nuevoAbono.Fecha_AboCliente = DateTime.Now;
                nuevoAbono.FK_Id_Moneda = monMant.PkMonedas(moneda)[0];
                nuevoAbono.FK_Id_Empleado = IdEmpleado;
                nuevoAbono.Estado_AboCliente = true;
                nuevoAbono.FK_Id_Cliente = IdCliente;

                facMant.RegistrarFactura(nuevaFactura, plistaDetProducto, nuevoAbono, nuevoCredito);
            }
            else if (tipoFactura == "Contado")
            {
                SIGEEA_AboCliente nuevoAbono = new SIGEEA_AboCliente();
                nuevoAbono.Monto_AboCliente = Convert.ToDouble(montoTotal);
                nuevoAbono.Metodo_AboCliente = Convert.ToInt32(metodoPago[0].ToString());
                nuevoAbono.Numero_AboCliente = numero;
                nuevoAbono.Fecha_AboCliente = DateTime.Now;
                nuevoAbono.FK_Id_Moneda = monMant.PkMonedas(moneda)[0];
                nuevoAbono.FK_Id_Empleado = IdEmpleado;
                nuevoAbono.Estado_AboCliente = true;
                nuevoAbono.FK_Id_Cliente = IdCliente;
                nuevaFactura.Estado_FacCliente = "CO";
                facMant.RegistrarFactura(nuevaFactura, plistaDetProducto, nuevoAbono, null);

            }
            MessageBox.Show("Imprimiendo Factura");
            print(txbFactura);
        }
        private void print(RichTextBox pFactura)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.Equals(true))
            {
                printDialog.PrintDocument((((IDocumentPaginatorSource)pFactura.Document).DocumentPaginator), "Imprimiendo");
            }
        }

    }
}

