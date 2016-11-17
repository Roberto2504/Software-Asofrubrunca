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
using SIGEEA_App.User_Controls.Clientes;
using SIGEEA_BL;
namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwCantidadProductoPedido.xaml
    /// </summary>
    public partial class wnwCantidadProductoPedido : MetroWindow
    {
        public wnwCantidadProductoPedido(string pTipoProceso, uc_Producto pProducto, uc_DetProducto pDetProducto)
        {
            InitializeComponent();
            if (pTipoProceso == "Agregar")
            {
                cantidad = pProducto.canInvProducto;
                precio = pProducto.preProducto;
                tipoProceso = pTipoProceso;
                tag = pProducto.Tag.ToString();
                calidad = pProducto.calTipProducto;
            }
            else {
                cantidad = pDetProducto.canInvProducto;
                moneda = pDetProducto.Moneda;
                precio = pDetProducto.preProducto;
                tipoProceso = pTipoProceso;
                tag = pDetProducto.Tag.ToString();
                calidad = pDetProducto.calTipProducto;
            }

            cargarDatos(pTipoProceso, pProducto, pDetProducto);
            ucDescuento.NUDTextBox.TextChanged += NUDTextBox_TextChanged;
            ucPedido.NUDTextBox.TextChanged += NUDTextBox_TextChanged1;
            
        }
        public string SepararMiles(double Cantidad)
        {
            return Cantidad.ToString("N2");
        }
        private void NUDTextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (tipoProceso == "Agregar")
            {
                cantidad = ((Convert.ToDouble(canAnterior)) - (Convert.ToDouble(ucPedido.NUDTextBox.Text))).ToString();
            }
            preBru = (((Convert.ToDouble(ucPedido.NUDTextBox.Text)) * (Convert.ToDouble(precio)))).ToString();
            txbTotal.Text = string.Concat(moneda, SepararMiles(Math.Round(Convert.ToDouble(preBru), 2)));
            preNet = ((Convert.ToDouble(preBru)) - (((Convert.ToDouble(ucPedido.NUDTextBox.Text) * Convert.ToDouble(precio)) * Convert.ToDouble(ucDescuento.NUDTextBox.Text)) / 100)).ToString();
            txbNuevoPrecio.Text = string.Concat(moneda, SepararMiles(Math.Round(Convert.ToDouble(preNet), 2))); 
        }

        private void NUDTextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            
                cantidad = ((Convert.ToDouble(canAnterior)) - (Convert.ToDouble(ucPedido.NUDTextBox.Text))).ToString();
            txbCantidad.Text = string.Concat(cantidad, uniMedida);
            preBru = (((Convert.ToDouble(ucPedido.NUDTextBox.Text)) * (Convert.ToDouble(precio)))).ToString();
            txbTotal.Text = string.Concat(moneda, SepararMiles(Math.Round(Convert.ToDouble(preBru), 2)));
            preNet = ((Convert.ToDouble(preBru)) - (((Convert.ToDouble(ucPedido.NUDTextBox.Text) * Convert.ToDouble(precio)) * Convert.ToDouble(ucDescuento.NUDTextBox.Text)) / 100)).ToString();
            txbNuevoPrecio.Text = string.Concat(moneda, SepararMiles(Math.Round(Convert.ToDouble(preNet), 2)));
        }

        private void NUDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbNuevoPrecio.Text =   string.Concat(moneda, SepararMiles(Math.Round(Convert.ToDouble((((Convert.ToDouble(ucPedido.NUDTextBox.Text) * Convert.ToDouble(precio))) - (((Convert.ToDouble(ucPedido.NUDTextBox.Text) * Convert.ToDouble(precio)) * Convert.ToDouble(ucDescuento.NUDTextBox.Text)) / 100)).ToString()), 2)));
        }

        uc_Producto proModifica = new uc_Producto();
        string cantidad;
        string canAnterior;
        string moneda;
        string precio;
        string preNac;
        string preExt;
        string preNet;
        string preBru;
        string uniMedida;
        string tipoProceso;
        string tag;
        string calidad;
        public void cargarDatos(string TipoProceso, uc_Producto Producto, uc_DetProducto DetProdcuto)
        {
            if (TipoProceso == "Agregar")
            {
                txbCantidad.Text = string.Concat(Producto.canInvProducto, Producto.UniMedida);
                cantidad = Producto.canInvProducto;
                canAnterior = Producto.canInvProducto;
                uniMedida = Producto.UniMedida;
                txbPrecio.Text = string.Concat(Producto.Moneda, SepararMiles(Math.Round(Convert.ToDouble(Producto.preProducto), 2))); 
                precio = Producto.preProducto;
                txbNombre.Text = Producto.nomTipProducto;
                txbTipo.Text = TipoProceso;
                txbId.Text = Producto.IdTipProducto;
                moneda = Producto.Moneda;
                preNac = Producto.preNacProducto;
                preExt = Producto.preExtProducto;
                tag = Producto.Tag.ToString();
            }
            else
            {

                txbCantidad.Text = string.Concat(DetProdcuto.canDisProducto, DetProdcuto.UniMedida);
                txbPrecio.Text = string.Concat(DetProdcuto.Moneda, SepararMiles(Math.Round(Convert.ToDouble(DetProdcuto.preProducto), 2)));
                txbNombre.Text = DetProdcuto.nomTipProducto;
                txbTipo.Text = TipoProceso;
                uniMedida = DetProdcuto.UniMedida;
                canAnterior = (Convert.ToDouble(DetProdcuto.canDisProducto) + Convert.ToDouble(DetProdcuto.canInvProducto)).ToString();
                cantidad = DetProdcuto.canDisProducto;
                precio = DetProdcuto.preProducto;
                txbId.Text = DetProdcuto.IdTipProducto;
               // txbCantidad.Text = DetProdcuto.canDisProducto;
                preBru = DetProdcuto.preBruProducto;
                preNet = DetProdcuto.preNetProducto;
                txbTotal.Text = SepararMiles(Math.Round(Convert.ToDouble(DetProdcuto.preBruProducto), 2));
                txbNuevoPrecio.Text = SepararMiles(Math.Round(Convert.ToDouble(DetProdcuto.preNetProducto), 2));  
                ucPedido.NUDTextBox.Text = DetProdcuto.canInvProducto;
                ucDescuento.NUDTextBox.Text = DetProdcuto.desProducto;
                moneda = DetProdcuto.Moneda;
                preNac = DetProdcuto.preNacProducto;
                preExt = DetProdcuto.preExtProducto;
                tag = DetProdcuto.Tag.ToString();
            }

        }



        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ClienteMantenimiento clientMant = new ClienteMantenimiento();
            clientMant.SumarInventario(Convert.ToInt32(txbId.Text), (Convert.ToDouble(cantidad) + Convert.ToDouble(ucPedido.NUDTextBox.Text)));
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (txbCantidad.Text != "")
            {
                if (Convert.ToDouble(ucPedido.NUDTextBox.Text) > Convert.ToDouble(canAnterior))
                { MessageBox.Show("El pedido exede la cantidad Disponible"); }
                else if (Convert.ToDouble(ucPedido.NUDTextBox.Text) <= 0)
                { MessageBox.Show("El pedido es menor o igual a 0"); }
                else {
                    MessageBoxResult m = MessageBox.Show("Es la cantidad correcta? " + ucPedido.NUDTextBox.Text, "Mensaje de Confirmación", MessageBoxButton.YesNo);
                    if (m == MessageBoxResult.Yes)
                    {

                        uc_DetProducto nuevoDet = new uc_DetProducto();

                        nuevoDet.preBruProducto = preBru;
                        nuevoDet.nomTipProducto = txbNombre.Text;
                        nuevoDet.IdTipProducto = txbId.Text;
                        nuevoDet.Moneda = moneda;
                        nuevoDet.canInvProducto = ucPedido.NUDTextBox.Text;
                        nuevoDet.desProducto = ucDescuento.NUDTextBox.Text;

                        nuevoDet.preNetProducto = preNet;
                        nuevoDet.preNacProducto = preNac;
                        nuevoDet.preExtProducto = preExt;
                        nuevoDet.Tag = tag;
                        nuevoDet.UniMedida = uniMedida;
                        nuevoDet.preProducto = precio;
                        nuevoDet.calTipProducto = calidad;
                        nuevoDet.canDisProducto = cantidad;
                        ((wnwRealizarPedidoCliente)this.Owner).CargarPedido(nuevoDet);
                        this.Close();
                    }

                }
            }
            else MessageBox.Show("No ha ingresado la cantidad");
        }



        private void uc_ControlNumericoGrande_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
                cantidad = ((Convert.ToDouble(canAnterior)) - (Convert.ToDouble(ucPedido.NUDTextBox.Text))).ToString();
            
            
            txbCantidad.Text = string.Concat(cantidad, uniMedida);
            preBru = (Math.Round(((Convert.ToDouble(ucPedido.NUDTextBox.Text)) * (Convert.ToDouble(precio))),2)).ToString();
            txbTotal.Text = string.Concat(moneda, SepararMiles(Math.Round(Convert.ToDouble(preBru), 2)));
            preNet = (Math.Round(((Convert.ToDouble(ucPedido.NUDTextBox.Text) * Convert.ToDouble(precio))) - (((Convert.ToDouble(ucPedido.NUDTextBox.Text) * Convert.ToDouble(precio)) * Convert.ToDouble(ucDescuento.NUDTextBox.Text)) / 100),2)).ToString();
            txbNuevoPrecio.Text = string.Concat(moneda, SepararMiles(Math.Round(Convert.ToDouble(preNet), 2)));

        }

        private void ucDescuento_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            preBru = (Math.Round(((Convert.ToDouble(ucPedido.NUDTextBox.Text)) * (Convert.ToDouble(precio))),2)).ToString();
            preNet = (Math.Round(((Convert.ToDouble(ucPedido.NUDTextBox.Text) * Convert.ToDouble(precio))) - (((Convert.ToDouble(ucPedido.NUDTextBox.Text) * Convert.ToDouble(precio)) * Convert.ToDouble(ucDescuento.NUDTextBox.Text)) / 100),2)).ToString();
            txbNuevoPrecio.Text =  string.Concat(moneda, SepararMiles(Math.Round(Convert.ToDouble(preNet), 2)));
        }
    }
}
