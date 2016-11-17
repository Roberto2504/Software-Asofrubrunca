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
using SIGEEA_App.Ventanas_Modales.Usuarios;
using SIGEEA_BO;
using SIGEEA_BL.Seguridad;
using Microsoft.Win32;
using System.IO;
using SIGEEA_BL;
using SIGEEA_App.Pantallas;

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
            CargarPantalla();
            CargarMoneda();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri(UsuarioGlobal.InfoUsuario.RutFondo_Usuario, UriKind.RelativeOrAbsolute));
            this.Background = myBrush;


        }
        
        SeguridadMantenimiento segMant = new SeguridadMantenimiento();
        MonedaMantenimiento monMant = new MonedaMantenimiento();
        List<SIGEEA_spListarSubModulosResult> listaSubModulos = new List<SIGEEA_spListarSubModulosResult>();
        List<SIGEEA_Modulo> listaModulos = new List<SIGEEA_Modulo>();
        int primera = 0;
        bool entro = false;

        string venta;
        string compra;
        System.Net.WebClient client = new System.Net.WebClient();
        Stream d;
        StreamReader r;
        string line;
        public void CargarMoneda()
        {
           txtCompra.Text = "₡ " + Math.Round(Convert.ToDouble(monMant.Moneda(1).PreCompra_Moneda), 2).ToString();
           txtVenta.Text = "₡ " + Math.Round(Convert.ToDouble(monMant.Moneda(1).PreVenta_Moneda), 2).ToString();
        }
        private void SincronizarTipoCambio()
        {
            txtVenta.Text = "";
            txtVenta.Text = "";
            compra = "";
            venta = "";
            try
            {
                d = client.OpenRead("https://www.bncr.fi.cr/BNCR/TipoCambio.aspx"); // Accede a la pagina que quieres buscar
                r = new StreamReader(d); // lee la informacion o contenido de la web
                line = r.ReadLine(); // recorre linea x linea la web
                int para = 0;
                int leido = 0;
                bool leer = false;
                while (line != null && leido != 2) // mientras exista contenido
                {
                    // aca realizas tu codigo de verificacion o obtener informacion

                    line = r.ReadLine(); // para seguir leendo las otras lineas de la pagina
                    if (para != 0)
                    {
                        try
                        {
                            for (int i = 0; i < line.Length; i++)
                            {
                                try
                                {
                                    if (line[i] == '>' && line[i + 1] == '5')
                                    {
                                        i++; leer = true;
                                    }
                                }
                                catch { }
                                if (line[i] == '<' && leer == true) { leer = false; leido++; }
                                if (leer == true)
                                {
                                    if (leido == 0)
                                    {
                                        if (line[i] == '.')
                                        {
                                            compra += ",";
                                        }
                                        else
                                        {
                                            compra += line[i];
                                        }

                                    }
                                    else
                                    {
                                        if (line[i] == '.')
                                        {
                                            venta += ",";
                                        }
                                        else
                                        {
                                            venta += line[i];
                                        }

                                    }
                                }

                            }
                        }
                        catch { }

                    }




                    para++;
                }
                monMant.ActualizaPrecio(Convert.ToDouble(venta), Convert.ToDouble(compra));
                txtVenta.Text = "₡ " + Math.Round(Convert.ToDouble(venta), 2).ToString();
                txtCompra.Text = "₡ " + Math.Round(Convert.ToDouble(compra), 2).ToString();
                d.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay conexión a internet");
            }

          
        }


        public void CargarPantalla()
        {
            wrpPrincipal.Children.Clear();
            listaModulos.Clear();
            lbUsuarioActual.Content = UsuarioGlobal.InfoUsuario.NomUsuario.ToString();
            UsuarioGlobal.Modulos.Clear();
            foreach (SIGEEA_spListarSubModulosResult subModulo in segMant.ListarSubModulos(Convert.ToInt32(UsuarioGlobal.InfoUsuario.FK_Id_Permiso)))
            {
                bool entro = false;
                SIGEEA_Modulo nuevoModulo = segMant.ObteneModulos(subModulo.FK_Id_Modulo);
                foreach (SIGEEA_Modulo Modulo1 in UsuarioGlobal.Modulos)
                {
                    if (Modulo1.PK_Id_Modulo == nuevoModulo.PK_Id_Modulo)
                    {
                        entro = true;
                    }
                }
                if (entro == false)
                {
                    UsuarioGlobal.Modulos.Add(nuevoModulo);
                }
            }
            List<SIGEEA_Modulo> ordenada = UsuarioGlobal.Modulos.OrderBy(c => c.Nombre_Modulo).ToList();
                foreach (SIGEEA_Modulo Modulo in ordenada)
            {
                foreach (SIGEEA_Modulo incluir in listaModulos)
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
                    nuevo.FontFamily = new FontFamily("Segoe UI Ligth");
                    nuevo.FontSize = 24;
                    nuevo.Foreground = new SolidColorBrush(Colors.White);
                    nuevo.Background = new LinearGradientBrush(Colors.Transparent, Colors.Gray, 90);
                    nuevo.Width = 180;
                    nuevo.Height = 35;
                    List<string> lista = new List<string>();
                    lista.Add(Modulo.Nombre_Modulo);
                    foreach (SIGEEA_spListaSubModuloPorPermisoResult submodulo in segMant.ListaSubModuloPorPermiso(Convert.ToInt32( UsuarioGlobal.InfoUsuario.FK_Id_Permiso),Modulo.PK_Id_Modulo))
                    {
                        lista.Add(submodulo.Nombre_SubModulo);
                    }
                    nuevo.ItemsSource = lista;
                    nuevo.SelectedIndex = 0;
                    nuevo.SelectionChanged += Nuevo_SelectionChanged;
                    nuevo.MouseUp += Nuevo_MouseUp;
                    wrpPrincipal.Children.Add(nuevo);
                    entro = false;
                }
                else
                {
                    entro = false;
                }
            }
        }

        private void Nuevo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Activate();
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
                    wnwMetodoBusquedaFactura venAbonoCredito = new wnwMetodoBusquedaFactura();
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
                    wnwOpcionesBusquedaFinca venEditarFinca = new wnwOpcionesBusquedaFinca("Editar");
                    venEditarFinca.Show();
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
                    wnwRegistrarInsumo venAgregarInsumo = new wnwRegistrarInsumo(ptipo:"Registrar", ppkInsumo:0);
                    venAgregarInsumo.Show();
                    break;

                case "Editar insumo":
                    wnwBuscadorInsumo editarInsumo = new wnwBuscadorInsumo("Editar");
                    editarInsumo.ShowDialog();
                    break;

                case "Compra de insumo":
                    wmwCompraInsumo compraInsumo = new wmwCompraInsumo();
                    compraInsumo.ShowDialog();
                    break;

                case "Pedir insumo":
                    wnwBuscadorInsumo pedirInsumo = new wnwBuscadorInsumo("Pedido");
                    pedirInsumo.ShowDialog();
                    break;
                case "Permisos y roles":
                    wnwRoles permisosyroles = new wnwRoles();
                    permisosyroles.Closed += Permisosyroles_Closed;
                    permisosyroles.ShowDialog();
                    break;
                case "Registrar usuario":
                    wnwAgregarUsuario nuevoUsuario = new wnwAgregarUsuario(tipo: "Agregar", pUsuario:null);
                    nuevoUsuario.ShowDialog();
                    break;
                

                default:
                    break;
            }
            cmb.SelectedIndex = 0;

        }

        private void Permisosyroles_Closed(object sender, EventArgs e)
        {
            CargarPantalla();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void btnFondo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagenes jpg(*.jpg)|*.jpg";
            if (ofd.ShowDialog() == true)
            {
                using (Stream stream = ofd.OpenFile())
                {
                    ImageBrush myBrush = new ImageBrush();
                    myBrush.ImageSource = new BitmapImage(new Uri(ofd.InitialDirectory + ofd.FileName, UriKind.RelativeOrAbsolute));
                    this.Background = myBrush;
                    segMant.CambiarFondo(ofd.FileName, UsuarioGlobal.InfoUsuario.PK_Id_Usuario);
                }
            }
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            txtVenta.Text = "";
            txtVenta.Text = "";
            
            SincronizarTipoCambio();
        }

        private void lbCerrarSesión_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            //Login_Pag login = new Login_Pag();
            //login.ShowDialog();
            
        }
    }
}
