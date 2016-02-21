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

using SIGEEA_App.Ventanas_Modales.Personas;

namespace SIGEEA_App.Paginas
{
    /// <summary>
    /// Interaction logic for Pag_General.xaml
    /// </summary>
    public partial class Pag_General : Page
    {
        public Pag_General()
        {
            InitializeComponent();
        }

        private void btnContactos_Click(object sender, RoutedEventArgs e)
        {
            wnwIdentificarPersona ventana = new wnwIdentificarPersona("Contacto");
            ventana.ShowDialog();
        }

        private void btnDirecciones_Click(object sender, RoutedEventArgs e)
        {
            wnwIdentificarPersona ventana = new wnwIdentificarPersona("Direccion");
            ventana.ShowDialog();
        }
    }
}
