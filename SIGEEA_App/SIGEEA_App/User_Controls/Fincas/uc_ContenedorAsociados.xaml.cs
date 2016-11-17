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

using SIGEEA_App.Ventanas_Modales.Fincas;

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
        string CodNom = null;
        AsociadoMantenimiento MantAsociado = new AsociadoMantenimiento();
        FincaMantenimiento MantFinca = new FincaMantenimiento();
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

                    if (opcion == "Registrar")
                    {
                        nuevo.btnOpcion.Content = "Registrar Finca";

                    }

                    else if (opcion == "Editar")
                    {
                        nuevo.btnOpcion.Content = "Editar Finca";
                        //nuevo.btnOpcion2.Content = "Ver Fincas";

                    }

                    //else if (opcion == "Eliminar o Activar")
                    //{
                    //    if (nuevo.EstadoAsociado == "ACTIVO") { nuevo.btnOpcion.Visibility = Visibility.Visible; nuevo.btnOpcion2.Visibility = Visibility.Hidden; }
                    //    else { nuevo.btnOpcion.Visibility = Visibility.Hidden; nuevo.btnOpcion2.Visibility = Visibility.Visible; }
                    //    nuevo.btnOpcion.Content = "Eliminar";
                    //    nuevo.btnOpcion2.Content = "Activar";

                    //}
                    nuevo.btnOpcion.Click += BtnOpcion_Click;

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
            var boton = (Button)sender;
            if (opcion == "Eliminar o Activar")
            {


                if (MessageBox.Show("¿Realmente activar este Cliente?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ClienteMantenimiento mant = new ClienteMantenimiento();
                    mant.ActivarCliente(Convert.ToInt32(boton.Tag));//eliminar

                }
                actualiza();
            }
        }

        private void BtnOpcion_Click(object sender, RoutedEventArgs e)
        {
            var boton = (Button)sender;
            if (opcion == "Registrar")
            {
                wnwRegistrarFinca nueva = new wnwRegistrarFinca(opcion,  Convert.ToInt32(boton.Tag), pFinca:null);
                nueva.ShowDialog();


            }
            else if (opcion == "Editar")
            {
                if(MantFinca.ListarInfoFinca(Convert.ToInt32(boton.Tag), pCodigo:"0", pNombre:null).Count > 1)
                {
                    wnwBuscadorFincas nueva = new wnwBuscadorFincas(opcion);
                    nueva.ShowDialog();
                }
                else
                {
                    wnwRegistrarFinca nueva = new wnwRegistrarFinca(opcion, Convert.ToInt32(boton.Tag), pFinca: MantFinca.ObtenerFincaPorIdAsociado(Convert.ToInt32(boton.Tag)));
                    nueva.ShowDialog();
                    
                }
               
            }

            else if (opcion == "Eliminar o Activar")
            {


                if (MessageBox.Show("¿Realmente activar este Cliente?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ClienteMantenimiento mant = new ClienteMantenimiento();
                    mant.ActivarCliente(Convert.ToInt32(boton.Tag));//eliminar

                }
                actualiza();
            }
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
