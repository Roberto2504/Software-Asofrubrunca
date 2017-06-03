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

using SIGEEA_App.Facturas;
using Microsoft.Reporting.WinForms;

using SIGEEA_BL;
using SIGEEA_BO;

namespace SIGEEA_App.Ventanas_Modales.Empleados
{
    /// <summary>
    /// Interaction logic for wnwCancelarPagoEmpleado.xaml
    /// </summary>
    public partial class wnwCancelarPagoEmpleado : MetroWindow
    {
        double total = 0;
        double horas = 0;
        int pk_empleado;
        List<SIGEEA_spObtenerPagosEmpleadosPendientesResult> Lista = new List<SIGEEA_spObtenerPagosEmpleadosPendientesResult>();

        public wnwCancelarPagoEmpleado(List<SIGEEA_spObtenerPagosEmpleadosPendientesResult> pLista, int pEmpleado)
        {
            InitializeComponent();


            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            ReporteFacturaVenta.Reset();
            
            
            List<SIGEEA_spGenerarFacturaPagoEmpleadoResult> Orden = new List<SIGEEA_spGenerarFacturaPagoEmpleadoResult>();
           
            Orden = dc.SIGEEA_spGenerarFacturaPagoEmpleado(pEmpleado).ToList();
            var source = new ReportDataSource("Detalle", helper.ConvertToDatatable(pLista));
            var source2 = new ReportDataSource("Orden", helper.ConvertToDatatable(Orden));
            ReporteFacturaVenta.LocalReport.DataSources.Add(source);
            ReporteFacturaVenta.LocalReport.DataSources.Add(source2);
            ReporteFacturaVenta.LocalReport.ReportEmbeddedResource = "SIGEEA_App.Facturas.Re_Cancelar_Pago_Empleado.rdlc";
            ReporteFacturaVenta.RefreshReport();



            /*SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();

            SIGEEA_spGenerarFacturaPagoEmpleadoResult encabezado = dc.SIGEEA_spGenerarFacturaPagoEmpleado(pEmpleado).First();



            Paragraph parrafoEncabezado = new Paragraph();
            parrafoEncabezado.TextAlignment = TextAlignment.Center;
            parrafoEncabezado.FontFamily = new FontFamily("Agency FB");
            parrafoEncabezado.FontSize = 18;

            parrafoEncabezado.Inlines.Add(new Run(encabezado.Nombre_Empresa));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run(encabezado.CedJuridica));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run(encabezado.Direccion_Empresa));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run(encabezado.Telefono));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run(encabezado.Correo));
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run(encabezado.Fecha));
            parrafoEncabezado.Inlines.Add(new Run("  " + encabezado.Hora));

            txbFactura.Document.Blocks.Add(parrafoEncabezado);

            Paragraph parrafoEmpleado = new Paragraph();
            parrafoEmpleado.TextAlignment = TextAlignment.Left;
            parrafoEmpleado.FontFamily = new FontFamily("Agency FB");
            parrafoEmpleado.FontSize = 16;

            parrafoEmpleado.Inlines.Add(new Run(encabezado.NombreAsociado));
            parrafoEmpleado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEmpleado.Inlines.Add(new Run(encabezado.CedPersona));
            parrafoEmpleado.Inlines.Add(new Run(Environment.NewLine));
            txbFactura.Document.Blocks.Add(parrafoEmpleado);


            Lista = pLista;
            pk_empleado = pEmpleado;


            Paragraph parrafoFactura = new Paragraph();
            parrafoFactura.TextAlignment = TextAlignment.Left;
            parrafoFactura.FontFamily = new FontFamily("Agency FB");
            parrafoFactura.FontSize = 16;

            parrafoFactura.Inlines.Add("Puesto      Horas       Precio      Total");
            parrafoFactura.Inlines.Add(Environment.NewLine);

            foreach (SIGEEA_spObtenerPagosEmpleadosPendientesResult p in pLista)
            {
                total += Convert.ToDouble(p.Total.Remove(0,1));
                horas += Convert.ToDouble(p.Diferencia);
                parrafoFactura.Inlines.Add(p.Nombre_Puesto + "      " + p.Diferencia +"         "+ p.Tarifa + "      " + p.Total);
                parrafoFactura.Inlines.Add(Environment.NewLine);        
            }

            txbFactura.Document.Blocks.Add(parrafoFactura);

            Paragraph parrafoTotal = new Paragraph();
            parrafoTotal.TextAlignment = TextAlignment.Left;
            parrafoTotal.FontFamily = new FontFamily("Agency FB");
            parrafoTotal.FontSize = 16;
            parrafoTotal.Inlines.Add("Total a cancelar: ₡" + total.ToString());
            parrafoTotal.Inlines.Add(Environment.NewLine);
            parrafoTotal.Inlines.Add("Horas laboradas: " + horas.ToString());


            txbFactura.Document.Blocks.Add(parrafoTotal);*/
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente quiere realizar el pago?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();
                    empleado.CancelarPago(Lista, pk_empleado);
                    MessageBox.Show("Pago realizado exitosamente.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == DialogResult.Equals(true))
                    {
                        //printDialog.PrintDocument((((IDocumentPaginatorSource)txbFactura.Document).DocumentPaginator), "Imprimiendo...");
                    }
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al realizar el pago solicitado: " + Ex.Message, "SIGEEA", MessageBoxButton.OK);
            }
        }
        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
