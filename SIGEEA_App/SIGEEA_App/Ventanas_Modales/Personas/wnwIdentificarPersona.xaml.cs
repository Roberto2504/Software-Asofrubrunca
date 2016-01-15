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

namespace SIGEEA_App.Ventanas_Modales.Personas
{
    /// <summary>
    /// Interaction logic for wnwIdentificarPersona.xaml
    /// </summary>
    public partial class wnwIdentificarPersona : MetroWindow
    {
        public wnwIdentificarPersona()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, RoutedEventArgs e)
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
    }
}
