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
using SIGEEA_BL.Validaciones;

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
            BrushConverter bc = new BrushConverter();
            txbContacto.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            try
            {
                PersonaMantenimiento persona = new PersonaMantenimiento();
                ValidacionesMantenimiento validacion = new ValidacionesMantenimiento();
                if ((String)cmbTipoContacto.SelectedValue == "Correo" && validacion.Validar(txbContacto.Text, 3) == true)
                {
                    persona.AgregarContacto(pPersona: pk_persona, pDato: txbContacto.Text, pTipoContacto: cmbTipoContacto.SelectedValue.ToString());
                    MessageBox.Show("Contacto añadido con éxito.", "SIGEEA", MessageBoxButton.OK);
                    this.Close();
                    wnwContactos ventana = new wnwContactos(pk_persona);
                    ventana.ShowDialog();
                }
                else if (((String)cmbTipoContacto.SelectedValue == "Tel. Movil" ||
                          (String)cmbTipoContacto.SelectedValue == "Tel. Residencia" ||
                          (String)cmbTipoContacto.SelectedValue == "Tel. Trabajo" ||
                          (String)cmbTipoContacto.SelectedValue == "Fax")
                          && validacion.Validar(txbContacto.Text, 2) == true)
                {
                    persona.AgregarContacto(pPersona: pk_persona, pDato: txbContacto.Text, pTipoContacto: cmbTipoContacto.SelectedValue.ToString());
                    MessageBox.Show("Contacto añadido con éxito.", "SIGEEA", MessageBoxButton.OK);
                    this.Close();
                    wnwContactos ventana = new wnwContactos(pk_persona);
                    ventana.ShowDialog();
                }
                else
                {
                    txbContacto.Foreground = (Brush)bc.ConvertFrom("#FFFF0404");
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Error al registrar el contacto: Formatos incompatibles con el sistema.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}
    }
}
