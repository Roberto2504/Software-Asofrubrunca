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
    /// Interaction logic for wnwRegistrarProducto.xaml
    /// </summary>
    public partial class wnwRegistrarProducto : MetroWindow
    {
        public wnwRegistrarProducto()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            SIGEEA_TipProducto nuevoTipo = new SIGEEA_TipProducto();
            nuevoTipo.Nombre_TipProducto = txbNombre.Text;
            nuevoTipo.Calidad_TipProducto = Convert.ToInt32(ucCalidad.NUDTextBox.Text);
            nuevoTipo.Descripcion_TipProducto = txbDescripcion.Text;
            ProductoMantenimiento prodMantenimiento = new ProductoMantenimiento();
            prodMantenimiento.RegistrarTipoProducto(nuevoTipo);
        }
    }
}
