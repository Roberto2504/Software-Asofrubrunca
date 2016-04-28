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
using SIGEEA_App.User_Controls;

namespace SIGEEA_App.Ventanas_Modales.Contactos
{
    /// <summary>
    /// Interaction logic for wnwContactos.xaml
    /// </summary>
    public partial class wnwContactos : MetroWindow
    {
        int pk_persona;
        bool color = true;
        public wnwContactos(int pPersona)
        {
            InitializeComponent();
            PersonaMantenimiento persona = new PersonaMantenimiento();
            pk_persona = pPersona;
            List<SIGEEA_spObtenerContactoResult> listaContactos = persona.ListarContactos(pPersona);

            if (listaContactos.Count > 0)
            {
                stpContactos.Visibility = Visibility.Visible;
                txbVacio.Visibility = Visibility.Collapsed;
                foreach (SIGEEA_spObtenerContactoResult c in listaContactos)
                {
                    uc_Contacto contacto = new uc_Contacto();
                    contacto.Info = c.Dato_Contacto;
                    contacto.Color(color);
                    contacto.cambiaImagen("/Imagenes/" + c.Nombre_TipContacto + ".ico");
                    contacto.btnEditar.Click += BtnEditar_Click;
                    contacto.ContactoId = c.PK_Id_Contacto;
                    stpContactos.Children.Add(contacto);
                    color = !color;
                }
            }
            else
            {
                stpContactos.Visibility = Visibility.Collapsed;
                txbVacio.Visibility = Visibility.Visible;
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wnwAgregarContacto ventana = new wnwAgregarContacto(pk_persona, "Insertar", 0);
            ventana.ShowDialog();
            this.Close();
        }
    }
}

