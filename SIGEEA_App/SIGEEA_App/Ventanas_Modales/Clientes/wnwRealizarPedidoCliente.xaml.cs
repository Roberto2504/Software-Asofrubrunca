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
using SIGEEA_App.User_Controls.Clientes;
using System.Collections.ObjectModel;
namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwRealizarPedidoCliente.xaml
    /// </summary>
    public partial class wnwRealizarPedidoCliente : MetroWindow
    {
        public wnwRealizarPedidoCliente(int pPk_Id_Cliente)
        {
            InitializeComponent();
            CargarDatos();
            idCliente = pPk_Id_Cliente;
        }

        public void CargarDatos()
        {
            MonedaMantenimiento mon = new MonedaMantenimiento();

            listaTipoFactura.Add("Contado");
            listaTipoFactura.Add("Crédito");
            listaTipoFactura.Add("Proforma");
            listaTipoPedido.Add("NACIONAL");
            listaTipoPedido.Add("EXTRANJERO");
            cmbVenta.ItemsSource = listaTipoPedido;
            cmbMoneda.ItemsSource = mon.ListarMonedas();
            cmbTipoFactura.ItemsSource = listaTipoFactura;

        }

        ProductoMantenimiento producto = new ProductoMantenimiento();
        ClienteMantenimiento clientMant = new ClienteMantenimiento();
        private uc_Producto productoAnterior = new uc_Producto();

        bool color = true;
        int Contador = 0;
        int conta = 0;
        string nomMoneda;
        string tipoPepido;
        int idCliente;
        List<string> listaTipoPedido = new List<string>();
        List<string> listaTipoFactura = new List<string>();
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
                    nueProducto.preNacProducto = result.PreNacional_PreProVenta.ToString();
                    nueProducto.preExtProducto = result.PreExtranjero_PreProVenta.ToString();
                    nueProducto.canInvProducto = result.Cantidad_DetInvProductos.ToString();
                    if (cmbVenta.Text == "NACIONAL")
                    {
                        nueProducto.preProducto = result.PreNacional_PreProVenta.ToString();
                        nueProducto.Moneda = "¢";
                    }
                    else {
                        nueProducto.preProducto = result.PreExtranjero_PreProVenta.ToString();
                        nueProducto.Moneda = "¢"; ;
                    }
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
                    nuevo.Tag = Contador.ToString();
                    nuevo.canInvProducto = Producto.canInvProducto;
                    nuevo.nomTipProducto = Producto.nomTipProducto;
                    nuevo.IdTipProducto = Producto.IdTipProducto;
                    nuevo.Moneda = Producto.Moneda;
                    nuevo.preProducto = Producto.preProducto;
                    nuevo.preExtProducto = Producto.preExtProducto;
                    nuevo.preNacProducto = Producto.preNacProducto;
                    nuevo.UniMedida = Producto.UniMedida;
                    nuevo.calTipProducto = Producto.calTipProducto;
                    Contador++;
                }

            }
            wnwCantidadProductoPedido nueva = new wnwCantidadProductoPedido("Agregar", pProducto: nuevo, pDetProducto: null);
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
                productoAnterior.Tag = Contador.ToString();
                productoAnterior.nomTipProducto = ObjetoSeleccionado.nomTipProducto;
                productoAnterior.preProducto = ObjetoSeleccionado.preProducto;
                productoAnterior.calTipProducto = ObjetoSeleccionado.calTipProducto;
                productoAnterior.canInvProducto = ObjetoSeleccionado.canInvProducto;
                productoAnterior.UniMedida = ObjetoSeleccionado.UniMedida;
                productoAnterior.IdTipProducto = ObjetoSeleccionado.IdTipProducto;
                productoAnterior.Color(color);
                productoAnterior.Moneda = ObjetoSeleccionado.Moneda;
                productoAnterior.preExtProducto = ObjetoSeleccionado.preExtProducto;
                productoAnterior.preNacProducto = ObjetoSeleccionado.preNacProducto;
                productoAnterior.IdMoneda = ObjetoSeleccionado.IdMoneda;
                productoAnterior.calTipProducto = ObjetoSeleccionado.calTipProducto;
                Contador++;
                // Inicia el evento de drag and drop
                DragDrop.DoDragDrop(this, productoAnterior, DragDropEffects.Copy | DragDropEffects.Move);
            }

        }

        private void wpVeProducto_Drop(object sender, DragEventArgs e)
        {

            uc_Producto nuevo = new uc_Producto();
            base.OnDrop(e);

            nuevo.preExtProducto = productoAnterior.preExtProducto;
            nuevo.preNacProducto = productoAnterior.preNacProducto;
            nuevo.canInvProducto = productoAnterior.canInvProducto;
            nuevo.nomTipProducto = productoAnterior.nomTipProducto;
            nuevo.IdTipProducto = productoAnterior.IdTipProducto;
            nuevo.UniMedida = productoAnterior.UniMedida;
            nuevo.Moneda = productoAnterior.Moneda;
            nuevo.preProducto = productoAnterior.preProducto;
            nuevo.Color(color);
            nuevo.Tag = productoAnterior.Tag;
            nuevo.calTipProducto = productoAnterior.calTipProducto;

            wnwCantidadProductoPedido nueva = new wnwCantidadProductoPedido("Agregar", pProducto: nuevo, pDetProducto: null);
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


        public void CargarPedido(uc_DetProducto pdetProducto)
        {
            bool esta = false;

            foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))//verifica si existe el producto en el campo de facturacion
            {
                if (pdetProducto.Tag == Producto.Tag)
                {
                    Producto.calTipProducto = pdetProducto.calTipProducto;
                    Producto.desProducto = pdetProducto.desProducto;
                    Producto.preBruProducto = pdetProducto.preBruProducto;
                    Producto.preNetProducto = pdetProducto.preNetProducto;
                    Producto.canDisProducto = pdetProducto.canDisProducto;
                    Producto.canInvProducto = pdetProducto.canInvProducto;
                    pdetProducto.Color(color);
                    //wpVeProducto.Children.Add(pdetProducto);
                    RestarInventario(pdetProducto);
                    esta = true;
                    CalcularPrecioTotal();
                }

            }
            if (esta == false)
            {

                pdetProducto.Color(color);
                pdetProducto.btnAgregarEditar.Tag = pdetProducto.Tag;
                pdetProducto.btnAgregarEditar.Click += BtnAgregarEditar_Click1;
                wpVeProducto.Children.Add(pdetProducto);
                RestarInventario(pdetProducto);
                CalcularPrecioTotal();
            }
            //else {
            //    pdetProducto.Color(color);
            //    pdetProducto.btnAgregarEditar.Tag = Convert.ToInt32(pdetProducto.IdTipProducto);
            //    pdetProducto.btnAgregarEditar.Click += BtnAgregarEditar_Click1;
            //    wpVeProducto.Children.Add(pdetProducto);
            //    RestarInventario(pdetProducto);

            //    CalcularPrecioTotal();
            //}

        }

        private void BtnAgregarEditar_Click1(object sender, RoutedEventArgs e)
        {
            uc_DetProducto nuevo = new uc_DetProducto();
            Button btnId = (Button)sender;
            foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))//revisa la lista de producto para verificar que existan disponibles
            {
                if (btnId.Tag == Producto.Tag)
                {
                    nuevo.calTipProducto = Producto.calTipProducto;
                    nuevo = Producto;
                    nuevo.canInvProducto = Producto.canInvProducto;
                    nuevo.nomTipProducto = Producto.nomTipProducto;
                    nuevo.IdTipProducto = Producto.IdTipProducto;
                    nuevo.desProducto = Producto.desProducto;
                    nuevo.preBruProducto = Producto.preBruProducto;
                    nuevo.preNetProducto = Producto.preNetProducto;
                    nuevo.preExtProducto = Producto.preExtProducto;
                    nuevo.preNacProducto = Producto.preNacProducto;
                    nuevo.preProducto = Producto.preProducto;
                    nuevo.Moneda = Producto.Moneda;
                    nuevo.UniMedida = Producto.UniMedida;
                    nuevo.canDisProducto = Producto.canDisProducto;
                    nuevo.Tag = Producto.Tag;
                }

            }
            foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpProducto))//revisa la lista de producto para verificar que existan disponibles
            {
                if (nuevo.IdTipProducto == Producto.IdTipProducto)
                {
                    nuevo.canDisProducto = Producto.canInvProducto;

                }

            }
            if (Convert.ToInt32(nuevo.canDisProducto) <= 0) { MessageBox.Show("Producto Agotado"); }
            wnwCantidadProductoPedido nueva = new wnwCantidadProductoPedido("Editar Cantidad", pProducto: null, pDetProducto: nuevo);
            nueva.Owner = this;
            nueva.ShowDialog();
        }
        public void RestarInventario(uc_DetProducto pProducto)
        {
            foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpProducto))//revisa la lista de producto para verificar que existan disponibles
            {
                if (pProducto.IdTipProducto == Producto.IdTipProducto)
                {
                    Producto.canInvProducto = pProducto.canDisProducto;
                }
            }

            clientMant.RestarInventario(Convert.ToInt32(pProducto.IdTipProducto), Convert.ToDouble(pProducto.canDisProducto));
        }


        private void cmbMoneda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nomMoneda = this.cmbMoneda.SelectedItem.ToString();
            txbCantitadTotal.Text = "TOTAL(" + this.cmbMoneda.SelectedItem + ")=";
            if (conta != 0)
            {
                CalcularPrecioTotal();
            }
            conta++;

        }
        public void CalcularPrecioTotal()
        {
            MonedaMantenimiento monMant = new MonedaMantenimiento();
            double Total = 0;
            foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))//revisa la lista de producto para verificar que existan disponibles
            {
                Total = Total + Convert.ToDouble(Producto.preNetProducto);
            }
            if (Total != 0)
            {
                if (cmbVenta.SelectedItem.ToString() == "NACIONAL")
                {
                    if (nomMoneda == "Colón")
                    {
                        Total = Total * monMant.PrecioVenta(nomMoneda);
                    }
                    else Total = Total / monMant.PrecioVenta(nomMoneda);
                }
                else {
                    if (nomMoneda == "Colón")
                    {
                        Total = Total * monMant.PrecioVenta("Dolar");
                    }
                    else if (nomMoneda == "Dolar")
                    {
                        Total = Total * 1;
                    }


                }
            }
            txbCanTotDolares.Text = Math.Round(Total, 3).ToString();
            if (txbCanTotDolares.Text != "")
            {
                txbCanTotNeto.Text = (Math.Round(((Convert.ToDouble(txbCanTotDolares.Text)) - (((Convert.ToDouble(txbCanTotDolares.Text)) * Convert.ToDouble(ucDescuentoTotal.NUDTextBox.Text)) / 100)), 2)).ToString();
            }
        }



        private void cmbVenta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tipoPepido = this.cmbVenta.SelectedItem.ToString();
            if (tipoPepido == "NACIONAL")
            {
                foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))//revisa la lista de producto para verificar que existan disponibles
                {

                    Producto.preNetProducto = ((Convert.ToDouble(Producto.canInvProducto) * Convert.ToDouble(Producto.preNacProducto))).ToString();
                    Producto.preBruProducto = ((Convert.ToDouble(Producto.canInvProducto) * Convert.ToDouble(Producto.preNacProducto)) - (((Convert.ToDouble(Producto.canInvProducto) * Convert.ToDouble(Producto.preNacProducto)) * Convert.ToDouble(Producto.desProducto)) / 100)).ToString();
                    Producto.Moneda = "¢";

                }
                foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpProducto))
                {
                    Producto.preProducto = Producto.preNacProducto;
                    Producto.Moneda = "¢";
                }

            }
            else
            {

                foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpProducto))
                {

                    Producto.preProducto = Producto.preExtProducto;
                    Producto.Moneda = "$";


                }
                foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))
                {

                    Producto.preBruProducto = ((Convert.ToDouble(Producto.canInvProducto) * Convert.ToDouble(Producto.preExtProducto))).ToString();
                    Producto.preNetProducto = ((Convert.ToDouble(Producto.canInvProducto) * Convert.ToDouble(Producto.preExtProducto)) - (((Convert.ToDouble(Producto.canInvProducto) * Convert.ToDouble(Producto.preExtProducto)) * Convert.ToDouble(Producto.desProducto)) / 100)).ToString();
                    Producto.Moneda = "$";

                }

            }
            CalcularPrecioTotal();
        }
        public void ListarDetalleProducto()
        {

        }
        private void btnGenerarFactura_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<uc_DetProducto> listarDetProducto = new ObservableCollection<uc_DetProducto>();
            foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))
            {
                clientMant.SumarInventario(Convert.ToInt32(Producto.IdTipProducto), (Convert.ToDouble(Producto.canDisProducto) + Convert.ToDouble(Producto.canInvProducto)));
                listarDetProducto.Add(Producto);
            }

            if (cmbTipoFactura.SelectedItem.ToString() == "Contado")
            {
                MessageBoxResult m = MessageBox.Show("Su tipo de factura es: " + cmbTipoFactura.SelectedItem.ToString(), "Mensaje de Confirmación", MessageBoxButton.YesNo);
                if (m == MessageBoxResult.Yes)
                {
                    wnwDatosFacturaCliente nueva = new wnwDatosFacturaCliente(pkIdEmpleado: 2, pkIdCliente: idCliente, Tipo: cmbTipoFactura.SelectedItem.ToString(), pkIdEmpresa: 1, ptipoPedido: tipoPepido, nueva: listarDetProducto, pMontoTotal: txbCanTotDolares.Text, pDescuentoTotal: ucDescuentoTotal.NUDTextBox.Text, pMontoNetoTotal: txbCanTotNeto.Text, pMonedaTotal: nomMoneda);
                    nueva.ShowDialog();
                }
            }
            else if (cmbTipoFactura.SelectedItem.ToString() == "Crédito")
            {
                MessageBoxResult m = MessageBox.Show("Su tipo de factura es: " + cmbTipoFactura.SelectedItem.ToString(), "Mensaje de Confirmación", MessageBoxButton.YesNo);
                if (m == MessageBoxResult.Yes)
                {
                    wnwDatosFacturaCliente nueva = new wnwDatosFacturaCliente(pkIdEmpleado: 2, pkIdCliente: idCliente, Tipo: cmbTipoFactura.SelectedItem.ToString(), pkIdEmpresa: 1, ptipoPedido: tipoPepido, nueva: listarDetProducto, pMontoTotal: txbCanTotDolares.Text, pDescuentoTotal: ucDescuentoTotal.NUDTextBox.Text, pMontoNetoTotal: txbCanTotNeto.Text, pMonedaTotal: nomMoneda);
                    nueva.ShowDialog();
                }
            }
            else if (cmbTipoFactura.SelectedItem.ToString() == "Proforma")
            {
                MessageBoxResult m = MessageBox.Show("Su tipo de factura es: " + cmbTipoFactura.SelectedItem.ToString(), "Mensaje de Confirmación", MessageBoxButton.YesNo);
                if (m == MessageBoxResult.Yes)
                {


                    foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))
                    {
                        clientMant.SumarInventario(Convert.ToInt32(Producto.IdTipProducto), (Convert.ToDouble(Producto.canDisProducto) + Convert.ToDouble(Producto.canInvProducto)));

                    }
                    wnwCancelarFacturaCliente nueva = new wnwCancelarFacturaCliente(pkIdEmpleado: 2, pkIdCliente: idCliente, Tipo: cmbTipoFactura.SelectedItem.ToString(), pkIdEmpresa: 1, ptipoPedido: tipoPepido, nueva: listarDetProducto, pMontoTotal: txbCanTotDolares.Text, pDescuentoTotal: ucDescuentoTotal.NUDTextBox.Text, pMontoNetoTotal: txbCanTotNeto.Text, pMonedaTotal: nomMoneda, pObservaciones: null, pMontoAbono: null, pfechaProPago: null, pmetodoPago: null, pnumero: null);


                    nueva.ShowDialog();
                }

            }
        }

        private void ucDescuentoTotal_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (txbCanTotDolares.Text != "")
            {
                txbCanTotNeto.Text = (Math.Round(((Convert.ToDouble(txbCanTotDolares.Text)) - (((Convert.ToDouble(txbCanTotDolares.Text)) * Convert.ToDouble(ucDescuentoTotal.NUDTextBox.Text)) / 100)), 2)).ToString();
            }
        }
        Double total;
        private void cmbTipoFactura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cmbTipoFactura.SelectedItem.ToString() == "Crédito")
            //{
            //    List<Double> listadeCredito = new List<Double>();
            //    listadeCredito = clientMant.ListarCreditosCliente(idCliente);
            //    total = 0;
            //    foreach (Double credito in listadeCredito)
            //    {
            //        total += credito;
            //    }
            //    total += Convert.ToDouble(txbCanTotNeto.Text);
            //    if (total > Convert.ToDouble(clientMant.LimiteCreditoCliente(idCliente)))
            //    {   total -= Convert.ToDouble(clientMant.LimiteCreditoCliente(idCliente));
            //        MessageBox.Show("El cliente actual solo posee: " + total)
            //    }
            //}esto lo voy a dejar pendiente
        }
    }
}