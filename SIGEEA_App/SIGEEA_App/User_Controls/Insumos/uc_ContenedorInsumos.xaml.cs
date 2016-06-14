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
using SIGEEA_App.Ventanas_Modales.Insumos;
using SIGEEA_App.User_Controls.Insumos;
namespace SIGEEA_App.User_Controls.Insumos
{
    /// <summary>
    /// Interaction logic for uc_ContenedorInsumos.xaml
    /// </summary>
    public partial class uc_ContenedorInsumos : UserControl
    {
        public uc_ContenedorInsumos(string pOpcion)
        {
            InitializeComponent();
            opcion = pOpcion;
        }
        #region Variables
        string opcion = "";
        string nomCed = null;
        InsumoMantenimiento MantInsumo= new InsumoMantenimiento();

        #endregion
        private void searchIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualiza();
        }
        private void FiltrarClientes(string CedNombre)
        {
            try
            {
                ClienteMantenimiento clienMant = new ClienteMantenimiento();
                stpClientes.Children.Clear();
                List<SIGEEA_spListarInsumosResult> listar = MantInsumo.ListarInsumos(CedNombre);
                foreach (SIGEEA_spListarInsumosResult lista in listar)
                {

                    uc_Insumo nuevo = new uc_Insumo();
                    nuevo.NombreInsumo = lista.Nombre_Insumo;
                    nuevo.Descripcion = lista.Descripcion_Insumo;
                    nuevo.CanInsumo = lista.Cantidad_InvInsumo.ToString();
                    nuevo.UniMedidaInsumo = lista.Nombre_UniMedida;
                    if (lista.Estado_Insumo == true) { nuevo.EstadoInsumo = "ACTIVO"; } else { nuevo.EstadoInsumo = "INACTIVO"; }
                    nuevo.IdInsumo = lista.PK_Id_Insumo.ToString();
                    nuevo.btnOpcion.Tag = lista.PK_Id_Insumo;
                    nuevo.btnOpcion2.Tag = lista.PK_Id_Insumo;

                    if (opcion == "Pedido")
                    {
                        nuevo.btnOpcion.Content = "Hacer Pedido";
                        

                    }
                    else if (opcion == "Editar")
                    {

                        nuevo.btnOpcion.Content = "Editar";
                        nuevo.btnOpcion2.Visibility = Visibility.Hidden;

                    }
                    else if (opcion == "Pedido")
                    {
                        nuevo.btnOpcion.Content = "Hacer pedido";
                        nuevo.btnOpcion2.Visibility = Visibility.Hidden;

                    }
                    else if (opcion == "Compra")
                    {
                        nuevo.btnOpcion.Content = "Comprar Insumo";
                        nuevo.btnOpcion2.Visibility = Visibility.Hidden;

                    }
                    else if (opcion == "Eliminar o Activar")
                    {
                        if (nuevo.EstadoInsumo == "ACTIVO") { nuevo.btnOpcion.Visibility = Visibility.Visible; nuevo.btnOpcion2.Visibility = Visibility.Hidden; }
                        else { nuevo.btnOpcion.Visibility = Visibility.Hidden; nuevo.btnOpcion2.Visibility = Visibility.Visible; }
                        nuevo.btnOpcion.Content = "Eliminar";
                        nuevo.btnOpcion2.Content = "Activar";

                    }
                    nuevo.btnOpcion.Click += BtnOpcion_Click; ;
                    nuevo.btnOpcion2.Click += BtnOpcion2_Click; ;

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
            var boton = (Button)sender;
           
            if (opcion == "Editar")
            {

                wnwRegistrarInsumo nuevo = new wnwRegistrarInsumo("Editar", Convert.ToInt32(boton.Tag));
                nuevo.ShowDialog();

            }
            else if (opcion == "Pedido")
            {
                wnwPedidoInsumo pedido = new wnwPedidoInsumo();
                pedido.ShowDialog();

            }
            else if (opcion == "Compra")
            {
                ;

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
