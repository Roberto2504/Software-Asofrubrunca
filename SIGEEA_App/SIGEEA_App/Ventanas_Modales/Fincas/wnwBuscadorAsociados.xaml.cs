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
using SIGEEA_App.User_Controls.Fincas;
namespace SIGEEA_App.Ventanas_Modales.Fincas
{
    /// <summary>
    /// Interaction logic for wnwBuscadorAsociados.xaml
    /// </summary>
    public partial class wnwBuscadorAsociados : MetroWindow
    {
        public wnwBuscadorAsociados(string tipo)
        {

            InitializeComponent();
            uc_ContenedorAsociados nuevo = new uc_ContenedorAsociados(pOpcion: tipo);
            grdContenedorAsociados.Children.Add(nuevo);
        }
    }
}
