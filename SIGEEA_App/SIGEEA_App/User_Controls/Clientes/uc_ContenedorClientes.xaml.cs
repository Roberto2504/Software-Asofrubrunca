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
using System.Collections.ObjectModel;
using System.IO;
using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_App.User_Controls.Clientes;
using SIGEEA_App.Ventanas_Modales.Personas;
using SIGEEA_App.Ventanas_Modales.Clientes;

namespace SIGEEA_App.User_Controls.Clientes
{
    /// <summary>
    /// Interaction logic for uc_ContenedorClientes.xaml
    /// </summary>
    public partial class uc_ContenedorClientes : UserControl
    {
        public uc_ContenedorClientes(string pOpcion)
        {
            InitializeComponent();
            opcion = pOpcion;
            FiltrarClientes("");
        }
        #region Variables
        string opcion = "";
        string nomCed = null;
        ClienteMantenimiento MantCliente = new ClienteMantenimiento();

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
                List<SIGEEA_spListarClienteResult> listar = clienMant.ListarClientes(CedNombre);
                foreach (SIGEEA_spListarClienteResult lista in listar)
                {

                    uc_Cliente nuevo = new uc_Cliente();
                    nuevo.NombreCompletoCliente = lista.nombreCompleto;
                    if(lista.CedParticular_Persona == null)
                    {
                        nuevo.CedulaCliente = lista.CedJuridica_Persona;
                    }else
                    {
                        nuevo.CedulaCliente = lista.CedParticular_Persona;
                    }
                    
                    nuevo.CatCliente = lista.Nombre_TipCatCliente;
                    if (lista.Estado_Cliente == true) { nuevo.EstadoCliente = "ACTIVO"; } else { nuevo.EstadoCliente = "INACTIVO"; }

                    nuevo.btnOpcion.Tag = lista.PK_Id_Cliente;
               

                    if (opcion == "Pedido")
                    {
                        nuevo.btnOpcion.Content = "Hacer Pedido";
                    }
                    else if (opcion == "Editar")
                    {

                        nuevo.btnOpcion.Content = "Editar";
                    }
                    else if (opcion == "Ver")
                    {
                        nuevo.btnOpcion.Content = "Ver Facturas";
                    }
                    else if (opcion == "Abono")
                    {
                        nuevo.btnOpcion.Content = "Hacer Abono";
                    }
                    else if (opcion == "ReporteVentas")
                    {
                        nuevo.btnOpcion.Content = "Ver reporte";
                    }
                    //else if (opcion == "Eliminar o Activar")
                    //{
                    //    if (nuevo.EstadoCliente == "ACTIVO") { nuevo.btnOpcion.Visibility = Visibility.Visible; nuevo.btnOpcion2.Visibility = Visibility.Hidden; }
                    //    else { nuevo.btnOpcion.Visibility = Visibility.Hidden; nuevo.btnOpcion2.Visibility = Visibility.Visible; }
                    //    nuevo.btnOpcion.Content = "Eliminar";
                    //    nuevo.btnOpcion2.Content = "Activar";

                    //}
                    nuevo.btnOpcion.Click += BtnOpcion_Click;
                    //nuevo.btnOpcion2.Click += BtnOpcion2_Click;

                    stpClientes.Children.Add(nuevo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.ToString(), "error", MessageBoxButton.OK);

            }

        }



        //private void BtnOpcion2_Click(object sender, RoutedEventArgs e)
        //{
        //    var boton = (Button)sender;
        //    if (opcion == "Pedido")
        //    {

        //        // nuevo.btnOpcion2.Content = "Ver Credito";

        //    }
        //    else if (opcion == "Editar")
        //    {


        //        //nuevo.btnOpcion2.Content = "Credito";

        //    }

        //    else if (opcion == "Eliminar o Activar")
        //    {


        //        if (MessageBox.Show("¿Realmente activar este Cliente?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
        //        {
        //            ClienteMantenimiento mant = new ClienteMantenimiento();
        //            mant.ActivarCliente(Convert.ToInt32(boton.Tag));//eliminar

        //        }
        //        actualiza();
        //    }


        //}

        private void BtnOpcion_Click(object sender, RoutedEventArgs e)
        {
            var boton = (Button)sender;
            if (opcion == "Pedido")
            {
                wnwRealizarPedidoCliente nuevoPedido = new wnwRealizarPedidoCliente(pPk_Id_Cliente: Convert.ToInt32(boton.Tag));
                nuevoPedido.ShowDialog();

            }
            else if (opcion == "Editar")
            {

                wnwRegistrarPersona ventana = new wnwRegistrarPersona("Cliente", pAsociado: null, pEmpleado: null, pCliente: MantCliente.ObtenerCliente(Convert.ToInt32(boton.Tag)));
                ventana.ShowDialog();//editar
            }
            else if (opcion == "Ver")
            {
                wnwFacturasCliente nueva = new wnwFacturasCliente(Tipo: "Por cliente", IdCliente: Convert.ToInt32(boton.Tag), IdFactura: 0);
                nueva.ShowDialog();

            }
            else if (opcion == "Abono")
            {
                //nuevo.btnOpcion.Content = "Hacer Abono";
            }
            else if (opcion == "ReporteVentas")
            {
                wnwReporteVentasCliente nuevaVentana = new wnwReporteVentasCliente(Convert.ToInt32(boton.Tag));
                nuevaVentana.ShowDialog();
            }
            else if (opcion == "Eliminar o Activar")
            {
                if (MessageBox.Show("¿Realmente eliminar este Cliente?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ClienteMantenimiento mant = new ClienteMantenimiento();
                    mant.EliminarCliente(Convert.ToInt32(boton.Tag));//eliminar

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
