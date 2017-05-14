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
        int MetodoPago;
        string numChequeTransferencia;
        double total = 0;
        int Factura;

        public wnwFacturasPendientesPago(int pFactura)
        {
            InitializeComponent();
        //    Factura = pFactura;
          
             try
             {
                 
                 DataClasses1DataContext dc = new DataClasses1DataContext();
                 List<SIGEEA_spObtenerDetallesFacturaSinCancelarAsocResult> lista = dc.SIGEEA_spObtenerDetallesFacturaSinCancelarAsoc(pFactura).ToList();
                 SIGEEA_spObtenerAsociadoFacturaResult informacion = dc.SIGEEA_spObtenerAsociadoFactura(pFactura).First();
                 lblAsociado.Content += " " + informacion.NombreAsociado;
                 lblCedula.Content += " " + informacion.CedParticular_Persona;
                 lblCodigo.Content += " " + informacion.Codigo_Asociado;
                 lblFactura.Content += " " + informacion.Numero_FacAsociado;
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
            foreach (uc_ItemDetallePagoAsoc item in stpContenedor.Children)
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

        private void llamarSegundaPantalla(List<Detalle> detalles)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            ReporteFacturaVenta.Reset();
            Factura = dc.SIGEEA_FacAsociados.First(c => c.PK_Id_FacAsociado == (dc.SIGEEA_DetFacAsociados.First(d => d.PK_Id_DetFacAsociado == detalles.First().getLlave()).FK_Id_FacAsociado)).PK_Id_FacAsociado;
            List<SIGEEA_spObtenerDetallesFacturaCompletaAsocResult> Detalle = new List<SIGEEA_spObtenerDetallesFacturaCompletaAsocResult>();
            List<SIGEEA_spGenerarFacturaEntregaResult> Orden = new List<SIGEEA_spGenerarFacturaEntregaResult>();
            Detalle = dc.SIGEEA_spObtenerDetallesFacturaCompletaAsoc(Factura).ToList();
            Orden = dc.SIGEEA_spGenerarFacturaEntrega(Factura).ToList();
             var source = new ReportDataSource("Detalle", helper.ConvertToDatatable(Detalle));
            var source2 = new ReportDataSource("Orden", helper.ConvertToDatatable(Orden)); 
            ReporteFacturaVenta.LocalReport.DataSources.Add(source);
            ReporteFacturaVenta.LocalReport.DataSources.Add(source2);
            ReporteFacturaVenta.LocalReport.ReportEmbeddedResource = "SIGEEA_App.Facturas.Re_Factura_Pendiente_Pago.rdlc";
            ReporteFacturaVenta.RefreshReport();
            //            txbFactura.Document.Blocks.Clear();
            //          DataClasses1DataContext dc = new DataClasses1DataContext();
            /*  int factura = 
              SIGEEA_spGenerarFacturaEntregaResult encabezado = dc.SIGEEA_spGenerarFacturaEntrega(factura).First();
              List<SIGEEA_spObtenerDetallesFacturaCompletaAsocResult> listaDetalles = dc.SIGEEA_spObtenerDetallesFacturaCompletaAsoc(factura).ToList();
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
              parrafoEncabezado.Inlines.Add(new Run(encabezado.NumFactura.ToString()));

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



              /*Paragraph parrafoFactura = new Paragraph();
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
              run.FontSize = 16;
              run.Text = "Producto          Cantidad total        Cantidad neta          A pagar       Merma              Precio";
              parrafoProductos.Inlines.Add(run);
              parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
              parrafoProductos.Inlines.Add(new Run(Environment.NewLine));



              foreach (Detalle i in detalles)
              {
                  foreach (SIGEEA_spObtenerDetallesFacturaCompletaAsocResult d in listaDetalles)
                  {
                      if (d.PK_Id_DetFacAsociado == i.getLlave())
                      {
                          parrafoProductos.Inlines.Add(new Run(d.Nombre_TipProducto + "              "));
                          parrafoProductos.Inlines.Add(new Run(d.CantidadTotalString + "                      "));
                          parrafoProductos.Inlines.Add(new Run(d.CantidadNetaString + "               "));
                          parrafoProductos.Inlines.Add(new Run((((double)d.CanNeta_DetFacAsociado * i.getMonto()) / ((double)d.CanNeta_DetFacAsociado * Convert.ToDouble(d.Precio.Substring(1)))).ToString("0.00") + "           "));
                          parrafoProductos.Inlines.Add(new Run(d.MERMA + "                    "));
                          parrafoProductos.Inlines.Add(new Run(d.Precio.ToString()));
                          moneda = d.Precio[0].ToString();
                          double totalDetalle = Convert.ToDouble(d.Precio.ToString().Remove(0, 1)) * (double)d.CanNeta_DetFacAsociado;
                          total += i.getMonto() == totalDetalle ? totalDetalle : i.getMonto();
                          parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
                      }
                  }
              }
              parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
              run = new Run();
              run.FontWeight = FontWeights.Bold;
              run.FontSize = 20;
              run.Text = "Total                  " + moneda + total.ToString() + "           ";
              parrafoProductos.Inlines.Add(run);
              parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
              parrafoProductos.Inlines.Add(new Run(Environment.NewLine));
              parrafoProductos.Inlines.Add(new Run("Este recibo es un comprobante legal en el que se respalda que el asociado realizó la entrega de producto. Recomendamos conservarlo."));
              txbFactura.Document.Blocks.Add(parrafoProductos);
              */
        }
        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
        List<Detalle> Detalles;
        string moneda;
        private void btnProcesar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Detalles = new List<Detalle>();
                foreach (uc_ItemDetallePagoAsoc item in stpContenedor.Children)
                {
                    if (item.Seleccionado() == true)
                    {
                        if(Convert.ToDouble(item.TotalDet.Substring(1)) <= Convert.ToDouble(item.txbMonto.Text))
                            throw new Exception("El abono a pagar no puede ser superior al monto adeudado.");
                    }
                    Detalles.Add(new Detalle(item.PkDetalleFactura, item.txbMonto.Text != String.Empty ? Convert.ToDouble(item.txbMonto.Text) : Convert.ToDouble(item.lblTotal.Text.Substring(1))));             
                }
                if (Detalles.Count > 0)
                {
                    grdPrimera.Visibility = Visibility.Collapsed;
                    grdSegunda.Visibility = Visibility.Visible;
                    llamarSegundaPantalla(Detalles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public class Detalle
        {
            public Detalle(int pLlave, double pMonto)
            {
                this.pkDetalle = pLlave;
                this.Monto = pMonto;
            }
            private int pkDetalle;
            private double Monto;

            public int getLlave() { return this.pkDetalle; }
            public double getMonto() { return this.Monto; }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            brdPopUp.Visibility = Visibility.Visible;
            grdSegunda.IsEnabled = false;
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            grdPrimera.Visibility = Visibility.Visible;
            grdSegunda.Visibility = Visibility.Collapsed;
            total = 0;
        }


        private void print(RichTextBox pFactura)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.Equals(true))
            {
                printDialog.PrintDocument((((IDocumentPaginatorSource)pFactura.Document).DocumentPaginator), "Imprimiendo");
            }
        }

        private void btnTransaccionListo_Click(object sender, RoutedEventArgs e)
        {
            numChequeTransferencia = txbNumTransaccionPop.Text;
            grdPrimeraPop.Visibility = Visibility.Visible;
            grdTransaccionPop.Visibility = Visibility.Collapsed;
            txbNumTransaccionPop.Text = "Digite el número de transacción";
            rbtTransferencia.IsChecked = false;
            brdPopUp.Visibility = Visibility.Collapsed;
            grdSegunda.IsEnabled = true;
        }

        private void btnChequeListo_Click(object sender, RoutedEventArgs e)
        {
            numChequeTransferencia = txbNumChequePop.Text;
            grdPrimeraPop.Visibility = Visibility.Visible;
            txbNumChequePop.Text = "Digite el número de cheque";
            grdChequePop.Visibility = Visibility.Collapsed;
            rbtCheque.IsChecked = false;
            brdPopUp.Visibility = Visibility.Collapsed;
            grdSegunda.IsEnabled = true;
        }

        private void btnSiguientePop_Click(object sender, RoutedEventArgs e)
        {
            if (rbtEfectivo.IsChecked == true)
            {
                brdPopUp.Visibility = Visibility.Collapsed;
                MetodoPago = 1; //Efectivo
                grdSegunda.IsEnabled = true;
                btnCancelar.Visibility = Visibility.Collapsed;
                btnEfectuarPago.Visibility = Visibility.Visible;
                grdPrimeraPop.Visibility = Visibility.Visible;
                rbtEfectivo.IsChecked = false;
            }
            else if (rbtCheque.IsChecked == true)
            {
                grdPrimeraPop.Visibility = Visibility.Collapsed;
                grdChequePop.Visibility = Visibility.Visible;
                btnCancelar.Visibility = Visibility.Collapsed;
                btnEfectuarPago.Visibility = Visibility.Visible;
                MetodoPago = 2; //Cheque
            }
            else if (rbtTransferencia.IsChecked == true)
            {
                grdPrimeraPop.Visibility = Visibility.Collapsed;
                grdTransaccionPop.Visibility = Visibility.Visible;
                btnCancelar.Visibility = Visibility.Collapsed;
                btnEfectuarPago.Visibility = Visibility.Visible;
                MetodoPago = 3; //Transferencia
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnCerrarPop_Click(object sender, RoutedEventArgs e)
        {
            grdSegunda.IsEnabled = true;
            grdChequePop.Visibility = Visibility.Collapsed;
            grdTransaccionPop.Visibility = Visibility.Collapsed;
            txbNumChequePop.Text = "Digite el número de cheque";
            txbNumTransaccionPop.Text = "Digite el número de transacción";
            grdPrimeraPop.Visibility = Visibility.Visible;
            grdChequePop.Visibility = Visibility.Collapsed;
            rbtCheque.IsChecked = false;
            rbtTransferencia.IsChecked = false;
            rbtEfectivo.IsChecked = false;
            brdPopUp.Visibility = Visibility.Collapsed;
            grdSegunda.IsEnabled = true;
        }

        private void btnEfectuarPago_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> llaves = new List<int>();
                List<double> montos = new List<double>();
                foreach (Detalle d in Detalles)
                {
                    llaves.Add(d.getLlave());
                    montos.Add(d.getMonto());
                }
                if (Detalles.Count > 0 && MessageBox.Show("¿Realmente quiere realizar el pago?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    AsociadoMantenimiento asociado = new AsociadoMantenimiento();
                    if (asociado.CancelaFacturaAsociado(llaves, montos, MetodoPago, numChequeTransferencia, total) == true)
                    {
                        MessageBox.Show("Pago realizado con éxito", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        //print(txbFactura);
                    }
                    else throw new ArgumentException("No se ha seleccionado ningún elemento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
