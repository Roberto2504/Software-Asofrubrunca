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
using SIGEEA_BO;

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
            wnwRegistrarPersona ventanaRegistro = new wnwRegistrarPersona(pTipoPersona: "Asociado", pAsociado: null, pEmpleado: null, pCliente: null);
            ventanaRegistro.Show();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            wnwVistaAsociados ventana = new wnwVistaAsociados();
            ventana.ShowDialog();
        }

        private void btnDireccion_Click(object sender, RoutedEventArgs e)
        {
            wnwIdentificar ventana = new wnwIdentificar("Direccion");
            ventana.ShowDialog();
        }

        private void btnCuota_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarCuota ventana = new wnwRegistrarCuota(0);
            ventana.ShowDialog();
        }

        private void btnAdministrarCuotas_Click(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            if (dc.SIGEEA_spObtenerCuotas().ToList().Count > 0)
            {
                wnwCuotas ventana = new wnwCuotas();
                ventana.ShowDialog();
            }
        }

        private void btnEntrega_Click(object sender, RoutedEventArgs e)
        {
            wnwIdentificar ventana = new wnwIdentificar("Entrega");
            ventana.ShowDialog();
        }

        private void btnPendientes_Click(object sender, RoutedEventArgs e)
        {
            wnwOpcionesFacturaProducto ventana = new wnwOpcionesFacturaProducto(true);
            ventana.ShowDialog();
        }

        private void btnIncompletas_Click(object sender, RoutedEventArgs e)
        {
            wnwOpcionesFacturaProducto ventana = new wnwOpcionesFacturaProducto(false);
            ventana.ShowDialog();
        }

        private void btnAsambleas_Click(object sender, RoutedEventArgs e)
        {
            wnwAsambleas ventana = new wnwAsambleas();
            ventana.ShowDialog();
        }
    }
}
