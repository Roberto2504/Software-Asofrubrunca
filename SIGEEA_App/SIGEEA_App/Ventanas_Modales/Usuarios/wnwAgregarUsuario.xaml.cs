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
    /// Interaction logic for wnwAgregarUsuario.xaml
    /// </summary>
    public partial class wnwAgregarUsuario : MetroWindow
    {
        public wnwAgregarUsuario(string tipo, SIGEEA_spListarUsuarioResult pUsuario)
        {
            InitializeComponent();
            CargarRoles();
            ptipo = tipo;
            if (tipo == "Editar")
            {
                txtTipo.Text = "Editar";
                ptipo = tipo;
                txtClave.Password = pUsuario.Clave_Usuario;
                txtNomUsuario.Text = pUsuario.Nombre_Usuario;
                primerNombre = pUsuario.Nombre_Usuario;
                txtBusEmpleado.Text = pUsuario.NombreCompleto;
                cbxRoles.SelectedValue = pUsuario.Nombre_Rol;
                Usuario = pUsuario;
                pkPrimerEmpleado = pUsuario.PK_Id_Empleado;
            }
        }
        string ptipo, primerNombre;
        int pkPrimerEmpleado;
        SIGEEA_spListarUsuarioResult Usuario = new SIGEEA_spListarUsuarioResult();
        SeguridadMantenimiento SegMant = new SeguridadMantenimiento();
        List<SIGEEA_spListarEmpleadosResult> listaEmpleado = new List<SIGEEA_spListarEmpleadosResult>();
        List<SIGEEA_Rol> ListaRoles = new List<SIGEEA_Rol>();
        SIGEEA_Rol Rol = new SIGEEA_Rol();
        SIGEEA_spListarEmpleadosResult Empleado = new SIGEEA_spListarEmpleadosResult();
        private void txtBusEmpleado_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBusEmpleado.Text != "")
            {
                listaEmpleado.Clear();
                cbxEmpleados.Items.Clear();
                listaEmpleado = SegMant.ListaEmpleados(txtBusEmpleado.Text);
                foreach (SIGEEA_spListarEmpleadosResult emp in listaEmpleado)
                {
                    ListBoxItem nuevo = new ListBoxItem();
                    nuevo.DataContext = emp;
                    nuevo.Content = emp.NombreCompleto;
                    cbxEmpleados.Items.Add(nuevo);
                }
                cbxEmpleados.SelectedIndex = 0;
            }
        }
        public void CargarRoles()
        {
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
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomUsuario.Text != "" && txtClave.Password != "" && txtConfClave.Password != "" && cbxEmpleados.SelectedIndex != -1 && cbxRoles.SelectedIndex != -1)
            {
                if(ptipo == "Editar")
                {
                    if (SegMant.validaNombreUsuario(txtNomUsuario.Text) == false|| txtNomUsuario.Text==primerNombre)
                    {
                        if (txtClave.Password == txtConfClave.Password)
                        {
                            if (SegMant.validaEmpleadoUsuario(Empleado.PK_Id_Empleado) == false || pkPrimerEmpleado == Empleado.PK_Id_Empleado )
                            {
                                SIGEEA_Usuario nuevo = new SIGEEA_Usuario();
                                nuevo.Nombre_Usuario = txtNomUsuario.Text;
                                nuevo.FK_Id_Rol = Rol.PK_Id_Rol;
                                nuevo.Clave_Usuario = txtClave.Password;
                                nuevo.FK_Id_Empleado = Empleado.PK_Id_Empleado;
                                nuevo.PK_Id_Usuario = Usuario.PK_Id_Usuario;
                                SegMant.EditarUsuario(nuevo);
                                MessageBox.Show("Se ha editado el usuario correctamente", "Alerta");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("El empleado ya poseé un usuario asociado", "Alerta");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas no coinciden.", "Alerta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un usuario con este nombre.", "Alerta");
                    }
                }
                else
                {
                    if (SegMant.validaNombreUsuario(txtNomUsuario.Text) == false)
                    {
                        if (txtClave.Password == txtConfClave.Password)
                        {
                            if (SegMant.validaEmpleadoUsuario(Empleado.PK_Id_Empleado) == false)
                            {
                                SIGEEA_Usuario nuevo = new SIGEEA_Usuario();
                                nuevo.Nombre_Usuario = txtNomUsuario.Text;
                                nuevo.FK_Id_Rol = Rol.PK_Id_Rol;
                                nuevo.Clave_Usuario = txtClave.Password;
                                nuevo.FK_Id_Empleado = Empleado.PK_Id_Empleado;
                                nuevo.RutFondo_Usuario = "C:/Users/rober/Documents/GitHub/Imagenes/4.jpg";
                                SegMant.AgregarUsuario(nuevo);
                                MessageBox.Show("Se ha agregado el usuario correctamente", "Alerta");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("El empleado ya poseé un usuario asociado", "Alerta");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas no coinciden.", "Alerta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un usuario con este nombre.", "Alerta");
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Alerta");
            }
        }

        private void cbxRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem nuevo = cbxRoles.SelectedValue as ListBoxItem;
            Rol = nuevo.DataContext as SIGEEA_Rol;
        }

        private void cbxEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbxEmpleados.SelectedItem != null) {

                ListBoxItem nuevo = cbxEmpleados.SelectedValue as ListBoxItem;
                Empleado = nuevo.DataContext as SIGEEA_spListarEmpleadosResult;
            }
        }
    }
}
