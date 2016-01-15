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

using SIGEEA_App.Ventanas_Modales.Productos;

namespace SIGEEA_App.Paginas
{
    /// <summary>
    /// Interaction logic for Pag_Productos.xaml
    /// </summary>
    public partial class Pag_Productos : Page
    {
        public Pag_Productos()
        {
            InitializeComponent();
        }

        private void btnTipoProducto_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarProducto ventana = new wnwRegistrarProducto();
            ventana.Show();
        }

        private void btnPrecioCompra_Click(object sender, RoutedEventArgs e)
        {
            wnwPreciosProducto ventana = new wnwPreciosProducto("Compra");
            ventana.Show();
        }

        private void btnPrecioVenta_Click(object sender, RoutedEventArgs e)
        {
            wnwPreciosProducto ventana = new wnwPreciosProducto("Venta");
            ventana.Show();
        }
    }
}
