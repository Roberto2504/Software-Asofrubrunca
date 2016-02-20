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
        #region Variables

        string nomInsumo = null;
        #endregion
        private void ccPedidoInsumo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ccCompraInsumo_Click(object sender, RoutedEventArgs e)
        {

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

        
        private void FiltrarInsumos(string nomInsumo)
        {
            try
            {

                InsumoMantenimiento mantInsumo = new InsumoMantenimiento();
                dtgrdInsumo.ItemsSource = mantInsumo.ListarInsumos(txbBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.ToString(), "error", MessageBoxButton.OK);

            }

        }
        public void actualiza()
        {
            if (txbBuscar.Text != null)
            {

                nomInsumo = txbBuscar.Text;
                FiltrarInsumos(nomInsumo);
            }

        }

        private void txbBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualiza();
        }
    }
}
