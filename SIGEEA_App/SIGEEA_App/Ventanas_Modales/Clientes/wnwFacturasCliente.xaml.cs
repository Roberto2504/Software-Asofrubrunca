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
using SIGEEA_App.User_Controls.Clientes;

namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwFacturasCliente.xaml
    /// </summary>
    public partial class wnwFacturasCliente : MetroWindow
    {
        public wnwFacturasCliente(string Tipo, int IdCliente, int IdFactura)
        {
            InitializeComponent();

            uc_ContenedorFacturas contenedor = new uc_ContenedorFacturas(pidFactura: IdFactura, pidCliente: IdCliente, pTipo: Tipo);
            stkPrincipal.Children.Add(contenedor);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
