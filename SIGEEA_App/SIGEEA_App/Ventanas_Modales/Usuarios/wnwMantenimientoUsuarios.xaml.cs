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
using SIGEEA_BL.Seguridad;
using SIGEEA_BO;
using MahApps.Metro.Controls;
using SIGEEA_App.User_Controls.Usuarios;
namespace SIGEEA_App.Ventanas_Modales.Usuarios
{
    /// <summary>
    /// Interaction logic for wnwMantenimientoUsuarios.xaml
    /// </summary>
    public partial class wnwMantenimientoUsuarios : MetroWindow
    {
        public wnwMantenimientoUsuarios()
        {
            InitializeComponent();
            CargarRoles();
        }
        List<SIGEEA_Rol> ListaRoles = new List<SIGEEA_Rol>();
        SIGEEA_Rol Rol = new SIGEEA_Rol();
        List<SIGEEA_spListarUsuarioResult> ListaUsuario = new List<SIGEEA_spListarUsuarioResult>();
        SIGEEA_spListarUsuarioResult Usuario = new SIGEEA_spListarUsuarioResult();
        SeguridadMantenimiento SegMant = new SeguridadMantenimiento();
        public void CargarRoles()
        {
            cbxRoles.Items.Clear();
            ListaRoles.Clear();
            ListaRoles = SegMant.LisRoles();
            
            foreach (SIGEEA_Rol rol in ListaRoles)
            {
                ListBoxItem nuevo = new ListBoxItem();
                nuevo.DataContext = rol;
                nuevo.Content = rol.Nombre_Rol;
                cbxRoles.Items.Add(nuevo);
            }
            cbxRoles.SelectedIndex = 0;
        }
        public void CargarUsuarios()
        {
            try
            {

                stpUsuarios.Children.Clear();
                ListaUsuario = SegMant.ListarUsuarios(txtBusEmpleado.Text, Rol.PK_Id_Rol);
                foreach (SIGEEA_spListarUsuarioResult usuario in ListaUsuario)
                {
                    uc_Usuario nuevo = new uc_Usuario();
                    nuevo.txtNomEmpleado.Text = usuario.NombreCompleto;
                    nuevo.txtNomUsuario.Text = usuario.Nombre_Usuario;
                    nuevo.txtRol.Text = usuario.Nombre_Rol;
                    nuevo.btnEditar.DataContext = usuario;
                    nuevo.btnEditar.Click += BtnEditar_Click;
                    stpUsuarios.Children.Add(nuevo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.ToString(), "error", MessageBoxButton.OK);

            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Button nuevo = (Button)sender;
            Usuario = nuevo.DataContext as SIGEEA_spListarUsuarioResult;
            wnwAgregarUsuario nuevo1 = new wnwAgregarUsuario(tipo: "Editar", pUsuario: Usuario);
            nuevo1.Closed += Nuevo_Closed;
            nuevo1.Show();

        }

        private void txtBusEmpleado_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarUsuarios();
        }

        private void cbxRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxRoles.SelectedValue != null)
            {
                ListBoxItem nuevo = cbxRoles.SelectedValue as ListBoxItem;
                Rol = nuevo.DataContext as SIGEEA_Rol;
                CargarUsuarios();
            }
            
        }

        private void btnAgregarRol_Click(object sender, RoutedEventArgs e)
        {
            wnwAgregarRol nueva = new wnwAgregarRol(tipo: "Agregar", prol: null);
            nueva.Closed += Nueva_Closed;
            nueva.Show();
        }

        private void Nueva_Closed(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditarRol_Click(object sender, RoutedEventArgs e)
        {
            wnwAgregarRol nueva = new wnwAgregarRol(tipo: "Editar", prol: Rol);
            nueva.Closed += Nueva_Closed;
            nueva.Show();
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            wnwAgregarUsuario nuevo = new wnwAgregarUsuario(tipo: "Agregar", pUsuario: null);
            nuevo.Closed += Nuevo_Closed;
            nuevo.Show();
        }

        private void Nuevo_Closed(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
    }
}
