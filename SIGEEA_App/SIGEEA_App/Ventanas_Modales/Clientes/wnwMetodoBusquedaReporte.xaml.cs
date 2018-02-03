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

namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwMetodoBusquedaReporte.xaml
    /// </summary>
    public partial class wnwMetodoBusquedaReporte : MetroWindow
    {
        public wnwMetodoBusquedaReporte()
        {
            InitializeComponent();
            cmbOpciones.Items.Add("Todas por rango de fechas");
            cmbOpciones.Items.Add("A partir del número de factura");
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbOpciones.SelectedIndex == 0)
            {
                wnwBuscadorCliente repVentasCliente = new wnwBuscadorCliente("ReporteVentas");
                repVentasCliente.Show();
            }
            if (cmbOpciones.SelectedIndex == 1)
            {
                wnwFacturaCliente venFacturaCliente = new wnwFacturaCliente(pidFactura:0, pTipo:"Reporte");
                venFacturaCliente.Show();
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
