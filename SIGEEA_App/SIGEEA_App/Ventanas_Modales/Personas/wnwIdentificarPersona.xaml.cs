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
using SIGEEA_App.Ventanas_Modales.Contactos;
using SIGEEA_App.Ventanas_Modales.Direcciones;

namespace SIGEEA_App.Ventanas_Modales.Personas
{
    /// <summary>
    /// Interaction logic for wnwIdentificarPersona.xaml
    /// </summary>
    public partial class wnwIdentificarPersona : MetroWindow
    {
        string tipoSolicitud;
        public wnwIdentificarPersona(string pTipoSolicitud)
        {
            InitializeComponent();
            tipoSolicitud = pTipoSolicitud;
        }

        private void btnValidar_Click(object sender, RoutedEventArgs e)
        {
            if (tipoSolicitud == "Contacto")
            {
                PersonaMantenimiento persona = new PersonaMantenimiento();
                int pk_persona = persona.AutenticaPersona(txbCedula.Text);
                if (pk_persona != 0)
                {
                    wnwContactos ventana = new wnwContactos(pk_persona);
                    ventana.ShowDialog();
                    this.Close();
                }
            }
            else if (tipoSolicitud == "Direccion")
            {
                EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();
                AsociadoMantenimiento asociado = new AsociadoMantenimiento();

                if (empleado.AutenticaEmpleado(txbCedula.Text) != null) //Es un empleado
                {
                    wnwDirecciones ventana = new wnwDirecciones(txbCedula.Text, "Empleado", pkFinca:0);
                    ventana.ShowDialog();
                    this.Close();
                }
                else if (asociado.AutenticaAsociado(txbCedula.Text) != null) //Es un asociado
                {
                    wnwDirecciones ventana = new wnwDirecciones(txbCedula.Text, "Asociado", pkFinca: 0);
                    ventana.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: el número de cédula digitado no se encuentra registrado.", "SIGEEA", MessageBoxButton.OK);
                }
            }
        }
    }
}
