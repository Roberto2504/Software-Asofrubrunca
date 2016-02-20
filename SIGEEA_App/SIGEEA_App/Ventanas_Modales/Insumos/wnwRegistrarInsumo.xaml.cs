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
using SIGEEA_BL;
using SIGEEA_BO;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace SIGEEA_App.Ventanas_Modales.Insumos
{
    /// <summary>
    /// Interaction logic for wnwRegistrarInsumo.xaml
    /// </summary>
    public partial class wnwRegistrarInsumo : MetroWindow
    {
        UnidadMedidaMantenimiento MantUnidades = new UnidadMedidaMantenimiento();
        InsumoMantenimiento MantInsumo = new InsumoMantenimiento();
        public wnwRegistrarInsumo()
        {
            InitializeComponent();
            cbxUnidadesDeMedida.ItemsSource = MantUnidades.listarUnidades();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
                {
                SIGEEA_Insumo nuevoInsumo = new SIGEEA_Insumo();
                nuevoInsumo.Nombre_Insumo = txtNombre.Text;
                nuevoInsumo.Descripcion_Insumo = txtDescripcion.Text;
                nuevoInsumo.Estado_Insumo = true;
                MantInsumo.RegistrarInsumo(nuevoInsumo,cbxUnidadesDeMedida.Text,txtCantidad.Text);

                    }
            catch
            {
                MessageBox.Show("Que madre no Registro");
            }
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCantidad.Text = cbxUnidadesDeMedida.Text;
        }

        
    }
}
