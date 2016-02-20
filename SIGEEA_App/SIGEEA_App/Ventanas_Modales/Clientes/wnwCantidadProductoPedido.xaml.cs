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
using SIGEEA_App.Custom_Controls;
using SIGEEA_App.User_Controls;
using SIGEEA_App.Ventanas_Modales.Clientes;

namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwCantidadProductoPedido.xaml
    /// </summary>
    public partial class wnwCantidadProductoPedido : MetroWindow
    {
        public wnwCantidadProductoPedido(string pTipoProceso, uc_Producto pProducto)
        {
            InitializeComponent();
            cantidad = pProducto.canInvProducto;
            cargarDatos(pTipoProceso, pProducto);
           

        }
        uc_Producto proModifica = new uc_Producto();
        string cantidad;
        public void cargarDatos(string TipoProceso, uc_Producto Producto)
        {
            
            txbNombre.Text = Producto.nomTipProducto;
            txbCantidad.Text =  String.Concat(Producto.canInvProducto.ToString(), Producto.UniMedida.ToString());
            btnGuardar.Tag = Producto.IdTipProducto.ToString();
            txbTipo.Text = TipoProceso.ToString();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            if(Convert.ToInt32(cantidad) < Convert.ToInt32(txbPedido.Text))
            { MessageBox.Show("El pedido exede la cantidad Disponible"); }
            else if (Convert.ToInt32(txbPedido.Text) <= 0 )
            { MessageBox.Show("El pedido es menor o igual a 0"); }
            else { 
                MessageBoxResult m = MessageBox.Show("Es la cantidad correcta? "+txbPedido.Text, "Mensaje de Confirmación", MessageBoxButton.YesNo);
            if (m == MessageBoxResult.Yes)
            {
                proModifica.canInvProducto = txbPedido.Text;
                ((wnwRealizarPedidoCliente)this.Owner).CargarPedido(btnGuardar.Tag.ToString(), txbPedido.Text );
                this.Close();
            }
            
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
