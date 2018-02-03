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
using SIGEEA_BL;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace SIGEEA_App.Ventanas_Modales.Asociados
{
    /// <summary>
    /// Interaction logic for wnwOpcionesReporteEntrega.xaml
    /// </summary>
    public partial class wnwOpcionesReporteEntrega : Window
    {
        public wnwOpcionesReporteEntrega()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            int indFactura, indAsociado;
            
            if(txbFecInicio.Text.Contains("Fecha de") || txbFecFin.Text.Contains("Fecha de") || (rbtAscEspecifico.IsChecked == true && txbCedulaCodigo.Text == String.Empty))
            {
                MessageBox.Show("Debe completar todos los campos", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (rbtFacTodas.IsChecked == true) indFactura = 0;
                else if (rbtFacIncompletas.IsChecked == true) indFactura = 1;
                else if (rbtFacPendientes.IsChecked == true) indFactura = 2;
                else indFactura = -1;

                if(rbtAscConsolidado.IsChecked == true)
                {
                    wnwReportesAsociado ventana = new wnwReportesAsociado(indFactura, 0, dpFecInicio.Text, dpFecFin.Text);
                    ventana.ShowDialog();
                    this.Close();
                }
                else if(rbtAscEspecifico.IsChecked == true && txbCedulaCodigo.Text != String.Empty)
                {
                    AsociadoMantenimiento asoc = new AsociadoMantenimiento();
                    
                    wnwReportesAsociado ventana = new wnwReportesAsociado(indFactura, 1, dpFecInicio.Text, dpFecFin.Text, asoc.AutenticaAsociado(txbCedulaCodigo.Text).PK_Id_Asociado);
                    ventana.ShowDialog();
                    this.Close();
                }
            }
        }

        private void dpFecFin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txbFecFin.Text = dpFecFin.Text;
        }

        private void dpFecInicio_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txbFecInicio.Text = dpFecInicio.Text;
        }

        private void rbtAscEspecifico_Checked(object sender, RoutedEventArgs e)
        {
            txbCedulaCodigo.Visibility = Visibility.Visible;
        }

        private void rbtAscEspecifico_Unchecked(object sender, RoutedEventArgs e)
        {
            if(txbCedulaCodigo.Visibility == Visibility.Visible)
                txbCedulaCodigo.Visibility = Visibility.Collapsed;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
