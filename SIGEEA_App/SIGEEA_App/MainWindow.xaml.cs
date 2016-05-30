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
using SIGEEA_App.Ventanas_Modales.Productos;
using MahApps.Metro.Controls.Dialogs;
using SIGEEA_App.Ventanas_Modales.Asociados;
using SIGEEA_App.Ventanas_Modales.Clientes;
using SIGEEA_App.Ventanas_Modales.Empleados;
using MahApps.Metro.Controls;
using SIGEEA_App.Ventanas_Modales.Fincas;
using SIGEEA_App.Ventanas_Modales.Insumos;
using SIGEEA_App.Ventanas_Modales.Personas;
using SIGEEA_App.Ventanas_Modales.Puestos;
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

            //this.Loaded += MainWindow_Loaded;
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
                    ComboBox nuevo = new ComboBox();

                    nuevo.FontFamily = new FontFamily("Cooper Black");
                    nuevo.FontSize = 28;
                    nuevo.Foreground = new SolidColorBrush(Colors.White);
                    nuevo.Background = new LinearGradientBrush(Colors.Green, Colors.MidnightBlue, 90);
                    nuevo.Width = 220;
                    nuevo.Height = 60;
                    List<string> lista = new List<string>();
                    lista.Add(Modulo.Nombre_Modulo);
                    foreach (string submodulo in segMant.ObtenerSubModulos(Modulo.PK_Id_Modulo))
                    {
                        lista.Add(submodulo);
                    }
                    nuevo.ItemsSource = lista;
                    nuevo.SelectedIndex = 0;
                    nuevo.SelectionChanged += Nuevo_SelectionChanged;

                    wrpPrincipal.Children.Add(nuevo);
                    entro = false;
                }
                else
                {
                    entro = false;
                }






            }
        }

        private void Nuevo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;


            switch (cmb.SelectedItem.ToString())
            {

                case "Registrar nuevo asociado":
                    wnwRegistrarPersona ventanaRegistro = new wnwRegistrarPersona(pTipoPersona: "Asociado", pAsociado: null, pEmpleado: null, pCliente: null);
                    ventanaRegistro.Show();
                    break;

                case "Editar asociado existente":
                    wnwVistaAsociados ventanaEdicion = new wnwVistaAsociados();
                    ventanaEdicion.ShowDialog();
                    break;

                case "Agregar/Editar dirección de asociados":
                    wnwIdentificar ventanaDireccion = new wnwIdentificar("Direccion");
                    ventanaDireccion.ShowDialog();
                    break;

                case "Registrar cuota":
                    wnwRegistrarCuota venRegistraCuota = new wnwRegistrarCuota(0);
                    venRegistraCuota.ShowDialog();
                    break;

                case "Administrar pagos de cuotas":
                    DataClasses1DataContext dc = new DataClasses1DataContext();
                    if (dc.SIGEEA_spObtenerCuotas().ToList().Count > 0)
                    {
                        wnwCuotas ventana2 = new wnwCuotas();
                        ventana2.ShowDialog();
                    }
                    else MessageBox.Show("No hay cuotas registradas actualmente.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                case "Reuniones":
                    wnwAsambleas ventana = new wnwAsambleas();
                    ventana.ShowDialog();
                    break;

                case "Registrar nuevo cliente":
                    wnwRegistrarPersona venRegistroCliente = new wnwRegistrarPersona(pTipoPersona: "Cliente", pAsociado: null, pEmpleado: null, pCliente: null);
                    venRegistroCliente.Show();
                    break;

                case "Editar cliente":
                    wnwBuscadorCliente venEditarCliente = new wnwBuscadorCliente("Editar");
                    venEditarCliente.Show();
                    break;

                case "Generar factura":
                    wnwBuscadorCliente venPedidoCliente = new wnwBuscadorCliente("Pedido");
                    venPedidoCliente.Show();
                    break;

                case "Realizar abono a factura":
                    wnwBuscadorCliente venAbonoCredito = new wnwBuscadorCliente("Abono");
                    venAbonoCredito.Show();
                    break;

                case "Entrega de producto":
                    wnwIdentificar ventanaEntrega = new wnwIdentificar("Entrega");
                    ventanaEntrega.ShowDialog();
                    break;

                case "Gestionar facturas incompletas":
                    wnwOpcionesFacturaProducto ventanaIncompletas = new wnwOpcionesFacturaProducto(false);
                    ventanaIncompletas.ShowDialog();
                    break;

                case "Gestionar facturas pendientes":
                    wnwOpcionesFacturaProducto ventanaPendientes = new wnwOpcionesFacturaProducto(true);
                    ventanaPendientes.ShowDialog();
                    break;

                case "Gestiona facturas incompletas":
                    wnwBuscadorCliente nuevo = new wnwBuscadorCliente("Facturas Incompletas");
                    nuevo.Show();
                    break;

                case "Registrar nuevo empleado":
                    wnwRegistrarPersona ventanaRegistroEmp = new wnwRegistrarPersona(pTipoPersona: "Empleado", pAsociado: null, pEmpleado: null, pCliente: null);
                    ventanaRegistroEmp.Show();
                    break;

                case "Editar empleado existente":
                    wnwIdentificarEmpleado ventanaIdentifica = new wnwIdentificarEmpleado("Editar");
                    ventanaIdentifica.ShowDialog();
                    break;

                case "Agregar/Editar dirección de empleados":
                    wnwIdentificarEmpleado ventanaDir = new wnwIdentificarEmpleado("Direccion");
                    ventanaDir.ShowDialog();
                    break;

                case "Gestionar puestos":
                    wnwPuestos ventanaPuestos = new wnwPuestos();
                    ventanaPuestos.ShowDialog();
                    break;

                case "Registro de horas ":
                    wnwRegistrarHorasLaboradas ventanaHor = new wnwRegistrarHorasLaboradas();
                    ventanaHor.ShowDialog();
                    break;

                case "Realizar pagos":
                    wnwIdentificarEmpleado ventanaPagos = new wnwIdentificarEmpleado("Pagos");
                    ventanaPagos.ShowDialog();
                    break;

                case "Agregar finca":
                    wnwBuscadorAsociados venAgregarFinca = new wnwBuscadorAsociados("Registrar");
                    venAgregarFinca.Show();
                    break;

                case "Editar finca":
                    break;

                case "Registrar nuevo producto":
                    wnwRegistrarProducto ventanaProd = new wnwRegistrarProducto();
                    ventanaProd.Show();
                    break;

                case "Compra/Venta del producto":
                    wnwPreciosProducto ventanaPrecios = new wnwPreciosProducto();
                    ventanaPrecios.Show();
                    break;

                case "Agregar insumo":
                    wnwRegistrarInsumo venAgregarInsumo = new wnwRegistrarInsumo();
                    venAgregarInsumo.Show();
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
            cmb.SelectedIndex = 0;

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
