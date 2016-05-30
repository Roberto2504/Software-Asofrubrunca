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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SIGEEA_BO;

namespace SIGEEA_App.Pantallas
{
    /// <summary>
    /// Interaction logic for Login_Pag.xaml
    /// </summary>
    public partial class Login_Pag : MetroWindow
    {
        public Login_Pag()
        {
            InitializeComponent();
            ShowCloseButton = false;
            btnIngresar.Click += BtnIngresar_Click;
            btnCerrar.Click += BtnCerrar_Click;
        }
        SeguridadMantenimiento segMant = new SeguridadMantenimiento();
        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            

            int Acceso = segMant.AutenticaUsuario(txbUsuario.Text, psbClave.Password.ToString());
            if (Acceso == 0)
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else {

                
               

                UsuarioGlobal.InfoUsuario = segMant.InfoUsuario(Acceso);
                List<SIGEEA_spListarPermisosResult> listaPermisos = segMant.ListarPermisos(UsuarioGlobal.InfoUsuario.FK_Id_Rol);
                int modulo = 0;
                bool entro = false;
                foreach (SIGEEA_spListarPermisosResult permiso in listaPermisos) {
                    UsuarioGlobal.Permisos.Add(permiso);
                   
                    foreach (SIGEEA_spListarSubModulosResult subModulo in segMant.ListarSubModulos(permiso.PK_Id_Permiso))
                    {
                        //UsuarioGlobal.SubModulos.Add(subModulo);
                        
                            foreach (SIGEEA_spListarModulosResult Modulo in segMant.ListasModulos(subModulo.FK_Id_Modulo))
                            {
                            UsuarioGlobal.Modulos.Add(Modulo);
                            
                            
                        }
                            

                        


                    }
               }
                MainWindow ventana = new MainWindow();
               
                ventana.ShowDialog();
                this.Close();
            }
            
        }
    }
}
