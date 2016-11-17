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
using SIGEEA_App.User_Controls.Insumos;
using SIGEEA_BL.Seguridad;

namespace SIGEEA_App.Ventanas_Modales.Insumos
{
    /// <summary>
    /// Interaction logic for wmwCompraInsumo.xaml
    /// </summary>
    public partial class wmwCompraInsumo : Window
    {
        public wmwCompraInsumo()
        {
            InitializeComponent();
        }
        InsumoMantenimiento mantInsumo = new InsumoMantenimiento();
        List<SIGEEA_spListarInsumosResult> LisInsumo = new List<SIGEEA_spListarInsumosResult>();
        double resultado;
        double total;
        public void Cargar()
        {
            try
            {
                LisInsumo.Clear();
                List<String> nombres = new List<String>();
                nombres.Clear();
                bool entro = false;
                    if (txtBuscar.Text == "")
                    {
                    LisInsumo = mantInsumo.ListarInsumos("");
                    }
                    else
                    {
                    
                    LisInsumo = mantInsumo.ListarInsumos(txtBuscar.Text);
                    }
                    Limpiar();
                    foreach (ucCompraInsumo pInsumo in FindVisualChildren<ucCompraInsumo>(stpInsumos))
                    {
                        nombres.Add(pInsumo.txtDescripcion.Text);
                    }

                    foreach (SIGEEA_spListarInsumosResult result in LisInsumo)
                    {

                        entro = false;
                        foreach (string nombre in nombres)
                        {
                            if (nombre == result.Descripcion_Insumo)
                            {

                                entro = true;
                            }
                        }
                        if (entro == false)
                        {
                            ucCompraInsumo nuevo = new ucCompraInsumo();
                            nuevo.txtNombre.Text = result.Nombre_Insumo;
                            nuevo.txtDisponibles.Text = result.Cantidad_InvInsumo + " " + result.Nombre_UniMedida;
                            nuevo.txtNombre.Tag = result.PK_IdInvInsumo;
                            nuevo.txtDisponibles.Tag = result.PK_Id_Insumo;
                            nuevo.txtDescripcion.Text = result.Descripcion_Insumo;
                            CargarUniMedida(nuevo, result.Nombre_UniMedida);

                        nuevo.txtUMedida.Text = result.Nombre_UniMedida;
                        nuevo.txtCantidad.TextChanged += TxtCantidad_TextChanged;
                            nuevo.txtPrecioUnidad.TextChanged += TxtPrecioUnidad_TextChanged;
                            stpInsumos.Children.Add(nuevo);
                        }
                    }

                
                




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Error");
                
            }
        }

        private void TxtPrecioUnidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            total = 0;
            foreach (ucCompraInsumo pInsumo in FindVisualChildren<ucCompraInsumo>(stpInsumos))
            {
                if (pInsumo.txtTotal.Text != "")
                {
                    total += Convert.ToDouble(pInsumo.txtTotal.Text.Remove(0, 2));
                }
            }
            txtTotal.Text = "₡ " + SepararMiles((Math.Round(total))).ToString();
        }
        public string SepararMiles(double Cantidad)
        {
            return Cantidad.ToString("N2");
        }
        private void TxtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            total = 0;
            foreach (ucCompraInsumo pInsumo in FindVisualChildren<ucCompraInsumo>(stpInsumos))
            {
                if (pInsumo.txtTotal.Text != "")
                {
                    total += Convert.ToDouble(pInsumo.txtTotal.Text.Remove(0, 2));
                }
            }
            txtTotal.Text = "₡ " + SepararMiles((Math.Round(total))).ToString();
        }

        public ucCompraInsumo CargarUniMedida(ucCompraInsumo insumo, string UMedida)
        {
            if (UMedida == "Uni")
            {
                insumo.cmbUMedida.Items.Add("Uni");
            }
            else if (UMedida == "Li")
            {
                insumo.cmbUMedida.Items.Add("Li");
                insumo.cmbUMedida.Items.Add("Ml");
                insumo.cmbUMedida.Items.Add("Oz");
            }
            else if (UMedida == "Ml")
            {
                insumo.cmbUMedida.Items.Add("Li");
                insumo.cmbUMedida.Items.Add("Ml");
                insumo.cmbUMedida.Items.Add("Oz");
            }
            else if (UMedida == "Oz")
            {
                insumo.cmbUMedida.Items.Add("Li");
                insumo.cmbUMedida.Items.Add("Ml");
                insumo.cmbUMedida.Items.Add("Oz");
            }
            else if (UMedida == "Kg")
            {
                insumo.cmbUMedida.Items.Add("Kg");
                insumo.cmbUMedida.Items.Add("Gr");
            }
            else if (UMedida == "Gr")
            {
                insumo.cmbUMedida.Items.Add("Kg");
                insumo.cmbUMedida.Items.Add("Gr");
            }
            insumo.cmbUMedida.SelectedIndex = 0;
            return insumo;
        }
        public void Limpiar()
        {
            bool entro = true;
            while (entro == true)
            {
                int conta = 0;
                foreach (ucCompraInsumo pInsumo in FindVisualChildren<ucCompraInsumo>(stpInsumos))
                {
                    if (pInsumo.txtCantidad.Text == "" && pInsumo.txtPrecioUnidad.Text == "")
                    {
                        stpInsumos.Children.Remove(pInsumo);
                        entro = true;
                    }
                    else
                    {
                        entro = false;
                    }
                    conta = 1;
                }
                if (conta == 0) entro = false;
            }
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
                {
                    if (depObj != null)
                    {
                        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                        {
                            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                            if (child != null && child is T)
                            {
                                yield return (T)child;
                            }

                            foreach (T childOfChild in FindVisualChildren<T>(child))
                            {
                                yield return childOfChild;
                            }
                        }
                    }
                }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPedir_Click(object sender, RoutedEventArgs e)
        {
            if (txtDetalle.Text != "")
            {
                bool entro = false;
                foreach (ucCompraInsumo pInsumo in FindVisualChildren<ucCompraInsumo>(stpInsumos))
                {
                    if (pInsumo.txtCantidad.Text != "" && pInsumo.txtPrecioUnidad.Text != "")
                    {
                        entro = true;
                    }
                }
                if (entro == true)
                {
                    SIGEEA_FacInsumo factura = new SIGEEA_FacInsumo();
                    factura.Descripcion_FacInsumo = txtDetalle.Text;
                    factura.Estado_FacInsumo = true;
                    factura.Fecha_FacInsumo = DateTime.Now;
                    factura.FK_Id_Empleado = UsuarioGlobal.InfoUsuario.PK_Id_Empleado;
                    factura.MonTotal_FacInsumo = Convert.ToDouble(txtTotal.Text.Remove(0, 2));
                    if (cbEfectivo.IsChecked == true)
                    {
                        factura.Credito_FacInsumo = false;
                    }
                    else
                    {
                        factura.Credito_FacInsumo = true;
                    }
                    SIGEEA_FacInsumo nuevo = mantInsumo.AgregarFactura(factura);
                    foreach (ucCompraInsumo pInsumo in FindVisualChildren<ucCompraInsumo>(stpInsumos))
                    {
                        if (pInsumo.txtCantidad.Text != "" && pInsumo.txtPrecioUnidad.Text != "")
                        {
                            SIGEEA_DetFacInsumo nuevoDetalle = new SIGEEA_DetFacInsumo();
                            nuevoDetalle.Precio_DetFacInsumo = Convert.ToDouble(pInsumo.txtPrecioUnidad.Text);
                            nuevoDetalle.Cantidad_DetFacInsumo = Convert.ToDouble(pInsumo.txtCantidad.Text) / (Convertir(pInsumo.txtUMedida.Text, pInsumo.cmbUMedida.SelectedItem.ToString()));
                            nuevoDetalle.FK_Id_InvInsumo = Convert.ToInt32(pInsumo.txtNombre.Tag);
                            nuevoDetalle.FK_Id_FacInsumo = nuevo.PK_Id_FacInsumo;
                            mantInsumo.AgregarDetalleFactura(nuevoDetalle);

                            mantInsumo.SumarInventario(Convert.ToInt32(pInsumo.txtDisponibles.Tag),nuevoDetalle.Cantidad_DetFacInsumo);

                        }
                    }
                    MessageBox.Show("La compra se ha realizado exitosamente.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe agregar al menos un detalle de la compra.");
                }

            }
            else
            {
                MessageBox.Show("Debe agregar una descripción.");
               
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
        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Cargar();
        }
        private void cbCredito_Checked(object sender, RoutedEventArgs e)
        {
            if (cbCredito.IsChecked == true)
            {
                cbEfectivo.IsChecked = false;
            }
            else
            {
                cbEfectivo.IsChecked = true;
            }
        }

        private void cbEfectivo_Checked(object sender, RoutedEventArgs e)
        {
            if (cbEfectivo.IsChecked == true)
            {
                cbCredito.IsChecked = false;
            }
            else
            {
                cbCredito.IsChecked = true;
            }
        }
    }
}
