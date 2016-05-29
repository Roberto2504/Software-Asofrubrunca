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
using SIGEEA_App.Ventanas_Modales.Productos;

namespace SIGEEA_App.Ventanas_Modales.Asociados
{
    /// <summary>
    /// Interaction logic for wnwIdentificar.xaml
    /// </summary>
    public partial class wnwIdentificar : MetroWindow
    {
        string solicitud;
        public wnwIdentificar(string tipoSolicitud)
        {
            InitializeComponent();
            solicitud = tipoSolicitud;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (solicitud == "EditarAsociado")
            {
                AsociadoMantenimiento Asociado = new AsociadoMantenimiento();
                if (Asociado.AutenticaAsociado(txbInformacion.Text) != null)
                {
                    wnwRegistrarPersona ventana = new wnwRegistrarPersona(pTipoPersona: "Asociado", pAsociado: Asociado.AutenticaAsociado(txbInformacion.Text), pEmpleado: null, pCliente: null);
                    ventana.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Los datos ingresados no coinciden con ningún registro.", "SIGEEA", MessageBoxButton.OK);
                }
            }
            else if(solicitud == "Direccion")
            {
                AsociadoMantenimiento Asociado = new AsociadoMantenimiento();
                if (Asociado.AutenticaAsociado(txbInformacion.Text) != null)
                {
                    wnwDirecciones ventana = new wnwDirecciones(txbInformacion.Text, "Asociado", pkFinca: 0);
                    ventana.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Los datos ingresados no coinciden con ningún registro.", "SIGEEA", MessageBoxButton.OK);
                }
            }
            else if (solicitud == "Entrega")
            {
                AsociadoMantenimiento Asociado = new AsociadoMantenimiento();
                Asociado = new AsociadoMantenimiento();
                DataClasses1DataContext dc = new DataClasses1DataContext();
                if (Asociado.AutenticaAsociado(txbInformacion.Text) != null)
                {
                    wnwEntregaProducto ventana = new wnwEntregaProducto(dc.SIGEEA_spObtenerAsociado(txbInformacion.Text).First());
                    ventana.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
