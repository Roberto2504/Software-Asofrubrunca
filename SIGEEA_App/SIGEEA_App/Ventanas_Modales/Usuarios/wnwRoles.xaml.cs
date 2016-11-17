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
using SIGEEA_App.User_Controls.Usuarios;


namespace SIGEEA_App.Ventanas_Modales.Usuarios
{
    /// <summary>
    /// Interaction logic for wnwRoles.xaml
    /// </summary>
    public partial class wnwRoles : Window
    {
        public wnwRoles()
        {
            InitializeComponent();
            CargarPermisos();
            Cargar();
        }
        SeguridadMantenimiento segMant = new SeguridadMantenimiento();

        List<SIGEEA_Permiso> listaPermiso = new List<SIGEEA_Permiso>();
        SIGEEA_Permiso permiso = new SIGEEA_Permiso();
        List<SIGEEA_SubModulo> listaSubModulos = new List<SIGEEA_SubModulo>();
        SIGEEA_SubModulo subModulo = new SIGEEA_SubModulo();
        List<SIGEEA_Modulo> listaModulo = new List<SIGEEA_Modulo>();
        SIGEEA_Modulo modulo = new SIGEEA_Modulo();
        public void CargarPermisos()
        {
            listaPermiso = segMant.LisPermiso();
            cmbPermisos.Items.Clear();
            foreach (SIGEEA_Permiso per in listaPermiso)
            {
                ListBoxItem nuevo = new ListBoxItem();
                nuevo.DataContext = per;
                nuevo.Content = per.Nombre_Permiso;
                cmbPermisos.Items.Add(nuevo);
            }
            cmbPermisos.SelectedIndex = 0;
        }
        public void Cargar()
        {
            listaModulo = segMant.LisModulos();
            stpModulos.Children.Clear();
            foreach (SIGEEA_Modulo mod in listaModulo)
            {
                uc_Modulos nuevoMod = new uc_Modulos();
                nuevoMod.txtNomModulo.Text = mod.Nombre_Modulo;
                nuevoMod.grdModulo.DataContext = mod;
                nuevoMod.cbxSeleccionado.DataContext = mod;//tengo que preguntar si tiene asignadas para chequearlo o deschequearlo
                listaSubModulos = segMant.LisSubModulos(mod.PK_Id_Modulo);
                foreach (SIGEEA_SubModulo modAux in listaSubModulos)
                {
                    if (segMant.ConsultaPermisoSubModulo(permiso.PK_Id_Permiso, modAux.PK_Id_SubModulo) == true)
                    {
                        nuevoMod.cbxSeleccionado.IsChecked = true;
                        break;
                    }
                }
                nuevoMod.grdModulo.MouseLeftButtonUp += GrdModulo_MouseLeftButtonUp;
                nuevoMod.cbxSeleccionado.Click += CbxSeleccionado_Checked;
                stpModulos.Children.Add(nuevoMod);
            }
            
        }



        private void CbxSeleccionado_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox grdModulo = (CheckBox)sender;
            modulo = grdModulo.DataContext as SIGEEA_Modulo;
            listaSubModulos = segMant.LisSubModulos(modulo.PK_Id_Modulo);
            if (grdModulo.IsChecked == false)
            {
                foreach (SIGEEA_SubModulo mod in listaSubModulos)
                {
                    if (segMant.ConsultaPermisoSubModulo(permiso.PK_Id_Permiso, mod.PK_Id_SubModulo) == true) segMant.EliminarSubModuloAPermiso(permiso.PK_Id_Permiso, mod.PK_Id_SubModulo);
                }
            }else
            {
                
                foreach (SIGEEA_SubModulo mod in listaSubModulos)
                {
                    segMant.AgregarSubModuloAPermiso(permiso.PK_Id_Permiso, mod.PK_Id_SubModulo);
                }
            }
            Cargar();
                CargarSubModulos();
        }

        private void GrdModulo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid grdModulo = (Grid)sender;
            modulo = grdModulo.DataContext as SIGEEA_Modulo;
            CargarSubModulos();


        }
        public void CargarSubModulos()
        {
            listaSubModulos = segMant.LisSubModulos(modulo.PK_Id_Modulo);
            stpSubModulos.Children.Clear();
            foreach (SIGEEA_SubModulo mod in listaSubModulos)
            {
                uc_SubModulos nuevoMod = new uc_SubModulos();
                nuevoMod.txtNomSubModulo.Text = mod.Nombre_SubModulo;
                nuevoMod.grdSubModulo.DataContext = mod;
                nuevoMod.cbxSeleccionado.DataContext = mod;
                nuevoMod.cbxSeleccionado.Click += CbxSeleccionado_Click;
                if (segMant.ConsultaPermisoSubModulo(permiso.PK_Id_Permiso, mod.PK_Id_SubModulo) == true) nuevoMod.cbxSeleccionado.IsChecked = true;
                else nuevoMod.cbxSeleccionado.IsChecked = false;
                nuevoMod.grdSubModulo.MouseLeftButtonUp += GrdSubModulo_MouseLeftButtonUp;
                stpSubModulos.Children.Add(nuevoMod);

            }
        }
        private void CbxSeleccionado_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cmbSubModulo = (CheckBox)sender;
            subModulo = cmbSubModulo.DataContext as SIGEEA_SubModulo;
            if(cmbSubModulo.IsChecked == true)
            {
               
                if (segMant.ConsultaPermisoSubModulo(permiso.PK_Id_Permiso, subModulo.PK_Id_SubModulo) == true)
                {
                    segMant.EliminarSubModuloAPermiso(permiso.PK_Id_Permiso, subModulo.PK_Id_SubModulo);
                }
                else
                {
                    segMant.AgregarSubModuloAPermiso(permiso.PK_Id_Permiso, subModulo.PK_Id_SubModulo);
                }

            }
            else {
                
                if (segMant.ConsultaPermisoSubModulo(permiso.PK_Id_Permiso, subModulo.PK_Id_SubModulo) == true)
                {
                    segMant.EliminarSubModuloAPermiso(permiso.PK_Id_Permiso, subModulo.PK_Id_SubModulo);
                }
                else
                {
                    segMant.AgregarSubModuloAPermiso(permiso.PK_Id_Permiso, subModulo.PK_Id_SubModulo);
                }
            }
            CargarSubModulos();
            Cargar();

        }

        private void GrdSubModulo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    

        private void cmbRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPermisos.SelectedItem != null)
            {
                ListBoxItem nuevo = cmbPermisos.SelectedValue as ListBoxItem;
                permiso = nuevo.DataContext as SIGEEA_Permiso;
                Cargar();
                CargarSubModulos();
            }
        }

        private void btnMantenimiento_Click(object sender, RoutedEventArgs e)
        {
            wnwMantenimientoUsuarios nuevo = new wnwMantenimientoUsuarios();
            nuevo.Closed += Nuevo_Closed;
            nuevo.Show();
        }

        private void Nuevo_Closed(object sender, EventArgs e)
        {
            Cargar();
            CargarPermisos();
        }
    }
}
