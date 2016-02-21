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
    /// Interaction logic for wnwVistaAsociados.xaml
    /// </summary>
    public partial class wnwVistaAsociados : MetroWindow
    {
        public wnwVistaAsociados()
        {
            InitializeComponent();
        }

        private void txbAsociado_TextChanged(object sender, TextChangedEventArgs e)
        {
            AsociadoMantenimiento asociado = new AsociadoMantenimiento();
            List<SIGEEA_spListarAsociadoResult> lista = asociado.ListarAsociados(txbAsociado.Text);
            stpAsociados.Children.Clear();
            bool color = true;

            foreach (SIGEEA_spListarAsociadoResult a in lista)
            {
                uc_ItemAsociado item = new uc_ItemAsociado();
                item.CedulaAsociado = a.CedParticular_Persona;
                item.NombreAsociado = a.Nombre;
                item.CodigoAsociado = a.Codigo_Asociado;
                item.PersonaId = a.PK_Id_Persona;
                item.AsociadoId = a.PK_Id_Asociado;
                item.Color(color);
                color = !color;
                stpAsociados.Children.Add(item);
            }
        }
    }
}
