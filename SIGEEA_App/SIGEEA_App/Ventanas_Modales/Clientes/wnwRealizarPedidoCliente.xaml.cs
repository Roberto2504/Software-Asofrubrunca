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
namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwRealizarPedidoCliente.xaml
    /// </summary>
    public partial class wnwRealizarPedidoCliente : MetroWindow
    {
        public wnwRealizarPedidoCliente()
        {
            InitializeComponent();

           

        }
        ProductoMantenimiento producto = new ProductoMantenimiento();
        // private ccProducto productoAnterior = new ccProducto();
        private uc_Producto productoAnterior = new uc_Producto();
        int idFactura = 0;
        bool color = true;

        private void wpProducto_Drop(object sender, DragEventArgs e)
        {

        }

        private void txbBuscarProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarProductos(txbBuscarProducto.Text);
        }
        public void CargarProductos(string nombre)
        {
            try
            {
                List<SIGEEA_spListarProductosResult> lista = new List<SIGEEA_spListarProductosResult>();
                lista = producto.ListarProductos(nombre);
                wpProducto.Children.Clear();

                foreach (SIGEEA_spListarProductosResult result in lista)
                {
                    uc_Producto nueProducto = new uc_Producto();
                    nueProducto.nomTipProducto = result.Nombre_TipProducto;
                    nueProducto.calTipProducto = result.Calidad_TipProducto.ToString();
                    nueProducto.UniMedida = result.Nombre_UniMedida;
                    nueProducto.canInvProducto = result.Cantidad_DetInvProductos.ToString();
                    nueProducto.preNacProducto = result.PreNacional_PreProVenta.ToString();
                    nueProducto.preExtProducto = result.PreExtranjero_PreProVenta.ToString();
                    nueProducto.IdTipProducto = result.PK_Id_TipProducto.ToString();
                    nueProducto.IdMoneda = result.PK_Id_Moneda.ToString();
                    nueProducto.btnAgregarEditar.Tag = Convert.ToInt32(result.PK_Id_TipProducto);
                    nueProducto.btnAgregarEditar.Click += BtnAgregarEditar_Click;
                    nueProducto.Color(color);
                    color = !color;
                    nueProducto.MouseMove += NueProducto_MouseMove;
                    nueProducto.GiveFeedback += NueProducto_GiveFeedback;
                    wpProducto.Children.Add(nueProducto);
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar los productos");
            }
        }

        private void BtnAgregarEditar_Click(object sender, RoutedEventArgs e)
        {
            uc_Producto nuevo = new uc_Producto();
            Button btnId = (Button)sender;
            foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpProducto))
            {
                if (btnId.Tag.ToString() == Producto.IdTipProducto)
                {
                    nuevo = Producto;
                    nuevo.canInvProducto = Producto.canInvProducto;
                    nuevo.nomTipProducto = Producto.nomTipProducto;
                    nuevo.IdTipProducto = Producto.IdTipProducto;
                    nuevo.UniMedida = Producto.UniMedida;
                }

            }
            wnwCantidadProductoPedido nueva = new wnwCantidadProductoPedido("Agregar", nuevo);
            nueva.Owner = this;
            nueva.ShowDialog();
        }

        private void NueProducto_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // Efecto de drag and drop
            // DragOver event handler. 

            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

        private void NueProducto_MouseMove(object sender, MouseEventArgs e)
        {

            var ObjetoSeleccionado = sender as uc_Producto;
            base.OnMouseMove(e);//se captura la pocision de maouse en el objeto
            if (e.LeftButton == MouseButtonState.Pressed)//se selecciono el objeto
            {
                // se recolecta la informacion de el objeto y se le asigna a la clase global

                productoAnterior.nomTipProducto = ObjetoSeleccionado.nomTipProducto;
                productoAnterior.preExtProducto = ObjetoSeleccionado.preExtProducto;
                productoAnterior.preNacProducto = ObjetoSeleccionado.preNacProducto;
                productoAnterior.calTipProducto = ObjetoSeleccionado.calTipProducto;
                productoAnterior.canInvProducto = ObjetoSeleccionado.canInvProducto;
                productoAnterior.UniMedida = ObjetoSeleccionado.UniMedida;
                productoAnterior.IdTipProducto = ObjetoSeleccionado.IdTipProducto;
                productoAnterior.Color(color);

                productoAnterior.IdMoneda = ObjetoSeleccionado.IdMoneda;

                // Inicia el evento de drag and drop
                DragDrop.DoDragDrop(this, productoAnterior, DragDropEffects.Copy | DragDropEffects.Move);
            }

        }

        private void wpVeProducto_Drop(object sender, DragEventArgs e)
        {

            uc_Producto nuevo = new uc_Producto();
            base.OnDrop(e);
            foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpProducto))//verifica si existe el producto en el campo de facturacion
            {

                if (productoAnterior.IdTipProducto == Producto.IdTipProducto)
                {
                    nuevo = Producto;
                    nuevo.canInvProducto = Producto.canInvProducto;
                    nuevo.nomTipProducto = Producto.nomTipProducto;
                    nuevo.IdTipProducto = Producto.IdTipProducto;
                    nuevo.UniMedida = Producto.UniMedida;

                }

            }

            wnwCantidadProductoPedido nueva = new wnwCantidadProductoPedido("Agregar", nuevo);
            nueva.Owner = this;
            nueva.ShowDialog();

            e.Handled = true;
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CargarProductos("");
        }
        public void CargarPedido(string idPedido, string cantidad)
        {
            bool esta = false;
            foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpVeProducto))//verifica si existe el producto en el campo de facturacion
            {
                if (idPedido == Producto.IdTipProducto)
                {
                    Producto.canInvProducto = (Convert.ToInt32(Producto.canInvProducto) + Convert.ToInt32(cantidad)).ToString();
                    RestarInventario(Producto);
                    esta = true;
                    CalcularPrecioTotal();
                }

            }
            if (esta == false)
            {
                uc_Producto NuevoProducto = new uc_Producto();
                NuevoProducto.nomTipProducto = productoAnterior.nomTipProducto;
                NuevoProducto.preExtProducto = productoAnterior.preExtProducto;
                NuevoProducto.preNacProducto = productoAnterior.preNacProducto;
                NuevoProducto.calTipProducto = productoAnterior.calTipProducto;
                NuevoProducto.canInvProducto = cantidad;
                NuevoProducto.UniMedida = productoAnterior.UniMedida;
                NuevoProducto.IdTipProducto = productoAnterior.IdTipProducto;
                NuevoProducto.Color(color);
                NuevoProducto.IdMoneda = productoAnterior.IdMoneda;
                NuevoProducto.btnAgregarEditar.Tag = Convert.ToInt32(productoAnterior.IdTipProducto);
                NuevoProducto.btnAgregarEditar.Click += BtnAgregarEditar_Click1;
                wpVeProducto.Children.Add(NuevoProducto);
                RestarInventario(NuevoProducto);
                CalcularPrecioTotal();
            }
        }

        private void BtnAgregarEditar_Click1(object sender, RoutedEventArgs e)
        {
            uc_Producto nuevo = new uc_Producto();
            Button btnId = (Button)sender;
            foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpProducto))//revisa la lista de producto para verificar que existan disponibles
            {
                if (btnId.Tag.ToString() == Producto.IdTipProducto)
                {
                    nuevo = Producto;
                    nuevo.canInvProducto = Producto.canInvProducto;
                    nuevo.nomTipProducto = Producto.nomTipProducto;
                    nuevo.IdTipProducto = Producto.IdTipProducto;
                    nuevo.UniMedida = Producto.UniMedida;
                }

            }
            if (Convert.ToInt32(nuevo.canInvProducto) <= 0) { MessageBox.Show("Producto Agotado"); }
            wnwCantidadProductoPedido nueva = new wnwCantidadProductoPedido("Editar Cantidad", nuevo);
            nueva.Owner = this;
            nueva.ShowDialog();
        }
        public void RestarInventario(uc_Producto pProducto)
        {
            foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpProducto))//revisa la lista de producto para verificar que existan disponibles
            {
                if (pProducto.IdTipProducto == Producto.IdTipProducto)
                {
                    Producto.canInvProducto = (Convert.ToInt32(Producto.canInvProducto) - Convert.ToInt32(pProducto.canInvProducto)).ToString();
                }
            }
        }
        public void CalcularPrecioTotal()
        { 
            foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpVeProducto))//revisa la lista de producto para verificar que existan disponibles
            {
                Producto.preNacProducto = ((Convert.ToInt32(Producto.preNacProducto) * Convert.ToInt32(Producto.canInvProducto))).ToString();
                Producto.preExtProducto = ((Convert.ToInt32(Producto.preExtProducto) * Convert.ToInt32(Producto.canInvProducto))).ToString();
                txbCanTotColones.Text = ((Convert.ToInt32(Producto.preNacProducto) + Convert.ToInt32(txbCanTotColones.Text))).ToString();
                txbCanTotDolares.Text = ((Convert.ToInt32(Producto.preExtProducto) + Convert.ToInt32(txbCanTotDolares.Text))).ToString();
            }
        }

        private void btnGenerarFactura_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
