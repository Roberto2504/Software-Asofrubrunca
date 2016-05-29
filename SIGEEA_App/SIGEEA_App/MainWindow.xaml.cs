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
using SIGEEA_App.Custom_Controls;
using MahApps.Metro.Controls;
using SIGEEA_BO;
using SIGEEA_BL.Seguridad;
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
            CargarPantalla();

        }
        SeguridadMantenimiento segMant = new SeguridadMantenimiento();
        List<SIGEEA_spListarSubModulosResult> listaSubModulos = new List<SIGEEA_spListarSubModulosResult>();
        List<SIGEEA_spListarModulosResult> listaModulos = new List<SIGEEA_spListarModulosResult>();
        int primera = 0;
        bool entro = false;
        public void CargarPantalla()
        {

            lbUsuarioActual.Content = UsuarioGlobal.InfoUsuario.NomUsuario.ToString();

            foreach (SIGEEA_spListarModulosResult Modulo in UsuarioGlobal.Modulos)
            {

                foreach (SIGEEA_spListarModulosResult incluir in listaModulos)
                {
                    if (incluir.PK_Id_Modulo == Modulo.PK_Id_Modulo)
                    {
                        entro = true;
                    }
                }
                listaModulos.Add(Modulo);
                if (entro == false || primera == 0)
                {
                    primera++;
                    DropDownButton nuevo = new DropDownButton();
                    nuevo.Content = Modulo.Nombre_Modulo;
                    nuevo.FontFamily = new FontFamily("Cooper Black");
                    nuevo.FontSize = 20;
                    nuevo.Foreground = new SolidColorBrush(Colors.White);
                    nuevo.Background = new LinearGradientBrush(Colors.DarkSlateGray, Colors.MidnightBlue, 90);
                    nuevo.Width = 150;

                    nuevo.ItemsSource = segMant.ObtenerSubModulos(Modulo.PK_Id_Modulo);
                    
                    nuevo.Click += Nuevo_Click;
                    wrpPrincipal.Children.Add(nuevo);
                    entro = false;
                }
                else
                {
                    entro = false;
                }






            }
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            DropDownButton cmb = (DropDownButton)sender;
           
            switch (cmb.Content.ToString())
            {

                case "Registrar nuevo asociado":
                    MessageBox.Show("hola");
                    break;

                case "Editar asociado existente":
                    break;

                case "Agregar/Editar dirección de asociados":
                    break;

                case "Registrar cuota":
                    break;

                case "Administrar pagos de cuotas":
                    break;

                case "Reuniones":
                    break;

                case "Registrar nuevo cliente":
                    break;

                case "Editar cliente":
                    break;

                case "Generar factura":
                    break;

                case "Realizar abono a factura":
                    break;

                case "Entrega de producto":
                    break;

                case "Gestionar facturas incompletas":
                    break;

                case "Gestionar facturas pendientes":
                    break;

                case "Gestiona facturas incompletas":
                    break;

                case "Registrar nuevo empleado":
                    break;

                case "Editar empleado existente":
                    break;

                case "Agregar/Editar dirección de empleados":
                    break;

                case "Gestionar puestos":
                    break;

                case "Registro de horas ":
                    break;

                case "Realizar pagos":
                    break;

                case "Agregar finca":
                    break;

                case "Editar finca":
                    break;

                case "Registrar nuevo producto":
                    break;

                case "Compra/Venta del producto":
                    break;

                case "Agregar insumo":
                    break;

                case "Editar insumo":
                    break;

                case "Compra de insumo":
                    break;

                case "Pedir insumo":
                    break;

                default:
                    break;
            }
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
