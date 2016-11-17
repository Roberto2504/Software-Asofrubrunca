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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIGEEA_App.User_Controls.Insumos
{
    /// <summary>
    /// Interaction logic for ucCompraInsumo.xaml
    /// </summary>
    public partial class ucCompraInsumo : UserControl
    {
        public ucCompraInsumo()
        {
            InitializeComponent();
        }

        
        int conta = 0;
        int conta1 = 0;
        private void txtCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
            if (e.Text == "," && conta == 0 && txtCantidad.Text != "")
            {
                e.Handled = false;
                conta = 1;
            }
        }

        private void txtPrecioUnidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
            if(txtPrecioUnidad.Text != "" && txtCantidad.Text !="")
            {
                txtTotal.Text = "₡ " + SepararMiles((Math.Round(Convert.ToDouble(txtPrecioUnidad.Text) * Convert.ToDouble(txtCantidad.Text), 2))).ToString();
            }
            else
            {
                txtTotal.Text = "₡ 0";
            }
            
        }
        public string SepararMiles(double Cantidad)
        {
            return Cantidad.ToString("N2");
        }
        private void txtPrecioUnidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool entro = false;
            for (int i = 0; i < txtPrecioUnidad.Text.Length; i++)
            {
                if (txtPrecioUnidad.Text[i] == ',')
                {
                    entro = true;
                }
            }
            if (entro == true)
            {
                conta = 1;
            }
            else conta = 0;
            double total;
            if (txtPrecioUnidad.Text != "" && txtCantidad.Text != "")
            {
                total = Convert.ToDouble(txtPrecioUnidad.Text) * Convert.ToDouble(txtCantidad.Text);
                txtTotal.Text = "₡ " + SepararMiles((Math.Round(total,2)));
            }
            else
            {
                txtTotal.Text = "₡ 0";
            }
        }
    }
}
