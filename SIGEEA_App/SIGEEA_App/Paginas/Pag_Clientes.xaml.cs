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
    /// Interaction logic for Pag_Clientes.xaml
    /// </summary>
    public partial class Pag_Clientes : Page
    {
        public Pag_Clientes()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarPersona ventana = new wnwRegistrarPersona(pTipoPersona: "Cliente", pAsociado: null, pEmpleado: null, pCliente: null);
            ventana.Show();
        }
    }
}
