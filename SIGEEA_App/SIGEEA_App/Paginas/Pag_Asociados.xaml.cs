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
using SIGEEA_App.Ventanas_Modales.Asociados;
using SIGEEA_App.Ventanas_Modales.Direcciones;
using SIGEEA_App.User_Controls;

namespace SIGEEA_App.Paginas
{
    /// <summary>
    /// Interaction logic for Pag_Asociados.xaml
    /// </summary>
    public partial class Pag_Asociados : Page
    {
        public Pag_Asociados()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarPersona ventanaRegistro = new wnwRegistrarPersona(pTipoPersona:"Asociado", pAsociado:null, pEmpleado:null, pCliente:null);
            ventanaRegistro.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            wnwIdentificar ventana = new wnwIdentificar("EditarAsociado");
            ventana.ShowDialog();
        }

        private void btnDireccion_Click(object sender, RoutedEventArgs e)
        {
            wnwIdentificar ventana = new wnwIdentificar("Direccion");
            ventana.ShowDialog();
        }
    }
}
