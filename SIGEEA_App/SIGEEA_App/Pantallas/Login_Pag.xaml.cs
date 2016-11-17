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
    public partial class Login_Pag : Window
    {
        public Login_Pag()
        {
            InitializeComponent();
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
                MainWindow ventana = new MainWindow();
                txbUsuario.Text = String.Empty;
                psbClave.Password = string.Empty;
                ventana.ShowDialog();

            }
            
        }
    }
}
