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
using SIGEEA_App.Custom_Controls;
using SIGEEA_App.Ventanas_Modales.Insumos;
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

        private void btnAgregarInsumo_Click(object sender, RoutedEventArgs e)
        {
            
           
        }

       
       
        
       

        private void btnEditarInsumo_Click(object sender, RoutedEventArgs e)
        {
            wnwBuscadorInsumo nuevo = new wnwBuscadorInsumo("Editar");
            nuevo.Show();
        }

        private void btnEliminaroActivarInsumo_Click(object sender, RoutedEventArgs e)
        {
            wnwBuscadorInsumo nuevo = new wnwBuscadorInsumo("Eliminar o Activar");
            nuevo.Show();
        }

        private void btnComrarInsumo_Click(object sender, RoutedEventArgs e)
        {
            wnwBuscadorInsumo nuevo = new wnwBuscadorInsumo("Comprar");
            nuevo.Show();
        }

        private void btnPedidoInsumo_Click(object sender, RoutedEventArgs e)
        {
            wnwBuscadorInsumo nuevo = new wnwBuscadorInsumo("Pedido");
            nuevo.Show();
        }
    }
}
