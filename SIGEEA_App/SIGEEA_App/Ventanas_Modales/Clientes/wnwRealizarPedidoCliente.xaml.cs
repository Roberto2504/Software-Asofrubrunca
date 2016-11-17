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
using SIGEEA_BL.Seguridad;
namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwRealizarPedidoCliente.xaml
    /// </summary>
    public partial class wnwRealizarPedidoCliente : Window
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
        public string SepararMiles(double Cantidad)
        {
            return Cantidad.ToString("N2");
        }
        ProductoMantenimiento producto = new ProductoMantenimiento();
        ClienteMantenimiento clientMant = new ClienteMantenimiento();
        MonedaMantenimiento monMant = new MonedaMantenimiento();
        private uc_Producto productoAnterior = new uc_Producto();
        int primera = 0;
        bool color = true;
        int Contador = 0;
        int conta = 0;
        string nomMoneda;
        string tipoPepido;
        int idCliente;
        Double totalCredito;
        List<string> listaTipoPedido = new List<string>();
        List<string> listaTipoFactura = new List<string>();
        
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
                    nueProducto.preNacProducto = SepararMiles(Math.Round(Convert.ToDouble(result.PreNacional_PreProVenta),2)).ToString();
                    nueProducto.preExtProducto = SepararMiles(Math.Round(Convert.ToDouble(result.PreExtranjero_PreProVenta), 2)).ToString();
                    nueProducto.canInvProducto = SepararMiles(Math.Round(Convert.ToDouble(result.Cantidad_DetInvProductos), 2)).ToString();
                    if (cmbVenta.Text == "NACIONAL")
                    {
                        nueProducto.preProducto = SepararMiles(Math.Round(Convert.ToDouble(result.PreNacional_PreProVenta), 2)).ToString();
                        nueProducto.Moneda = "¢";
                    }
                    else {
                        nueProducto.preProducto = SepararMiles(Math.Round(Convert.ToDouble(result.PreExtranjero_PreProVenta), 2)).ToString();
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
                    nuevo.preProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.preProducto), 2)).ToString(); 
                    nuevo.preExtProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.preExtProducto), 2)).ToString(); 
                    nuevo.preNacProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.preNacProducto), 2)).ToString(); 
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
                productoAnterior.preProducto = SepararMiles(Math.Round(Convert.ToDouble(ObjetoSeleccionado.preProducto), 2));
                productoAnterior.calTipProducto = ObjetoSeleccionado.calTipProducto;
                productoAnterior.canInvProducto = SepararMiles(Math.Round(Convert.ToDouble(ObjetoSeleccionado.canInvProducto), 2)); 
                productoAnterior.UniMedida = ObjetoSeleccionado.UniMedida;
                productoAnterior.IdTipProducto = ObjetoSeleccionado.IdTipProducto;
                productoAnterior.Color(color);
                productoAnterior.Moneda = ObjetoSeleccionado.Moneda;
                productoAnterior.preExtProducto = SepararMiles(Math.Round(Convert.ToDouble(ObjetoSeleccionado.preExtProducto), 2)); 
                productoAnterior.preNacProducto = SepararMiles(Math.Round(Convert.ToDouble(ObjetoSeleccionado.preNacProducto), 2)); 
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
            nuevo.preExtProducto = SepararMiles(Math.Round(Convert.ToDouble(productoAnterior.preExtProducto), 2)); 
            nuevo.preNacProducto = SepararMiles(Math.Round(Convert.ToDouble(productoAnterior.preNacProducto), 2));
            nuevo.canInvProducto = SepararMiles(Math.Round(Convert.ToDouble(productoAnterior.canInvProducto), 2));
            nuevo.nomTipProducto = productoAnterior.nomTipProducto;
            nuevo.IdTipProducto = productoAnterior.IdTipProducto;
            nuevo.UniMedida = productoAnterior.UniMedida;
            nuevo.Moneda = productoAnterior.Moneda;
            nuevo.preProducto = SepararMiles(Math.Round(Convert.ToDouble(productoAnterior.preProducto), 2));
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
                    Producto.preBruProducto = SepararMiles(Math.Round(Convert.ToDouble(pdetProducto.preBruProducto), 2));
                    Producto.preNetProducto = SepararMiles(Math.Round(Convert.ToDouble(pdetProducto.preNetProducto), 2));
                    Producto.canDisProducto = SepararMiles(Math.Round(Convert.ToDouble(pdetProducto.preNetProducto), 2));
                    Producto.canInvProducto = SepararMiles(Math.Round(Convert.ToDouble(pdetProducto.canInvProducto), 2)); 
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
                    nuevo.canInvProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.canInvProducto), 2)); 
                    nuevo.nomTipProducto = Producto.nomTipProducto;
                    nuevo.IdTipProducto = Producto.IdTipProducto;
                    nuevo.desProducto = Producto.desProducto;
                    nuevo.preBruProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.preBruProducto), 2)); 
                    nuevo.preNetProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.preNetProducto), 2)); 
                    nuevo.preExtProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.preExtProducto), 2)); 
                    nuevo.preNacProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.preNacProducto), 2)); 
                    nuevo.preProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.preProducto), 2)); 
                    nuevo.Moneda = Producto.Moneda;
                    nuevo.UniMedida = Producto.UniMedida;
                    nuevo.canDisProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.canDisProducto), 2)); 
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

            if (conta != 0)
            {
                CalcularPrecioTotal();
            }
            conta++;

        }
        public void CalcularPrecioTotal()
        {
            
            double Total = 0;
            foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))//revisa la lista de producto para verificar que existan disponibles
            {
                Total = Total + Convert.ToDouble(Producto.preNetProducto);
            }
            
            if (Total != 0)
            {
                if (cmbVenta.SelectedItem.ToString() == "NACIONAL")//ESTO SE PUEDE CAMBIAR PARA QUE EL PRECIO DEL EXTRAJERO APAREZCA EN COLONES
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

            if (nomMoneda == "Colón")
            {
                txbCanTotBruto.Text = "₡" + SepararMiles(Math.Round(Total, 3));
                string conTotBruto = txbCanTotBruto.Text;
                
                if (txbCanTotBruto.Text != "")
                {
                    txbCanTotNeto.Text = "₡" + SepararMiles(Math.Round(((Convert.ToDouble(conTotBruto.Remove(0, 1))) - (((Convert.ToDouble(conTotBruto.Remove(0, 1))) * Convert.ToDouble(ucDescuentoTotal.NUDTextBox.Text)) / 100)), 2)); 
                }
            }
            else if (nomMoneda == "Dolar")
            {
                txbCanTotBruto.Text = "$" + SepararMiles(Math.Round(Total, 3));
                string conTotBruto = txbCanTotBruto.Text;
               
                if (txbCanTotBruto.Text != "")
                {
                    txbCanTotNeto.Text = "$"+ SepararMiles((Math.Round(((Convert.ToDouble(conTotBruto.Remove(0,1))) - (((Convert.ToDouble(conTotBruto.Remove(0, 1))) * Convert.ToDouble(ucDescuentoTotal.NUDTextBox.Text)) / 100)), 2)));
                }
            }
            CalculaCredito();
        }



        private void cmbVenta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tipoPepido = this.cmbVenta.SelectedItem.ToString();
            if (tipoPepido == "NACIONAL")
            {
                foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))//revisa la lista de producto para verificar que existan disponibles
                {

                    Producto.preNetProducto = SepararMiles(Math.Round(((Convert.ToDouble(Producto.canInvProducto) * Convert.ToDouble(Producto.preNacProducto))),2));
                    Producto.preBruProducto = SepararMiles(Math.Round(((Convert.ToDouble(Producto.canInvProducto) * Convert.ToDouble(Producto.preNacProducto)) - (((Convert.ToDouble(Producto.canInvProducto) * Convert.ToDouble(Producto.preNacProducto)) * Convert.ToDouble(Producto.desProducto)) / 100)),2));
                    Producto.Moneda = "¢";

                }
                foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpProducto))
                {
                    Producto.preProducto = SepararMiles(Math.Round(Convert.ToDouble(Producto.preNacProducto),2));
                    Producto.Moneda = "¢";
                }

            }
            else
            {
               
                foreach (uc_Producto Producto in FindVisualChildren<uc_Producto>(wpProducto))
                {

                    Producto.preProducto = SepararMiles(Math.Round((Convert.ToDouble(Producto.preExtProducto) / monMant.PrecioVenta("Dolar")), 2)); 
                    Producto.Moneda = "$";
                }
                foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))
                {

                    Producto.preBruProducto = SepararMiles(Math.Round((Convert.ToDouble(Producto.canInvProducto) * (Convert.ToDouble(Producto.preExtProducto) / monMant.PrecioVenta("Dolar"))), 2)); 
                    Producto.preNetProducto = SepararMiles(Math.Round(((Convert.ToDouble(Producto.canInvProducto) * (Convert.ToDouble(Producto.preExtProducto) / monMant.PrecioVenta("Dolar"))) - (((Convert.ToDouble(Producto.canInvProducto) * (Convert.ToDouble(Producto.preExtProducto) / monMant.PrecioVenta("Dolar"))) * Convert.ToDouble(Producto.desProducto)) / 100)), 2));
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

                listarDetProducto.Add(Producto);
            }

            if (cmbTipoFactura.SelectedItem.ToString() == "Contado")
            {
                MessageBoxResult m = MessageBox.Show("Su tipo de factura es: " + cmbTipoFactura.SelectedItem.ToString(), "Mensaje de Confirmación", MessageBoxButton.YesNo);
                if (m == MessageBoxResult.Yes)
                {
                    wnwDatosFacturaCliente nueva = new wnwDatosFacturaCliente(pkIdEmpleado: UsuarioGlobal.InfoUsuario.PK_Id_Empleado, pkIdCliente: idCliente, Tipo: cmbTipoFactura.SelectedItem.ToString(), pkIdEmpresa: 1, ptipoPedido: tipoPepido, nueva: listarDetProducto, pMontoTotal: txbCanTotBruto.Text, pDescuentoTotal: ucDescuentoTotal.NUDTextBox.Text, pMontoNetoTotal: txbCanTotNeto.Text, pMonedaTotal: nomMoneda);
                    nueva.Closed += Nueva_Closed;
                    nueva.ShowDialog();
                }
            }
            else if (cmbTipoFactura.SelectedItem.ToString() == "Crédito")
            {
                MessageBoxResult m = MessageBox.Show("Su tipo de factura es: " + cmbTipoFactura.SelectedItem.ToString(), "Mensaje de Confirmación", MessageBoxButton.YesNo);
                if (m == MessageBoxResult.Yes)
                {
                    wnwDatosFacturaCliente nueva = new wnwDatosFacturaCliente(pkIdEmpleado: UsuarioGlobal.InfoUsuario.PK_Id_Empleado, pkIdCliente: idCliente, Tipo: cmbTipoFactura.SelectedItem.ToString(), pkIdEmpresa: 1, ptipoPedido: tipoPepido, nueva: listarDetProducto, pMontoTotal: txbCanTotBruto.Text, pDescuentoTotal: ucDescuentoTotal.NUDTextBox.Text, pMontoNetoTotal: txbCanTotNeto.Text, pMonedaTotal: nomMoneda);
                    nueva.Closed += Nueva_Closed;
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
                    wnwDatosFacturaCliente nueva = new wnwDatosFacturaCliente(pkIdEmpleado: UsuarioGlobal.InfoUsuario.PK_Id_Empleado, pkIdCliente: idCliente, Tipo: cmbTipoFactura.SelectedItem.ToString(), pkIdEmpresa: 1, ptipoPedido: tipoPepido, nueva: listarDetProducto, pMontoTotal: txbCanTotBruto.Text, pDescuentoTotal: ucDescuentoTotal.NUDTextBox.Text, pMontoNetoTotal: txbCanTotNeto.Text, pMonedaTotal: nomMoneda);
                    nueva.Closed += Nueva_Closed;
                    nueva.ShowDialog();
                }

            }
        }

        private void Nueva_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucDescuentoTotal_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (txbCanTotBruto.Text != "")
            {
                string conTotBruto = txbCanTotBruto.Text;
                txbCanTotNeto.Text = string.Concat(txbCanTotBruto.Text[0],(SepararMiles(Math.Round(((Convert.ToDouble(conTotBruto.Remove(0, 1))) - (((Convert.ToDouble(conTotBruto.Remove(0, 1))) * Convert.ToDouble(ucDescuentoTotal.NUDTextBox.Text)) / 100)), 2))));
                CalculaCredito();
            }
        }

        private void cmbTipoFactura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoFactura.SelectedItem.ToString() == "Crédito")
            {
                CalculaCredito();
            }
            else grdCredito.Visibility = Visibility.Hidden;
        }
        public void CalculaCredito()
        {
            if (primera != 0)
            {
                if (cmbTipoFactura.SelectedItem.ToString() == "Crédito")
                {
                    string CanTotNeto = txbCanTotNeto.Text;
                    MonedaMantenimiento monMant = new MonedaMantenimiento();
                    List<SIGEEA_spListarCreditoClienteResult> listadeCredito = new List<SIGEEA_spListarCreditoClienteResult>();
                    listadeCredito = clientMant.ListarCreditosCliente(idCliente);
                    totalCredito = 0;
                    foreach (SIGEEA_spListarCreditoClienteResult saldo in listadeCredito)
                    {
                        totalCredito += Convert.ToDouble(saldo.Saldo);
                    }
                    if (nomMoneda == "Colón")
                    {
                        totalCredito += Convert.ToDouble(CanTotNeto.Remove(0, 1));
                        if (totalCredito > Convert.ToDouble(clientMant.LimiteCreditoCliente(idCliente).Limite_CatCliente))
                        {
                            totalCredito -= Convert.ToDouble(CanTotNeto.Remove(0,1));
                            totalCredito = Convert.ToDouble(clientMant.LimiteCreditoCliente(idCliente).Limite_CatCliente) - totalCredito;
                            MessageBox.Show("El cliente actual solo posee: ¢" + totalCredito + " de credito disponible");
                        }
                        else
                        {
                            if (cmbTipoFactura.SelectedItem.ToString() == "Crédito")
                            {
                                totalCredito -= Convert.ToDouble(CanTotNeto.Remove(0, 1));
                                grdCredito.Visibility = Visibility.Visible;
                                totalCredito = Convert.ToDouble(clientMant.LimiteCreditoCliente(idCliente).Limite_CatCliente) - totalCredito;
                                txbCredito.Text = "¢" + SepararMiles(Math.Round(totalCredito,2));
                            }
                            else grdCredito.Visibility = Visibility.Hidden;
                        }
                    }
                    else if (nomMoneda == "Dolar")
                    {
                        totalCredito += Convert.ToDouble(CanTotNeto.Remove(0, 1)) * monMant.PrecioVenta("Dolar");
                        if (totalCredito > Convert.ToDouble(clientMant.LimiteCreditoCliente(idCliente).Limite_CatCliente))
                        {
                            totalCredito -= Convert.ToDouble(CanTotNeto.Remove(0, 1)) * monMant.PrecioVenta("Dolar");
                            totalCredito = Convert.ToDouble(clientMant.LimiteCreditoCliente(idCliente).Limite_CatCliente) - totalCredito;
                            totalCredito = totalCredito / monMant.PrecioVenta("Dolar");
                            MessageBox.Show("El cliente actual solo posee: ¢" + totalCredito + " de credito disponible");
                        }
                        else
                        {
                            if (cmbTipoFactura.SelectedItem.ToString() == "Crédito")
                            {
                                grdCredito.Visibility = Visibility.Visible;

                                totalCredito -= Convert.ToDouble(CanTotNeto.Remove(0, 1));
                                grdCredito.Visibility = Visibility.Visible;
                                totalCredito = Convert.ToDouble(clientMant.LimiteCreditoCliente(idCliente).Limite_CatCliente) - totalCredito;
                                totalCredito = totalCredito / monMant.PrecioVenta("Dolar");
                                txbCredito.Text = "$" + SepararMiles(Math.Round(totalCredito, 2));
                            }
                            else grdCredito.Visibility = Visibility.Hidden;
                        }
                    }
                }
                else grdCredito.Visibility = Visibility.Hidden;
            }
            primera++;



        }

        private void txbBuscarProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarProductos(txbBuscarProducto.Text);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            foreach (uc_DetProducto Producto in FindVisualChildren<uc_DetProducto>(wpVeProducto))
            {
                clientMant.SumarInventario(Convert.ToInt32(Producto.IdTipProducto), (Convert.ToDouble(Producto.canDisProducto) + Convert.ToDouble(Producto.canInvProducto)));
            }
            this.Close();
        }
    }
}