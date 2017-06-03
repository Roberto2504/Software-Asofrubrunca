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
        bool editar = false;
        public wnwRegistrarProducto(string nomProducto = null)
        {
            InitializeComponent();

            if (nomProducto != null)
            {
                editar = true;
                SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
                SIGEEA_TipProducto ProdEditar = dc.SIGEEA_TipProductos.First(c => c.Nombre_TipProducto == nomProducto);
                txbNombre.Text = ProdEditar.Nombre_TipProducto;
                txbDescripcion.Text = ProdEditar.Descripcion_TipProducto;
                ucCalidad.NUDTextBox.Text = ProdEditar.Calidad_TipProducto.ToString();
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (txbDescripcion.Text != "" && txbNombre.Text != "")
            {
                try
                {
                    if (editar == false)
                    {
                        SIGEEA_TipProducto nuevoTipo = new SIGEEA_TipProducto();
                        nuevoTipo.Nombre_TipProducto = txbNombre.Text;
                        nuevoTipo.Calidad_TipProducto = Convert.ToInt32(ucCalidad.NUDTextBox.Text);
                        nuevoTipo.Descripcion_TipProducto = txbDescripcion.Text;
                        ProductoMantenimiento prodMantenimiento = new ProductoMantenimiento();
                        prodMantenimiento.RegistrarTipoProducto(nuevoTipo);
                        MessageBox.Show("El producto se ha registrado correctamente", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        SIGEEA_TipProducto editarTipo = new SIGEEA_TipProducto();
                        editarTipo.Nombre_TipProducto = txbNombre.Text;
                        editarTipo.Calidad_TipProducto = Convert.ToInt32(ucCalidad.NUDTextBox.Text);
                        editarTipo.Descripcion_TipProducto = txbDescripcion.Text;
                        ProductoMantenimiento prodMantenimiento = new ProductoMantenimiento();
                        prodMantenimiento.ModificarTipoProducto(editarTipo);
                        this.Close();
                    }

                    MessageBox.Show("El producto se ha modificado con éxito", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violation of UNIQUE KEY constraint 'UK_SIGEEA_TipProducto'"))
                        MessageBox.Show("Error: el nombre que intenta guardar, ya se encuentra registrado en el sistema.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Error: " + ex.Message + ". Contacte al administrador del sistema.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos");
            }
        }
    }
}
