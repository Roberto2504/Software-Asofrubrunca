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
using SIGEEA_App.Ventanas_Modales.Empleados;
using SIGEEA_App.Ventanas_Modales.Puestos;

namespace SIGEEA_App.Paginas
{
    /// <summary>
    /// Interaction logic for Pag_Empleados.xaml
    /// </summary>
    public partial class Pag_Empleados : Page
    {
        public Pag_Empleados()
        {
            InitializeComponent();
        }

        private void btnRegistrarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarPersona ventana = new wnwRegistrarPersona(pTipoPersona: "Empleado", pAsociado: null, pEmpleado: null, pCliente: null);
            ventana.Show();
        }

        private void btnEditarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            wnwIdentificarEmpleado ventana = new wnwIdentificarEmpleado("Editar");
            ventana.ShowDialog();
        }

        private void btnDireccion_Click(object sender, RoutedEventArgs e)
        {
            wnwIdentificarEmpleado ventana = new wnwIdentificarEmpleado("Direccion");
            ventana.ShowDialog();
        }

        private void btnPuestos_Click(object sender, RoutedEventArgs e)
        {
            wnwPuestos ventana = new wnwPuestos();
            ventana.ShowDialog();
        }

        private void btnHoras_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarHorasLaboradas ventana = new wnwRegistrarHorasLaboradas();
            ventana.ShowDialog();
        }

        private void btnPagos_Click(object sender, RoutedEventArgs e)
        {
            wnwIdentificarEmpleado ventana = new wnwIdentificarEmpleado("Pagos");
            ventana.ShowDialog();
        }
    }
}
