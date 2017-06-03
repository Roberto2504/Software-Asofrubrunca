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

namespace SIGEEA_App.Ventanas_Modales.Productos
{
    /// <summary>
    /// Interaction logic for wnwPreciosProducto.xaml
    /// </summary>
    public partial class wnwPreciosProducto : MetroWindow
    {
        ProductoMantenimiento mantProducto = new ProductoMantenimiento();
        public wnwPreciosProducto()
        {
            InitializeComponent();
            cmbProductoVenta.ItemsSource = mantProducto.ListarTipoProducto();
            cmbProductoCompra.ItemsSource = mantProducto.ListarTipoProducto();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SIGEEA_PreProCompra nuevoPrecioCompra = new SIGEEA_PreProCompra();
                nuevoPrecioCompra.PreNacional_PreProCompra = Convert.ToDouble(txbPreNacionalCompra.Text);
                nuevoPrecioCompra.PreExtranjero_PreProCompra = Convert.ToDouble(txbPreExtranjeroCompra.Text);
                nuevoPrecioCompra.FK_Id_TipProducto = cmbProductoCompra.SelectedIndex + 1;
                nuevoPrecioCompra.FecRegistro_PreProCompra = DateTime.Now;
                mantProducto.ActualizarPrecioCompra(nuevoPrecioCompra);

                SIGEEA_PreProVenta nuevoPrecioVenta = new SIGEEA_PreProVenta();
                nuevoPrecioVenta.PreNacional_PreProVenta = Convert.ToDouble(txbPreNacionalVenta.Text);
                nuevoPrecioVenta.PreExtranjero_PreProVenta = Convert.ToDouble(txbPreExtranjeroVenta.Text);
                nuevoPrecioVenta.FK_Id_TipProducto = cmbProductoVenta.SelectedIndex + 1;
                nuevoPrecioVenta.FecRegistro_PreProVenta = DateTime.Now;
                nuevoPrecioVenta.FK_Id_Moneda = 2;
                mantProducto.ActualizarPrecioVenta(nuevoPrecioVenta);
                MessageBox.Show("Actualización realizada con éxito", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("No se pudo realizar la acción solicitada", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void cmbProductoVenta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_spObtenerPreciosVentaActualProdResult precio = dc.SIGEEA_spObtenerPreciosVentaActualProd(cmbProductoVenta.SelectedValue.ToString()).First();

            txbPreExtranjeroVenta.Text = precio.PreExtranjero_PreProVenta.ToString();
            txbPreNacionalVenta.Text = precio.PreNacional_PreProVenta.ToString();
            btnEditarVenta.IsEnabled = true;
        }

        private void cmbProductoCompra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_spObtenerPreciosCompraActualProdResult precio = dc.SIGEEA_spObtenerPreciosCompraActualProd(cmbProductoCompra.SelectedValue.ToString()).First();
            btnEditarCompra.IsEnabled = true;

            txbPreExtranjeroCompra.Text = precio.PreExtranjero_PreProCompra.ToString();
            txbPreNacionalCompra.Text = precio.PreNacional_PreProCompra.ToString();
        }

        private void btnEditarCompra_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarProducto ventana = new wnwRegistrarProducto(cmbProductoCompra.SelectedValue.ToString());
            ventana.ShowDialog();
        }

        private void btnEditarVenta_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarProducto ventana = new wnwRegistrarProducto(cmbProductoVenta.SelectedValue.ToString());
            ventana.ShowDialog();
        }
    }
}
