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
namespace SIGEEA_App.Ventanas_Modales.Usuarios
{
    /// <summary>
    /// Interaction logic for wnwAgregarRol.xaml
    /// </summary>
    public partial class wnwAgregarRol : MetroWindow
    {
        public wnwAgregarRol(string tipo, SIGEEA_Rol prol)
        {
            InitializeComponent();
            CargarPermiso();
            ptipo = tipo;
            if (tipo == "Editar")
            {
                txtTipo.Text = "Editar rol";
                txtNomRol.Text = prol.Nombre_Rol;
                Permiso = segMant.ObtenerPermiso(Convert.ToInt32(prol.FK_Id_Permiso));
                cbxPermiso.SelectedValue = Permiso.Nombre_Permiso;
                Rol = prol;
                primerNombre = Rol.Nombre_Rol;
            }
            
        }
        string ptipo;
        string primerNombre;
        SeguridadMantenimiento segMant = new SeguridadMantenimiento();
        List<SIGEEA_Permiso> listPermisos = new List<SIGEEA_Permiso>();
        SIGEEA_Permiso Permiso = new SIGEEA_Permiso();
        SIGEEA_Rol Rol = new SIGEEA_Rol();
        public void CargarPermiso()
        {
            listPermisos = segMant.LisPermiso();
            foreach (SIGEEA_Permiso rol in listPermisos)
            {
                ListBoxItem nuevo = new ListBoxItem();
                nuevo.DataContext = rol;
                nuevo.Content = rol.Nombre_Permiso;
                cbxPermiso.Items.Add(nuevo);
            }
            cbxPermiso.SelectedIndex = 0;
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(txtNomRol.Text != "")
            {
                if (ptipo == "Editar")
                {
                    if (segMant.ValidaNombreRol(txtNomRol.Text) == false || primerNombre == Rol.Nombre_Rol)
                    {
                        Rol.Nombre_Rol = txtNomRol.Text;
                        Rol.FK_Id_Permiso = Permiso.PK_Id_Permiso;
                        segMant.EditarRol(Rol);
                        MessageBox.Show("Se ha editado correctamente", "Mensaje de información");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un rol con ese nombre", "Alerta");
                    }
                }else
                {
                    if(segMant.ValidaNombreRol(txtNomRol.Text) == false)
                    {
                        Rol.Nombre_Rol = txtNomRol.Text;
                        Rol.FK_Id_Permiso = Permiso.PK_Id_Permiso;
                        segMant.AgregarRol(Rol);
                        MessageBox.Show("Se ha agragado correctamente", "Mensaje de información");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un rol con ese nombre", "Alerta");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Debe ponerle un nombre al rol", "Alerta");
            }

        }

        private void cbxPermiso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem nuevo = cbxPermiso.SelectedValue as ListBoxItem;
            Permiso = nuevo.DataContext as SIGEEA_Permiso;
        }
    }
}
