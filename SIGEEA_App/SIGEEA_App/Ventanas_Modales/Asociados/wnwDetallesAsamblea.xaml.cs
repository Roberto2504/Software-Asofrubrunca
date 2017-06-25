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
using SIGEEA_App.User_Controls.Asociados;

namespace SIGEEA_App.Ventanas_Modales.Asociados
{
    /// <summary>
    /// Interaction logic for wnwDetallesAsamblea.xaml
    /// </summary>
    public partial class wnwDetallesAsamblea : MetroWindow
    {
        public wnwDetallesAsamblea(int pAsamblea)
        {
            InitializeComponent();
            CargaInformacion(pAsamblea);
        }

        private void CargaInformacion(int pAsamblea)
        {
            try
            {
                SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
                List<SIGEEA_spObtenerListadoAsistenciaResult> lista = dc.SIGEEA_spObtenerListadoAsistencia(pAsamblea).ToList();
                bool color = true;
                foreach (SIGEEA_spObtenerListadoAsistenciaResult a in lista)
                {
                    uc_AsociadoAsamblea asociado = new uc_AsociadoAsamblea(a.PK_Id_AsiAsamblea, a.Nombre, a.Estado_AsiAsamblea, a.Cedula);
                    asociado.Color(color);
                    stpContenedor.Children.Add(asociado);
                    color = !color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            List<SIGEEA_spObtenerListadoAsistenciaResult> lista = new List<SIGEEA_spObtenerListadoAsistenciaResult>();
            AsociadoMantenimiento asociado = new AsociadoMantenimiento();
            foreach (uc_AsociadoAsamblea a in stpContenedor.Children)
            {
                SIGEEA_spObtenerListadoAsistenciaResult item = new SIGEEA_spObtenerListadoAsistenciaResult();
                item.PK_Id_AsiAsamblea = a.AsociadoAsambleaId;
                item.Cedula = a.AsociadoAsambleaCedula;
                item.Estado_AsiAsamblea = a.ObtenerEstado();
                item.Nombre = a.AsociadoAsambleaNombre;
                lista.Add(item);
            }
            asociado.ActualizarDetalleAsamblea(lista);
        }
    }
}
