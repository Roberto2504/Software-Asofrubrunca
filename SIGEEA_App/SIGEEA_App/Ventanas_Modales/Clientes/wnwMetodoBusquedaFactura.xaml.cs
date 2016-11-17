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

namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwMetodoBusquedaFactura.xaml
    /// </summary>
    public partial class wnwMetodoBusquedaFactura : MetroWindow
    {
        public wnwMetodoBusquedaFactura()
        {
            InitializeComponent();
            cmbOpciones.Items.Add("Todas las facturas pendientes");
            cmbOpciones.Items.Add("Todas las facturas pendientes por cliente");
            cmbOpciones.Items.Add("A partir del número de factura");
        }

        private void cmbOpciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbOpciones.SelectedIndex == 0)//Listar Todas las facturas pendientes
            {
                grdOpciones.Visibility = Visibility.Hidden;
            }
            if (cmbOpciones.SelectedIndex == 1)//Listar las facturas pendientes por cliente
            {
                grdOpciones.Visibility = Visibility.Hidden;

            }
            if (cmbOpciones.SelectedIndex == 2)//Listar A partir del número de factura
            {
                grdOpciones.Visibility = Visibility.Visible;
                lbNumero.Visibility = Visibility.Visible;
                txtNumeroFactura.Visibility = Visibility.Visible;
            }
        }
        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbOpciones.SelectedIndex == 0)//Listar Todas las facturas pendientes
            {
                wnwFacturasCliente nueva = new wnwFacturasCliente(Tipo: "Todas", IdCliente: 0, IdFactura: 0);
                nueva.ShowDialog();
            }
            if (cmbOpciones.SelectedIndex == 1)//Listar las facturas pendientes por cliente
            {
                wnwBuscadorCliente venPedidoCliente = new wnwBuscadorCliente("Ver");
                venPedidoCliente.Show();

            }
            if (cmbOpciones.SelectedIndex == 2)//Listar A partir del número de factura
            {

                wnwFacturasCliente nueva = new wnwFacturasCliente(Tipo: "Por factura", IdCliente: 0, IdFactura: Convert.ToInt32(txtNumeroFactura.Text));
                nueva.ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
