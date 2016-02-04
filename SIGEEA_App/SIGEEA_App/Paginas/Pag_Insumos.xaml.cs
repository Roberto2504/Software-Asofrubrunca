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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIGEEA_BL;
using SIGEEA_App.Ventanas_Modales;

namespace SIGEEA_App.Paginas
{
    /// <summary>
    /// Interaction logic for Pag_Insumos.xaml
    /// </summary>
    public partial class Pag_Insumos : Page
    {
        public Pag_Insumos()
        {
            InitializeComponent();
        }

        private void ccPedidoInsumo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ccCompraInsumo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            InsumoMantenimiento mantInsumo = new InsumoMantenimiento();
            dtgrdInsumo.ItemsSource = mantInsumo.ListarInsumos(txtBuscar.Text);
        }

        private void ccEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ccEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarInsumo_Click(object sender, RoutedEventArgs e)
        {
            Ventanas_Modales.Insumos.wnwRegistrarInsumo ventanaInsumo = new Ventanas_Modales.Insumos.wnwRegistrarInsumo();
            ventanaInsumo.Show();
        }
    }
}
