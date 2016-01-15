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

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

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

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventana = new MainWindow();
            ventana.ShowDialog();
            this.Close();
        }
    }
}
