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
            EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();
            if (empleado.AutenticaEmpleado(txbCedula.Text) != null)
            {
                if (solicitud == "Editar")
                {

                    wnwRegistrarPersona ventana = new wnwRegistrarPersona("Empleado", pAsociado: null, pEmpleado: empleado.AutenticaEmpleado(txbCedula.Text), pCliente: null);
                    ventana.ShowDialog();
                    this.Close();
                }
                else if (solicitud == "Direccion")
                {
                    wnwDirecciones ventana = new wnwDirecciones(txbCedula.Text, "Empleado", pkFinca: 0);
                    ventana.ShowDialog();
                    this.Close();
                }
                else if (solicitud == "Pagos")
                {
                    if (empleado.ListarPagosEmpleados(txbCedula.Text).Count != 0)
                    {
                        wnwPagoEmpleados ventana = new wnwPagoEmpleados(txbCedula.Text);
                        ventana.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Este empleado no posee ningún registro pendiente de pago.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            else
            {
                MessageBox.Show("Los datos ingresados no coinciden con los registros", "SIGEEA", MessageBoxButton.OK);
            }
        }
    }
}
