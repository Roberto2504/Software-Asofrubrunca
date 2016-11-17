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
        int conta = 0;
        int conta1 = 0;
        public wnwRegistrarInsumo(string ptipo, int ppkInsumo)
        {
            InitializeComponent();
            tipo = ptipo;
            pkInsumo = ppkInsumo;
            cbxUnidadesDeMedida.ItemsSource = MantUnidades.listarUnidades();
            if(tipo == "Editar")
            {
                cargarInfo();
            }
        }
        string tipo;
        int pkInsumo;
        public void cargarInfo()
        {
            SIGEEA_spObtenerInsumoResult insumo = MantInsumo.ObtenerInsumo(pkInsumo);
            cbxUnidadesDeMedida.Text = insumo.Nombre_UniMedida;
            txtCantidad.Text = insumo.Cantidad_InvInsumo.ToString();
            txtNombre.Text = insumo.Nombre_Insumo;
            txtDescripcion.Text = insumo.Descripcion_Insumo;
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
                {
                if (tipo == "Editar")
                {
                    SIGEEA_Insumo nuevoInsumo = new SIGEEA_Insumo();
                    nuevoInsumo.Nombre_Insumo = txtNombre.Text;
                    nuevoInsumo.Descripcion_Insumo = txtDescripcion.Text;
                    nuevoInsumo.Estado_Insumo = true;
                    nuevoInsumo.PK_Id_Insumo = pkInsumo;
                    SIGEEA_InvInsumo inv = new SIGEEA_InvInsumo();
                    inv.Cantidad_InvInsumo = Convert.ToDouble(txtCantidad.Text);
                    MantInsumo.ModificarInsumo(nuevoInsumo,  inv, cbxUnidadesDeMedida.Text);
                    MessageBox.Show("Editado correctamente");

                }
                else
                {
                    SIGEEA_Insumo nuevoInsumo = new SIGEEA_Insumo();
                    nuevoInsumo.Nombre_Insumo = txtNombre.Text;
                    nuevoInsumo.Descripcion_Insumo = txtDescripcion.Text;
                    nuevoInsumo.Estado_Insumo = true;
                    MantInsumo.RegistrarInsumo(nuevoInsumo, cbxUnidadesDeMedida.Text, txtCantidad.Text);
                    MessageBox.Show("Registrado correctamente");
                }
                this.Close();

                    }
            catch
            {
                MessageBox.Show("Error al registrar");
            }
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCantidad.Text = cbxUnidadesDeMedida.Text;
        }

        private void txtCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
            if (e.Text == "," && conta == 0 && txtCantidad.Text != "")
            {
                e.Handled = false;
                conta1 = 1;
            }
        }

        private void txtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool entro = false;
            for (int i = 0; i < txtCantidad.Text.Length; i++)
            {
                if (txtCantidad.Text[i] == ',')
                {
                    entro = true;
                }
            }
            if (entro == true)
            {
                conta = 1;
            }
            else conta = 0;
            
        }
    }
}
