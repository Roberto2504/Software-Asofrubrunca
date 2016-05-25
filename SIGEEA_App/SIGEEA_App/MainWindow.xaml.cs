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

namespace SIGEEA_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            btnSalir.Click += BtnSalir_Click;
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tiAsociados.GotFocus += TiAsociados_GotFocus;
            tiEmpleados.GotFocus += TiEmpleados_GotFocus;
            tiProductos.GotFocus += TiProductos_GotFocus;
            tiClientes.GotFocus += TiClientes_GotFocus;
            tiFincas.GotFocus += TiFincas_GotFocus;
            tiInsumos.GotFocus += TiInsumos_GotFocus;
            tiGeneral.GotFocus += TiGeneral_GotFocus;

            frmAsociados.Navigate(new Uri("/Paginas/Pag_Asociados.xaml", UriKind.RelativeOrAbsolute));
            frmEmpleados.Navigate(new Uri("/Paginas/Pag_Empleados.xaml", UriKind.RelativeOrAbsolute));
            frmProductos.Navigate(new Uri("/Paginas/Pag_Productos.xaml", UriKind.RelativeOrAbsolute));
            frmClietnes.Navigate(new Uri("/Paginas/Pag_Clientes.xaml", UriKind.RelativeOrAbsolute));
            frmFincas.Navigate(new Uri("/Paginas/Pag_Fincas.xaml", UriKind.RelativeOrAbsolute));
            frmInsumos.Navigate(new Uri("/Paginas/Pag_Insumos.xaml", UriKind.RelativeOrAbsolute));
            frmGeneral.Navigate(new Uri("/Paginas/Pag_General.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TiGeneral_GotFocus(object sender, RoutedEventArgs e)
        {
            frmProductos.Refresh();
            frmEmpleados.Refresh();
            frmClietnes.Refresh();
            frmAsociados.Refresh();
            frmFincas.Refresh();
            frmInsumos.Refresh();
        }

        private void TiInsumos_GotFocus(object sender, RoutedEventArgs e)
        {
            frmProductos.Refresh();
            frmEmpleados.Refresh();
            frmClietnes.Refresh();
            frmAsociados.Refresh();
            frmFincas.Refresh();
            frmGeneral.Refresh();
        }

        private void TiFincas_GotFocus(object sender, RoutedEventArgs e)
        {
            frmProductos.Refresh();
            frmEmpleados.Refresh();
            frmClietnes.Refresh();
            frmInsumos.Refresh();
            frmAsociados.Refresh();
            frmGeneral.Refresh();
        }

        private void TiClientes_GotFocus(object sender, RoutedEventArgs e)
        {
            frmAsociados.Refresh();
            frmProductos.Refresh();
            frmEmpleados.Refresh();
            frmInsumos.Refresh();
            frmFincas.Refresh();
            frmGeneral.Refresh();
        }

        private void TiProductos_GotFocus(object sender, RoutedEventArgs e)
        {
            frmAsociados.Refresh();
            frmEmpleados.Refresh();
            frmClietnes.Refresh();
            frmInsumos.Refresh();
            frmFincas.Refresh();
            frmGeneral.Refresh();
        }

        private void TiEmpleados_GotFocus(object sender, RoutedEventArgs e)
        {
            frmAsociados.Refresh();
            frmProductos.Refresh();
            frmClietnes.Refresh();
            frmInsumos.Refresh();
            frmFincas.Refresh();
            frmGeneral.Refresh();
        }

        private void TiAsociados_GotFocus(object sender, RoutedEventArgs e)
        {
            frmProductos.Refresh();
            frmEmpleados.Refresh();
            frmClietnes.Refresh();
            frmInsumos.Refresh();
            frmFincas.Refresh();
            frmGeneral.Refresh();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSalir_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
