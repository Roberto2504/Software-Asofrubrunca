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
using SIGEEA_App.Ventanas_Modales.Fincas;
using System.Collections.ObjectModel;
using System.IO;
using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_App.Custom_Controls;
namespace SIGEEA_App.Paginas
{
    /// <summary>
    /// Interaction logic for Pag_Fincas.xaml
    /// </summary>
    public partial class Pag_Fincas : Page
    {
        public Pag_Fincas()
        {
            InitializeComponent();
        }


        private void btnAgregarFinca_Click(object sender, RoutedEventArgs e)
        {
            wnwBuscadorAsociados nuevo = new wnwBuscadorAsociados("Registrar");
            nuevo.Show();
        }

        private void btnEditarFinca_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminaroActivarFinca_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
