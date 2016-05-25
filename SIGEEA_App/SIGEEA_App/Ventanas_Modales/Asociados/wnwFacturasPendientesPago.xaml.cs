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

using SIGEEA_BO;
using SIGEEA_BL;
using SIGEEA_App.User_Controls.Productos;


namespace SIGEEA_App.Ventanas_Modales.Asociados
{
    /// <summary>
    /// Interaction logic for wnwFacturasPendientesPago.xaml
    /// </summary>
    public partial class wnwFacturasPendientesPago : MetroWindow
    {
        public wnwFacturasPendientesPago(int pFactura)
        {
            InitializeComponent();
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                List<SIGEEA_spObtenerDetallesFacturaSinCancelarAsocResult> lista = dc.SIGEEA_spObtenerDetallesFacturaSinCancelarAsoc(pFactura).ToList();
                SIGEEA_spObtenerAsociadoFacturaResult informacion = dc.SIGEEA_spObtenerAsociadoFactura(pFactura).First();
                lblAsociado.Content += " " + informacion.NombreAsociado;
                lblCedula.Content += " " + informacion.CedParticular_Persona;
                lblCodigo.Content += " " + informacion.Codigo_Asociado;
                lblFactura.Content += " " + pFactura;
                lblFecEntrega.Content += " " + informacion.Fecha;
                if (lista.Count <= 0) throw new Exception("No se encontraron registros");
                bool color = true;
                foreach (SIGEEA_spObtenerDetallesFacturaSinCancelarAsocResult df in lista)
                {
                    uc_ItemDetallePagoAsoc item = new uc_ItemDetallePagoAsoc(df, color);
                    item.cbxSeleccionar.Checked += CbxSeleccionar_Checked;
                    item.cbxSeleccionar.Unchecked += CbxSeleccionar_Unchecked;
                    color = !color;
                    stpContenedor.Children.Add(item);
                }
            }
            catch (Exception ex)
            {
                Label lblVacio = new Label();
                lblVacio.Foreground = Brushes.IndianRed;
                lblVacio.FontSize = 18;
                lblVacio.Width = 430;
                lblVacio.Content = "Error: " + ex.Message;
                lblVacio.FontWeight = FontWeights.ExtraBold;
                stpContenedor.Children.Add(lblVacio);
            }
        }

        private void CbxSeleccionar_Unchecked(object sender, RoutedEventArgs e)
        {
            bool boton = true;
            foreach(uc_ItemDetallePagoAsoc item in stpContenedor.Children)
            {
                if (item.Seleccionado() == true) boton = false;
            }
            if (boton == false) btnProcesar.IsEnabled = true;
            else btnProcesar.IsEnabled = false;
                
        }

        private void CbxSeleccionar_Checked(object sender, RoutedEventArgs e)
        {
            btnProcesar.IsEnabled = true;
        }

        private void llamarSegundaPantalla(List<int> detalles)
        {
            txbFactura.Document.Blocks.Clear();
            DataClasses1DataContext dc = new DataClasses1DataContext();
            int factura = dc.SIGEEA_FacAsociados.First(c => c.PK_Id_FacAsociado == (dc.SIGEEA_DetFacAsociados.First(d => d.PK_Id_DetFacAsociado == detalles.First()).FK_Id_FacAsociado)).PK_Id_FacAsociado;
            SIGEEA_spGenerarFacturaEntregaResult encabezado = dc.SIGEEA_spGenerarFacturaEntrega(factura).First();
            SIGEEA_spObtenerFacturaCompletaAsocResult infoFactura = dc.SIGEEA_spObtenerFacturaCompletaAsoc(factura).First();
            List<SIGEEA_spObtenerDetallesEntregaResult> listaDetalles = dc.SIGEEA_spObtenerDetallesEntrega(factura).ToList();
            String uMedida = infoFactura.CantidadNeta.Substring(infoFactura.CantidadNeta.Length - 2);
            Run run;

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
            parrafoEncabezado.Inlines.Add(new Run(Environment.NewLine));
            parrafoEncabezado.Inlines.Add(new Run(encabezado.NumFactura));

            txbFactura.Document.Blocks.Add(parrafoEncabezado);//FINAL

            Paragraph parrafoAsociado = new Paragraph();
            parrafoAsociado.TextAlignment = TextAlignment.Left;
            parrafoAsociado.FontFamily = new FontFamily("Agency FB");
            parrafoAsociado.FontSize = 16;

            parrafoAsociado.Inlines.Add(new Run(encabezado.NombreAsociado));
            parrafoAsociado.Inlines.Add(new Run(Environment.NewLine));
            parrafoAsociado.Inlines.Add(new Run(encabezado.CedPersona));
            parrafoAsociado.Inlines.Add(new Run(Environment.NewLine));
            parrafoAsociado.Inlines.Add(new Run(encabezado.CodigoAsociado));
            txbFactura.Document.Blocks.Add(parrafoAsociado);



            Paragraph parrafoFactura = new Paragraph();
            parrafoFactura.TextAlignment = TextAlignment.Left;
            parrafoFactura.FontFamily = new FontFamily("Agency FB");
            parrafoFactura.FontSize = 16;
            parrafoFactura.Inlines.Add(new Run("______________________________________________________________________________________________"));
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            parrafoFactura.Inlines.Add(new Run("Cantidad total entregada: " + infoFactura.CantidadTotal));
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            parrafoFactura.Inlines.Add(new Run("Cantidad neta: " + infoFactura.CantidadNeta));
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            parrafoFactura.Inlines.Add(new Run("Merma: " + infoFactura.MERMA));
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            parrafoFactura.Inlines.Add(new Run("______________________________________________________________________________________________"));
            parrafoFactura.Inlines.Add(new Run(Environment.NewLine));
            txbFactura.Document.Blocks.Add(parrafoFactura);


            Paragraph parrafoProductos = new Paragraph();
            parrafoProductos.TextAlignment = TextAlignment.Left;
            parrafoProductos.FontFamily = new FontFamily("Agency FB");
            parrafoProductos.FontSize = 16;

            run = new Run();
            run.FontWeight = FontWeights.Bold;
            run.FontSize = 20;
            run.Text = "Producto          Cantidad                Precio";
            parrafoProductos.Inlines.Add(run);
            parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
            parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
            double total = 0;

            foreach (int i in detalles)
            {
                foreach (SIGEEA_spObtenerDetallesEntregaResult d in listaDetalles)
                {
                    if (d.PK_Id_DetFacAsociado == i)
                    {
                        parrafoProductos.Inlines.Add(new Run(d.Nombre_TipProducto + "                   "));
                        parrafoProductos.Inlines.Add(new Run(d.CanNeta_DetFacAsociado + uMedida + "                               "));
                        parrafoProductos.Inlines.Add(new Run(d.Precio));
                        total += (int)d.CanNeta_DetFacAsociado;
                        parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
                    }
                }
            }
            parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
            run = new Run();
            run.FontWeight = FontWeights.Bold;
            run.FontSize = 20;
            run.Text = "Total                  " + total.ToString() + uMedida + "           ";
            parrafoProductos.Inlines.Add(run);
            parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
            parrafoProductos.Inlines.Add(new Run("Este recibo es un comprobante legal en el que se respalda que el asociado realizó la entrega de producto. Recomendamos conservarlo."));
            txbFactura.Document.Blocks.Add(parrafoProductos);
        }
        List<int> Detalles;
        private void btnProcesar_Click(object sender, RoutedEventArgs e)
        {
            Detalles = new List<int>();
            foreach(uc_ItemDetallePagoAsoc item in stpContenedor.Children)
            {
                if (item.Seleccionado() == true)
                    Detalles.Add(item.PkDetalleFactura);
            }
            if(Detalles.Count > 0)
            {
                grdPrimera.Visibility = Visibility.Collapsed;
                grdSegunda.Visibility = Visibility.Visible;
                llamarSegundaPantalla(Detalles);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Detalles.Count > 0 && MessageBox.Show("¿Realmente quiere realizar el pago?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    AsociadoMantenimiento asociado = new AsociadoMantenimiento();
                    if (asociado.CancelaFacturaAsociado(Detalles) == true)
                    {
                        MessageBox.Show("Pago realizado con éxito", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        print(txbFactura);
                    }
                    else throw new ArgumentException("No se ha seleccionado ningún elemento.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            grdPrimera.Visibility = Visibility.Visible;
            grdSegunda.Visibility = Visibility.Collapsed;
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
