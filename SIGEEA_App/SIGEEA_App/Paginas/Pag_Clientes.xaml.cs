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
using SIGEEA_App.Ventanas_Modales.Personas;
using System.Collections.ObjectModel;
using System.IO;
using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_App.Custom_Controls;



namespace SIGEEA_App.Paginas
{
    /// <summary>
    /// Interaction logic for Pag_Clientes.xaml
    /// </summary>
    public partial class Pag_Clientes : Page
    {
        public Pag_Clientes()
        {
            InitializeComponent();
        }
        #region Variables
        
        string nomCed = null;
        ClienteMantenimiento MantCliente = new ClienteMantenimiento();

        SIGEEA_spListarClienteResult cliSeleccionado = new SIGEEA_spListarClienteResult();
        #endregion

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarPersona ventana = new wnwRegistrarPersona(pTipoPersona: "Cliente", pAsociado: null, pEmpleado: null, pCliente: null);
            ventana.Show();
        }

        private void FiltrarClientes(string CedNombre)
        {
            try
            {
             
                ClienteMantenimiento clienMant = new ClienteMantenimiento();
                dataGrid.ItemsSource = clienMant.ListarClientes(CedNombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.ToString(), "error", MessageBoxButton.OK);

            }

        }
        public void actualiza()
        {
            if (txtBuscar.Text != null)
            {
              
                nomCed = txtBuscar.Text;
                FiltrarClientes(nomCed);

            }
           
        }

        private void ccEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ccEliminar_Click(object sender, RoutedEventArgs e)
        {
            ClienteMantenimiento mant = new ClienteMantenimiento();
            mant.EliminarCliente(cliSeleccionado.PK_Id_Cliente);
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cliSeleccionado = dataGrid.SelectedItem as SIGEEA_spListarClienteResult;
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualiza();
        }
    }
}
