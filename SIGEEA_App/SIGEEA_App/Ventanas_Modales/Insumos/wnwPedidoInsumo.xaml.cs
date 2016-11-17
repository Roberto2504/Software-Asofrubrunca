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
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_BL.Seguridad;
namespace SIGEEA_App.Ventanas_Modales.Insumos
{
    /// <summary>
    /// Interaction logic for wnwPedidoInsumo.xaml
    /// </summary>
    public partial class wnwPedidoInsumo : MetroWindow
    {
        public wnwPedidoInsumo(SIGEEA_spListarInsumosResult pinsumo)
        {
            InitializeComponent();
            
            ucPedido.NUDTextBox.TextChanged += NUDTextBox_TextChanged;
            insumo = pinsumo;
            Cargar();
        }

  

        int conta = 0;
        int conta1 = 0;
        string cantidad;
        string canAnterior;
        double resultado;
        SIGEEA_spListarInsumosResult insumo = new SIGEEA_spListarInsumosResult();
        public void Cargar()
        {
            if(insumo != null)
            {
                txtDescripcion.Text = insumo.Descripcion_Insumo;
                txtNombre.Text = insumo.Nombre_Insumo;
                txtDisponible.Text = insumo.Cantidad_InvInsumo + Convert.ToString(" " + insumo.Nombre_UniMedida);
                canAnterior = insumo.Cantidad_InvInsumo.ToString();
                CargarUniMedida(insumo.Nombre_UniMedida);
            }
        }
        private void NUDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calcular();
        }
        public void Calcular()
        {
            if (ucPedido.NUDTextBox.Text != "")
            {
                if ((Convert.ToDouble(ucPedido.NUDTextBox.Text) / Convertir(insumo.Nombre_UniMedida, cmbUMedida.SelectedItem.ToString())) <= Convert.ToDouble(canAnterior))
                {
                    cantidad = ((Convert.ToDouble(canAnterior)) - (Convert.ToDouble(ucPedido.NUDTextBox.Text) / Convertir(insumo.Nombre_UniMedida, cmbUMedida.SelectedItem.ToString()))).ToString();
                    txtDisponible.Text = string.Concat(cantidad, insumo.Nombre_UniMedida);
                }
                else
                {
                    MessageBox.Show("El pedido excede la cantidad disponible");
                    txtDisponible.Text = insumo.Cantidad_InvInsumo + Convert.ToString(" " + insumo.Nombre_UniMedida);
                    canAnterior = insumo.Cantidad_InvInsumo.ToString();
                    ucPedido.NUDTextBox.Text = "";
                }
            }
            else
            {
                txtDisponible.Text = insumo.Cantidad_InvInsumo + Convert.ToString(" " + insumo.Nombre_UniMedida);
                canAnterior = insumo.Cantidad_InvInsumo.ToString();
            }
        }
        public double Convertir(string tipo, string tipo2)
        {

            if (tipo == "Li" && tipo2 == "Oz")
            {
                resultado = 33.814022701271305;
            }
            if (tipo == "Li" && tipo2 == "Li")
            {
                resultado = 1;
            }
            else if (tipo == "Li" && tipo2 == "Ml")
            {
                resultado = 1000;
            }
            else if (tipo == "Oz" && tipo2 == "Li")
            {
                resultado = 0.29573529563000002;
            }
            else if (tipo == "Oz" && tipo2 == "Oz")
            {
                resultado = 1;
            }
            else if (tipo == "Oz" && tipo2 == "Ml")
            {
                resultado = 29.573529563000002;
            }
            else if (tipo == "Kg" && tipo2 == "Gr")
            {
                resultado = 1000;
            }
            else if (tipo == "Kg" && tipo2 == "Kg")
            {
                resultado = 1;
            }
            else if (tipo == "Gr" && tipo2 == "Kg")
            {
                resultado = 0.001;
            }
            else if (tipo == "Gr" && tipo2 == "Gr")
            {
                resultado = 1;
            }
            else if (tipo == "Ml" && tipo2 == "Li")
            {
                resultado = 0.001;
            }
            else if (tipo == "Ml" && tipo2 == "Ml")
            {
                resultado = 1;
            }
            else if (tipo == "Ml" && tipo2 == "Oz")
            {
                resultado = 0.029573529563000002;
            }
            else if (tipo == "Uni" && tipo2 == "Uni")
            {
                resultado = 1;
            }
            return resultado;
        }
        public void CargarUniMedida(string UMedida)
        {
            if (UMedida == "Uni")
            {
                cmbUMedida.Items.Add("Uni");
            }
            else if (UMedida == "Li")
            {
                cmbUMedida.Items.Add("Li");
                cmbUMedida.Items.Add("Ml");
                cmbUMedida.Items.Add("Oz");
            }
            else if (UMedida == "Ml")
            {
               cmbUMedida.Items.Add("Li");
               cmbUMedida.Items.Add("Ml");
               cmbUMedida.Items.Add("Oz");
            }
            else if (UMedida == "Oz")
            {
                cmbUMedida.Items.Add("Li");
                cmbUMedida.Items.Add("Ml");
                cmbUMedida.Items.Add("Oz");
            }
            else if (UMedida == "Kg")
            {
                cmbUMedida.Items.Add("Kg");
                cmbUMedida.Items.Add("Gr");
            }
            else if (UMedida == "Gr")
            {
                cmbUMedida.Items.Add("Kg");
                cmbUMedida.Items.Add("Gr");
            }
            cmbUMedida.SelectedIndex = 0;
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPedir_Click(object sender, RoutedEventArgs e)
        {
            if(txtDetalle.Text != "")
            {
                if (ucPedido.NUDTextBox.Text != "" && ucPedido.NUDTextBox.Text != "0") {

                    SIGEEA_PedInsumo pedInsumo = new SIGEEA_PedInsumo();
                    pedInsumo.Descripcion_PedInsumo = txtDetalle.Text;
                    pedInsumo.Cantidad_PedInsumo = (Convert.ToDouble(ucPedido.NUDTextBox.Text) / Convertir(insumo.Nombre_UniMedida, cmbUMedida.SelectedItem.ToString()));
                    pedInsumo.Estado_Insumo = true;
                    pedInsumo.Fecha_PedInsumo = DateTime.Now;
                    pedInsumo.FK_Id_Empleado = UsuarioGlobal.InfoUsuario.PK_Id_Empleado;
                    pedInsumo.FK_Id_Insumo = insumo.PK_Id_Insumo;
                    InsumoMantenimiento mantInsumo = new InsumoMantenimiento();
                    mantInsumo.PedidoInsumo(pedInsumo);
                    mantInsumo.RestarInventario(insumo.PK_Id_Insumo, pedInsumo.Cantidad_PedInsumo);
                    MessageBox.Show("Se ha realizado el pedido perfectamente.");
                    this.Close();
                }else
                {
                    MessageBox.Show("Debe agregar una cantidad al pedido.");
                }
                
            }
            else
            {
                MessageBox.Show("Debe agregar un detalle al pedido.");
            }
        }

        private void cmbUMedida_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Calcular();
        }
    }
}
