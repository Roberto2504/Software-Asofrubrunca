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
        string Accion;
        int pk_contacto;
        public wnwAgregarContacto(int pPersona, string pAccion, int pIdContacto)
        {
            InitializeComponent();
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<SIGEEA_TipContacto> lista = new List<SIGEEA_TipContacto>();
            lista = dc.SIGEEA_TipContactos.ToList();
            pk_persona = pPersona;
            Accion = pAccion;

            foreach (SIGEEA_TipContacto tc in lista)
            {
                cmbTipoContacto.Items.Add(tc.Nombre_TipContacto);
            }

            if (pAccion == "Editar" && pIdContacto != 0)
            {
                pk_contacto = pIdContacto;
                txbContacto.Text = dc.SIGEEA_Contactos.First(c => c.PK_Id_Contacto == pIdContacto).Dato_Contacto;
                SIGEEA_Contacto contacto = dc.SIGEEA_Contactos.First(c => c.PK_Id_Contacto == pIdContacto);
                cmbTipoContacto.SelectedItem = dc.SIGEEA_TipContactos.First(c => c.PK_Id_TipContacto == contacto.FK_Id_TipContacto).Nombre_TipContacto;
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
                if ((String)cmbTipoContacto.SelectedValue == "Correo" && validacion.Validar(txbContacto.Text, 2) == true)
                {
                    if (Accion == "Insertar")
                    {
                        persona.AgregarContacto(pPersona: pk_persona, pDato: txbContacto.Text, pTipoContacto: cmbTipoContacto.SelectedValue.ToString());
                        MessageBox.Show("Contacto añadido con éxito.", "SIGEEA", MessageBoxButton.OK);
                    }
                    else if (Accion == "Editar")
                    {
                        SIGEEA_Contacto editarContacto = new SIGEEA_Contacto();
                        editarContacto.PK_Id_Contacto = pk_contacto;
                        editarContacto.Dato_Contacto = txbContacto.Text;
                        editarContacto.FK_Id_Persona = pk_persona;
                        DataClasses1DataContext dc = new DataClasses1DataContext();
                        editarContacto.FK_Id_TipContacto = dc.SIGEEA_TipContactos.First(c => c.Nombre_TipContacto == (String)cmbTipoContacto.SelectedValue).PK_Id_TipContacto;
                        persona.EditarContacto(editarContacto);
                        MessageBox.Show("Los cambios se realizaron con éxito.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    this.Close();
                    wnwContactos ventana = new wnwContactos(pk_persona);
                    ventana.ShowDialog();
                }
                else if (((String)cmbTipoContacto.SelectedValue == "Tel. Movil" ||
                          (String)cmbTipoContacto.SelectedValue == "Tel. Residencia" ||
                          (String)cmbTipoContacto.SelectedValue == "Tel. Trabajo" ||
                          (String)cmbTipoContacto.SelectedValue == "Fax")
                          && validacion.Validar(txbContacto.Text, 1) == true)
                {
                    if (Accion == "Insertar")
                    {
                        persona.AgregarContacto(pPersona: pk_persona, pDato: txbContacto.Text, pTipoContacto: cmbTipoContacto.SelectedValue.ToString());
                        MessageBox.Show("Contacto añadido con éxito.", "SIGEEA", MessageBoxButton.OK);
                    }
                    else if (Accion == "Editar")
                    {
                        SIGEEA_Contacto editarContacto = new SIGEEA_Contacto();
                        editarContacto.PK_Id_Contacto = pk_contacto;
                        editarContacto.Dato_Contacto = txbContacto.Text;
                        editarContacto.FK_Id_Persona = pk_persona;
                        DataClasses1DataContext dc = new DataClasses1DataContext();
                        editarContacto.FK_Id_TipContacto = dc.SIGEEA_TipContactos.First(c => c.Nombre_TipContacto == cmbTipoContacto.SelectedItem.ToString()).PK_Id_TipContacto;
                        persona.EditarContacto(editarContacto);
                        MessageBox.Show("Los cambios se realizaron con éxito.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    this.Close();
                    wnwContactos ventana = new wnwContactos(pk_persona);
                    ventana.ShowDialog();
                }
                else
                {
                    txbContacto.Foreground = (Brush)bc.ConvertFrom("#FFFF0404");
                    throw new ArgumentException("Error al registrar: Formatos incompatibles con el sistema");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
