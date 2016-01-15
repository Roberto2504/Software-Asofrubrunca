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
        string Accion;
        ProductoMantenimiento mantProducto = new ProductoMantenimiento();
        public wnwPreciosProducto(string pAccion)
        {
            InitializeComponent();           
            cmbProducto.ItemsSource = mantProducto.ListarTipoProducto();
            Accion = pAccion;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Accion == "Compra")
                {
                    SIGEEA_PreProCompra nuevoPrecio = new SIGEEA_PreProCompra();
                    nuevoPrecio.PreNacional_PreProCompra = Convert.ToDouble(txbPreNacional.Text);
                    nuevoPrecio.PreExtranjero_PreProCompra = Convert.ToDouble(txbPreExtranjero.Text);
                    nuevoPrecio.FK_Id_TipProducto = cmbProducto.SelectedIndex + 1;
                    nuevoPrecio.FecRegistro_PreProCompra = DateTime.Now;
                    mantProducto.ActualizarPrecioCompra(nuevoPrecio);
                }

                else if (Accion == "Venta")
                {
                    SIGEEA_PreProVenta nuevoPrecio = new SIGEEA_PreProVenta();
                    nuevoPrecio.PreNacional_PreProVenta = Convert.ToDouble(txbPreNacional.Text);
                    nuevoPrecio.PreExtranjero_PreProVenta = Convert.ToDouble(txbPreExtranjero.Text);
                    nuevoPrecio.FK_Id_TipProducto = cmbProducto.SelectedIndex + 1;
                    nuevoPrecio.FecRegistro_PreProVenta = DateTime.Now;
                    mantProducto.ActualizarPrecioVenta(nuevoPrecio);
                }
                MessageBox.Show("Actualización realizada con éxito");
            }
            catch
            {
                MessageBox.Show("No se pudo realizar la acción solicitada");
            }
        }
    }
}
