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

using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_App.Ventanas_Modales.Personas;
using SIGEEA_App.Ventanas_Modales.Direcciones;

namespace SIGEEA_App.Ventanas_Modales.Empleados
{
    /// <summary>
    /// Interaction logic for wnwIdentificarEmpleado.xaml
    /// </summary>
    public partial class wnwIdentificarEmpleado : MetroWindow
    {
        string solicitud;
        public wnwIdentificarEmpleado(string tipoSolicitud)
        {
            InitializeComponent();
            solicitud = tipoSolicitud;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (solicitud == "Editar")
            {
                EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();
                if (empleado.AutenticaEmpleado(txbCedula.Text) != null)
                {
                    wnwRegistrarPersona ventana = new wnwRegistrarPersona("Empleado", pAsociado: null, pEmpleado: empleado.AutenticaEmpleado(txbCedula.Text), pCliente: null);
                    ventana.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Los datos ingresados no coinciden con los registros", "SIGEEA", MessageBoxButton.OK);
                }
            }
            else if(solicitud == "Direccion")
            {
                wnwDirecciones ventana = new wnwDirecciones(txbCedula.Text, "Empleado");
                ventana.ShowDialog();
                this.Close();
            }
        }
    }
}
