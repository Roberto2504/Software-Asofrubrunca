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
    /// Interaction logic for wnwBuscadorFincas.xaml
    /// </summary>
    public partial class wnwBuscadorFincas : MetroWindow
    {
        public wnwBuscadorFincas(string opcion)
        {
            InitializeComponent();
            uc_ContenedorFincas nuevo = new uc_ContenedorFincas(pOpcion: opcion);
            grdContenedorFincas.Children.Add(nuevo);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
