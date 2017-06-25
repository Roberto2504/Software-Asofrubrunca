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

namespace SIGEEA_App.User_Controls.Asociados
{
    /// <summary>
    /// Interaction logic for uc_ContenedorFamiliares.xaml
    /// </summary>
    public partial class uc_ContenedorFamiliares : UserControl
    {
        public uc_ContenedorFamiliares()
        {
            InitializeComponent();
        }

        bool color = true;
        int pk_asociado;
        string cedula;
        List<int> editados = new List<int>();

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AsociadoMantenimiento asociado = new AsociadoMantenimiento();
                List<SIGEEA_Familiar> lista = new List<SIGEEA_Familiar>();

                foreach (uc_ItemFamiliar f in stpContenedor.Children)
                {
                    if ((string)f.lblIdFamiliar.Content == "-1")
                    {
                        SIGEEA_Familiar familiar = new SIGEEA_Familiar();
                        familiar.Nombre_Familiar = f.txbNombre.Text;
                        familiar.DesEstudios_Familiar = f.txbDetalles.Text;
                        familiar.Escolaridad_Familiar = f.Escolaridad();
                        familiar.PK_Id_Familiar = Convert.ToInt32(f.lblIdFamiliar.Content);
                        lista.Add(familiar);
                    }
                    else
                    {
                        foreach (int i in editados)
                        {
                            if (f.ObtieneIdFamiliar() == i)
                            {
                                SIGEEA_Familiar familiar = new SIGEEA_Familiar();
                                familiar.Nombre_Familiar = f.txbNombre.Text;
                                familiar.DesEstudios_Familiar = f.txbDetalles.Text;
                                familiar.Escolaridad_Familiar = f.Escolaridad();
                                familiar.PK_Id_Familiar = Convert.ToInt32(f.lblIdFamiliar.Content);
                                lista.Add(familiar);
                            }
                        }
                    }
                }
                asociado.AgregaEditaFamiliares(pk_asociado, lista);
                MessageBox.Show("La información se ha guardado correctamente.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Information);
                //lista.Clear();
                CargaFamiliares(cedula);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: La información no se ha guardado correctamente." + Ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            uc_ItemFamiliar familiar = new uc_ItemFamiliar(null, false);
            stpContenedor.Children.Insert(0,familiar);
        }

        public void CargaFamiliares(string pCedula)
        {
            try
            {
                stpContenedor.Children.Clear();
                AsociadoMantenimiento asociado = new AsociadoMantenimiento();
                List<SIGEEA_spListarFamiliaresResult> lista = asociado.ListarFamiliares(pCedula);
                SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
                SIGEEA_spObtenerAsociadoResult autentica = asociado.AutenticaAsociado(pCedula);
                pk_asociado = autentica.PK_Id_Asociado;
                cedula = autentica.CedParticular_Persona;


                foreach (SIGEEA_spListarFamiliaresResult f in lista)
                {
                    uc_ItemFamiliar familiar = new uc_ItemFamiliar(f, true);
                    familiar.Color(color);
                    familiar.btnEliminar.Click += BtnEliminar_Click;
                    familiar.btnEditar.Click += BtnEditar_Click;
                    color = !color;
                    stpContenedor.Children.Add(familiar);
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: La información se ha guardado correctamente." + Ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Button familiar = (Button)sender;
            editados.Add(Convert.ToInt32(familiar.Tag.ToString()));
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            CargaFamiliares(cedula);
        }
    }
}
