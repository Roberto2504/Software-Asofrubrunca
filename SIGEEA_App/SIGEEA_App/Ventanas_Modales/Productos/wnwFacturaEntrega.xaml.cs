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

using SIGEEA_BL;
using SIGEEA_BO;
using Microsoft.Reporting.WinForms;

namespace SIGEEA_App.Ventanas_Modales.Productos
{
    /// <summary>
    /// Interaction logic for wnwFacturaEntrega.xaml
    /// </summary>
    public partial class wnwFacturaEntrega : MetroWindow
    {
        List<SIGEEA_spGenerarFacturaEntregaResult> encabezado;
        List<SIGEEA_spObtenerDetallesEntregaResult> detalles;
        string CodigoAsociado;
        public wnwFacturaEntrega(int factura, string pAsociado)
        {
            InitializeComponent();
            CodigoAsociado = pAsociado;
            GeneraFactura(factura);

        }

        private void GeneraFactura(int factura)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            encabezado = dc.SIGEEA_spGenerarFacturaEntrega(factura).ToList();
            detalles = dc.SIGEEA_spObtenerDetallesEntrega(factura).ToList();

            var source = new ReportDataSource("Detalle", SIGEEA.BL.Facturas.helper.ConvertToDatatable(detalles));
            var source2 = new ReportDataSource("Encabezado", SIGEEA.BL.Facturas.helper.ConvertToDatatable(encabezado));



            ReporteFacturaEntrega.LocalReport.DataSources.Add(source);
            ReporteFacturaEntrega.LocalReport.DataSources.Add(source2);
            ReporteFacturaEntrega.LocalReport.ReportEmbeddedResource = "SIGEEA_App.Facturas.Re_Factura_Orden_Venta.rdlc";
            ReporteFacturaEntrega.RefreshReport();

            //Paragraph parrafoEncabezado = new Paragraph();
            //parrafoEncabezado.TextAlignment = TextAlignment.Center;
            //parrafoEncabezado.FontFamily = new FontFamily("Agency FB");
            //parrafoEncabezado.FontSize = 18;

            //parrafoEncabezado.Inlines.Add(new Run(encabezado.Nombre_Empresa));
            //parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            //parrafoEncabezado.Inlines.Add(new Run(encabezado.CedJuridica));
            //parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            //parrafoEncabezado.Inlines.Add(new Run(encabezado.Direccion_Empresa));
            //parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            //parrafoEncabezado.Inlines.Add(new Run(encabezado.Telefono));
            //parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            //parrafoEncabezado.Inlines.Add(new Run(encabezado.Correo));
            //parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            //parrafoEncabezado.Inlines.Add(new Run(encabezado.Fecha));
            //parrafoEncabezado.Inlines.Add(new Run("  " + encabezado.Hora));
            //parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            //parrafoEncabezado.Inlines.Add(new Run(encabezado.NumFactura));

            //txbFactura.Document.Blocks.Add(parrafoEncabezado);//FINAL

            //Paragraph parrafoAsociado = new Paragraph();
            //parrafoAsociado.TextAlignment = TextAlignment.Left;
            //parrafoAsociado.FontFamily = new FontFamily("Agency FB");
            //parrafoAsociado.FontSize = 16;

            //parrafoAsociado.Inlines.Add(new Run(encabezado.NombreAsociado));
            //parrafoAsociado.Inlines.Add(new Run(Environment.NewLine));
            //parrafoAsociado.Inlines.Add(new Run(encabezado.CedPersona));
            //parrafoAsociado.Inlines.Add(new Run(Environment.NewLine));
            //parrafoAsociado.Inlines.Add(new Run(encabezado.CodigoAsociado));
            //txbFactura.Document.Blocks.Add(parrafoAsociado);


            //Paragraph parrafoProductos = new Paragraph();
            //parrafoProductos.TextAlignment = TextAlignment.Left;
            //parrafoProductos.FontFamily = new FontFamily("Agency FB");
            //parrafoProductos.FontSize = 16;
            //parrafoProductos.Inlines.Add(new Run("Producto           Cantidad          Precio"));
            //parrafoProductos.Inlines.Add(new Run(Environment.NewLine));

            //foreach (SIGEEA_spObtenerDetallesEntregaResult d in detalles)
            //{

            //    parrafoProductos.Inlines.Add(new Run(d.Nombre_TipProducto + "          "));
            //    parrafoProductos.Inlines.Add(new Run(d.CanTotal_DetFacAsociado + "              "));
            //    parrafoProductos.Inlines.Add(new Run(d.Precio));
            //    parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
            //}
            //parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
            //parrafoProductos.Inlines.Add(new Run("Este recibo es un comprobante legal en el que se respalda que el asociado realizó la entrega de producto. Recomendamos conservarlo."));
            //txbFactura.Document.Blocks.Add(parrafoProductos);










        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAnular_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Realmente quiere cancelar la entrega?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AsociadoMantenimiento asoc = new AsociadoMantenimiento();

                string mensaje = asoc.AnularEntregaProducto(encabezado.First().NumFactura);
                if (mensaje.Equals("OK"))
                {
                    wnwEntregaProducto ventana = new wnwEntregaProducto(asoc.obtenerAsociadoPorID(CodigoAsociado), detalles);
                    this.Close();
                    ventana.ShowDialog();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }
    }
}
