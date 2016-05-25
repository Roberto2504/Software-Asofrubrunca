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

namespace SIGEEA_App.Ventanas_Modales.Asociados
{
    /// <summary>
    /// Interaction logic for wnwOpcionesFacturaProducto.xaml
    /// </summary>
    public partial class wnwOpcionesFacturaProducto : MetroWindow
    {
        bool solicitud;
        public wnwOpcionesFacturaProducto(bool pSolicitud)
        {
            InitializeComponent();
            //pSolicitud = true : si se desean obtener facturas pendientes
            //pSolicitud = false : si se desean obtener facturas incompletas
            solicitud = pSolicitud;
            cmbOpciones.Items.Add("Todas las facturas pendientes");
            cmbOpciones.Items.Add("Todas las facturas pendientes de un asociado");
            cmbOpciones.Items.Add("A partir del número de factura");
        }

        private void cmbOpciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbOpciones.SelectedIndex == 0)//Listar todas
            {
                grdAsociado.Visibility = Visibility.Collapsed;
                grdFacturaUnica.Visibility = Visibility.Collapsed;
                grdTodas.Visibility = Visibility.Visible;
                btnTodas.IsDefault = true;
                btnListaFacAsociado.IsDefault = false;
                btnFactura.IsDefault = false;
            }
            else if (cmbOpciones.SelectedIndex == 1)//Listar las de un asociado
            {
                grdAsociado.Visibility = Visibility.Visible;
                grdFacturaUnica.Visibility = Visibility.Collapsed;
                grdTodas.Visibility = Visibility.Collapsed;
                btnTodas.IsDefault = false;
                btnListaFacAsociado.IsDefault = true;
                btnFactura.IsDefault = false;
            }
            else if (cmbOpciones.SelectedIndex == 2)//A partir de su número de factura
            {
                grdAsociado.Visibility = Visibility.Collapsed;
                grdFacturaUnica.Visibility = Visibility.Visible;
                grdTodas.Visibility = Visibility.Collapsed;
                btnTodas.IsDefault = false;
                btnListaFacAsociado.IsDefault = false;
                btnFactura.IsDefault = true;
            }
        }

        private void btnTodas_Click(object sender, RoutedEventArgs e)
        {         
            wnwFacturasPendientes ventana = new wnwFacturasPendientes(null,solicitud);
            ventana.ShowDialog();
        }

        private void btnListaFacAsociado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AsociadoMantenimiento asociado = new AsociadoMantenimiento();
                if (asociado.AutenticaAsociado(txbAsociado.Text) != null)
                {
                    wnwFacturasPendientes ventana = new wnwFacturasPendientes(txbAsociado.Text,solicitud);
                    ventana.ShowDialog();                    
                }
                else
                {
                    throw new ArgumentException("La información suministrada no coincide con ningún registro.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnFactura_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                SIGEEA_FacAsociado factura = dc.SIGEEA_FacAsociados.First(c => c.PK_Id_FacAsociado == Convert.ToInt32(txbFactura.Text));

                if(solicitud == true && (factura == null || factura.Estado_FacAsociado == false || factura.Incompleta_FacAsociado == true))
                    throw new ArgumentException("La factura digitada no existe, está pendiente de finalización o ya fue cancelada.");


                if (solicitud == false && (factura == null || factura.Incompleta_FacAsociado == false || factura.Estado_FacAsociado == false))
                    throw new ArgumentException("La factura digitada no existe o su entrega ya fue completada y/o cancelada.");


                if (solicitud == false)
                {
                    wnwCompletaEntrega ventana = new wnwCompletaEntrega(factura.PK_Id_FacAsociado);
                    ventana.ShowDialog();
                }
                else
                {
                    wnwFacturasPendientesPago ventana = new wnwFacturasPendientesPago(factura.PK_Id_FacAsociado);
                    ventana.ShowDialog();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
