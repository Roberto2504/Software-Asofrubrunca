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

namespace SIGEEA_App.Ventanas_Modales.Contactos
{
    /// <summary>
    /// Interaction logic for wnwAgregarContacto.xaml
    /// </summary>
    public partial class wnwAgregarContacto : MetroWindow
    {
        int pk_persona;
        public wnwAgregarContacto(int pPersona)
        {
            InitializeComponent();
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<SIGEEA_TipContacto> lista = new List<SIGEEA_TipContacto>();
            lista = dc.SIGEEA_TipContactos.ToList();
            pk_persona = pPersona;

            foreach(SIGEEA_TipContacto tc in lista)
            {
                cmbTipoContacto.Items.Add(tc.Nombre_TipContacto);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonaMantenimiento persona = new PersonaMantenimiento();
                persona.AgregarContacto(pPersona: pk_persona, pDato: txbContacto.Text, pTipoContacto: cmbTipoContacto.SelectedValue.ToString());
                MessageBox.Show("Contacto añadido con éxito.", "SIGEEA", MessageBoxButton.OK);
                this.Close();
                wnwContactos ventana = new wnwContactos(pk_persona);
                ventana.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error al registrar el contacto. Asegúrese de que la información ingresada es correcta.", "SIGEEA", MessageBoxButton.OK);
            }
}
    }
}
