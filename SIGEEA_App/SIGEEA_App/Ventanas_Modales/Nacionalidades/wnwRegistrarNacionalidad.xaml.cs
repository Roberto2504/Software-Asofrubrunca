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
using SIGEEA_BO;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace SIGEEA_App.Ventanas_Modales.Nacionalidades
{
    /// <summary>
    /// Interaction logic for wnwRegistrarNacionalidad.xaml
    /// </summary>
    public partial class wnwRegistrarNacionalidad : MetroWindow
    {
        public wnwRegistrarNacionalidad()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                SIGEEA_Nacionalidad nuevaNacionalidad = new SIGEEA_Nacionalidad();
                nuevaNacionalidad.Nombre_Nacionalidad = txbNacionalidad.Text;
                dc.SIGEEA_Nacionalidads.InsertOnSubmit(nuevaNacionalidad);
                dc.SubmitChanges();
                MessageBox.Show("Se realizó el registro con éxito.", "SIGEEA", MessageBoxButton.OK);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error al registrar.", "SIGEEA", MessageBoxButton.OK);
            }
        }
    }
}
