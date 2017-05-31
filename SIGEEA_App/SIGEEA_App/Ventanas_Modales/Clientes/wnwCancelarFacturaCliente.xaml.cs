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
using SIGEEA_App.User_Controls.Clientes;
using SIGEEA_BL;
using SIGEEA_BO;
using System.Collections.ObjectModel;

namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwCancelarFacturaCliente.xaml
    /// </summary>
    public partial class wnwCancelarFacturaCliente : MetroWindow
    {
        public wnwCancelarFacturaCliente(int idFactura)
        {
            InitializeComponent();
           
        }
       
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void print(RichTextBox pFactura)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.Equals(true))
                {
                    printDialog.PrintDocument((((IDocumentPaginatorSource)pFactura.Document).DocumentPaginator), "Imprimiendo");
                }
            }
            catch
            {

            }
            
        }

    }
}

