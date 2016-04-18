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
using SIGEEA_App.User_Controls.Asociados;

using SIGEEA_App.Ventanas_Modales.Asociados;

namespace SIGEEA_App.User_Controls.Fincas
{
    /// <summary>
    /// Interaction logic for uc_ContenedorAsociados.xaml
    /// </summary>
    public partial class uc_ContenedorAsociados : UserControl
    {
        public uc_ContenedorAsociados(string pOpcion)
        {
            InitializeComponent();
            opcion = pOpcion;
        }
        #region Variables
        string opcion = "";
        string CodNom= null;
        AsociadoMantenimiento MantAsociado = new AsociadoMantenimiento();

        #endregion
        private void searchIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualiza();
        }
        private void FiltrarClientes(string CodNombre)
        {
            try
            {
                ClienteMantenimiento clienMant = new ClienteMantenimiento();
                stpClientes.Children.Clear();
                List<SIGEEA_spListarAsociadoResult> listar = MantAsociado.ListarAsociados(CodNombre);
                foreach (SIGEEA_spListarAsociadoResult lista in listar)
                {

                    uc_Asociado nuevo = new uc_Asociado();
                    nuevo.NombreCompletoAsociado = lista.Nombre;
                    nuevo.Codigo = lista.Codigo_Asociado;
                    
                    if (lista.Estado_Asociado == true) { nuevo.EstadoAsociado = "ACTIVO"; } else { nuevo.EstadoAsociado = "INACTIVO"; }
                    nuevo.idPersona = lista.PK_Id_Persona.ToString();
                    nuevo.IdAsociado = lista.PK_Id_Asociado.ToString();
                    nuevo.btnOpcion.Tag = lista.PK_Id_Asociado;
                    nuevo.btnOpcion2.Tag = lista.PK_Id_Asociado;

                    if (opcion == "Registrar")
                    {
                        nuevo.btnOpcion.Content = "Hacer Pedido";
                        nuevo.btnOpcion2.Content = "Ver Credito";

                    }
                    
                    else if (opcion == "Editar")
                    {
                        nuevo.btnOpcion.Content = "Ver Cliente";
                        nuevo.btnOpcion2.Content = "Ver Credito";

                    }
                    
                    else if (opcion == "Eliminar o Activar")
                    {
                        if (nuevo.EstadoAsociado == "ACTIVO") { nuevo.btnOpcion.Visibility = Visibility.Visible; nuevo.btnOpcion2.Visibility = Visibility.Hidden; }
                        else { nuevo.btnOpcion.Visibility = Visibility.Hidden; nuevo.btnOpcion2.Visibility = Visibility.Visible; }
                        nuevo.btnOpcion.Content = "Eliminar";
                        nuevo.btnOpcion2.Content = "Activar";

                    }
                    nuevo.btnOpcion.Click += BtnOpcion_Click;
                    nuevo.btnOpcion2.Click += BtnOpcion2_Click;

                    stpClientes.Children.Add(nuevo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.ToString(), "error", MessageBoxButton.OK);

            }

        }

        private void BtnOpcion2_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnOpcion_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void actualiza()
        {
            if (searchIn.Text != null)
            {

                CodNom = searchIn.Text;
                FiltrarClientes(CodNom);
            }

        }
    }
}
