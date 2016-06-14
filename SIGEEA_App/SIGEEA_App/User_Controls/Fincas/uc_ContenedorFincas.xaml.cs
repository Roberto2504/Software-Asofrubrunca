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
using SIGEEA_App.User_Controls.Fincas;
using SIGEEA_App.Ventanas_Modales.Fincas;
namespace SIGEEA_App.User_Controls.Fincas
{
    /// <summary>
    /// Interaction logic for uc_ContenedorFincas.xaml
    /// </summary>
    public partial class uc_ContenedorFincas : UserControl
    {
        public uc_ContenedorFincas(string pOpcion)
        {
            InitializeComponent();
            opcion = pOpcion;
        }
        #region Variables
        string opcion = "";
        string nomCed = null;
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
                stpFincas.Children.Clear();

                List<SIGEEA_spListarFincasResult> listar = MantFinca.ListarInfoFinca(pPkAsociado:0, pCodigo: CodNombre,pNombre: CodNombre);
                foreach (SIGEEA_spListarFincasResult lista in listar)
                {

                    uc_Finca nuevo = new uc_Finca();
                    if(lista.Alquilada_Finca == true)
                    {
                        nuevo.txbAlquilada.Text = "Alquilada";
                    }else
                    nuevo.txbAlquilada.Text = "Propia";
                    nuevo.txbNomCompleto.Text = lista.NombreCompleto;
                    nuevo.txbCodFinca.Text = lista.Codigo_Finca;
                    nuevo.btnOpcion.Tag = lista.PK_Id_Finca;
                    if (opcion == "Editar")
                    {
                        nuevo.btnOpcion.Content = "Editar";

                    }
                    else if (opcion == "Eliminar")
                    {

                        nuevo.btnOpcion.Content = "Eliminar";

                    }
                    else if (opcion == "Ver")
                    {
                        nuevo.btnOpcion.Content = "Ver";

                    }
                    else if (opcion == "Activar")
                    {
                        nuevo.btnOpcion.Content = "Activar";

                    }

                    nuevo.btnOpcion.Click += BtnOpcion_Click; 

                    stpFincas.Children.Add(nuevo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.ToString(), "error", MessageBoxButton.OK);

            }

        }

        private void BtnOpcion_Click(object sender, RoutedEventArgs e)
        {
            var boton = (Button)sender;
            if (opcion == "Editar")
            {
                wnwRegistrarFinca editarFinca = new wnwRegistrarFinca(ptipo:"Editar", pPkAsociado: MantFinca.ObtenerFinca(Convert.ToInt32(boton.Tag)).FK_Id_Asociado, pFinca: MantFinca.ObtenerFinca(Convert.ToInt32(boton.Tag)));
                editarFinca.ShowDialog();

            }
            else if (opcion == "Eliminar")
            {
                if (MessageBox.Show("¿Realmente desea eliminar esta Finca?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    MantFinca.CambiarEstadoFinca(Convert.ToInt32(boton.Tag));
                }
                actualiza();
                
            }
            else if (opcion == "Ver")
            {
                wnwRegistrarFinca editarFinca = new wnwRegistrarFinca(ptipo: "Ver", pPkAsociado: MantFinca.ObtenerFinca(Convert.ToInt32(boton.Tag)).FK_Id_Asociado, pFinca: MantFinca.ObtenerFinca(Convert.ToInt32(boton.Tag)));
                editarFinca.ShowDialog();

            }
            else if (opcion == "Activar")
            {
                if (MessageBox.Show("¿Realmente desea activar esta Finca?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    MantFinca.CambiarEstadoFinca(Convert.ToInt32(boton.Tag));
                }
                actualiza();

            }
        }

        public void actualiza()
        {
            if (searchIn.Text != null)
            {

                nomCed = searchIn.Text;
                FiltrarClientes(nomCed);
            }

        }
    }
}
