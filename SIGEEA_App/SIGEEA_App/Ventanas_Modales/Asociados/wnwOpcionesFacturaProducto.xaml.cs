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
        public wnwOpcionesFacturaProducto()
        {
            InitializeComponent();
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
            }
            else if (cmbOpciones.SelectedIndex == 1)//Listar las de un asociado
            {
                grdAsociado.Visibility = Visibility.Visible;
                grdFacturaUnica.Visibility = Visibility.Collapsed;
                grdTodas.Visibility = Visibility.Collapsed;
            }
            else if (cmbOpciones.SelectedIndex == 2)//A partir de su número de factura
            {
                grdAsociado.Visibility = Visibility.Collapsed;
                grdFacturaUnica.Visibility = Visibility.Visible;
                grdTodas.Visibility = Visibility.Collapsed;
            }
        }

        private void btnTodas_Click(object sender, RoutedEventArgs e)
        {
            wnwFacturasIncompletas ventana = new wnwFacturasIncompletas(null);
            ventana.ShowDialog();
            this.Close();
        }

        private void btnListaFacAsociado_Click(object sender, RoutedEventArgs e)
        {
            AsociadoMantenimiento asociado = new AsociadoMantenimiento();
            if (asociado.AutenticaAsociado(txbAsociado.Text) != null)
            {
                wnwFacturasIncompletas ventana = new wnwFacturasIncompletas(txbAsociado.Text);
                ventana.ShowDialog();
                this.Close();
            }
        }

        private void btnFactura_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
