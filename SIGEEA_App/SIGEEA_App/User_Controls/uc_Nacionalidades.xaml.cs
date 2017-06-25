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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_App.Ventanas_Modales.Nacionalidades;

namespace SIGEEA_App.User_Controls
{
    /// <summary>
    /// Interaction logic for uc_Nacionalidades.xaml
    /// </summary>
    public partial class uc_Nacionalidades : UserControl
    {
        public uc_Nacionalidades()
        {
            InitializeComponent();
            PersonaMantenimiento persona = new PersonaMantenimiento();
            cmbLista.ItemsSource = persona.ListarNacionalidades();
        }

        public int getNacionalidad()
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_Nacionalidads.First(c => c.Nombre_Nacionalidad == cmbLista.SelectedItem.ToString()).PK_Id_Nacionalidad;
        }

        public void setNacionalidad(string pNacionalidad)
        {
            cmbLista.SelectedItem = pNacionalidad;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarNacionalidad ventana = new wnwRegistrarNacionalidad();
            ventana.ShowDialog();
        }
    }
}
