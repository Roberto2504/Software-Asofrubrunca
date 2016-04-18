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

namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Interaction logic for wnwBuscadorCliente.xaml
    /// </summary>
    public partial class wnwBuscadorCliente : MetroWindow
    {
        public wnwBuscadorCliente(string tipo)
        {
            InitializeComponent();
            uc_ContenedorClientes nuevo = new uc_ContenedorClientes(pOpcion: tipo);
            grdContenedorClientes.Children.Add(nuevo);
        }

    }
}
