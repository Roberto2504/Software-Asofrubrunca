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

namespace SIGEEA_App.Ventanas_Modales.Fincas
{
    /// <summary>
    /// Interaction logic for wnwOpcionesBusquedaFinca.xaml
    /// </summary>
    public partial class wnwOpcionesBusquedaFinca : Window
    {
        public wnwOpcionesBusquedaFinca(string pOpcion)
        {
            InitializeComponent();
            Opcion = pOpcion;


        }
        string Opcion;
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOpcion_Click(object sender, RoutedEventArgs e)
        {
            wnwBuscadorFincas nueva = new wnwBuscadorFincas(opcion: Opcion);
            nueva.ShowDialog();
            this.Close();
        }

        private void btnOpcion2_Click(object sender, RoutedEventArgs e)
        {
            wnwBuscadorAsociados nueva = new wnwBuscadorAsociados("Editar");
            nueva.ShowDialog();
            this.Close();
        }
    }
}
