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

using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_App.User_Controls.Asociados;

namespace SIGEEA_App.User_Controls.Productos
{
    /// <summary>
    /// Interaction logic for uc_IngresoProducto.xaml
    /// </summary>
    public partial class uc_IngresoProducto : UserControl
    {
        List<SIGEEA_TipProducto> listaProductos;
        
        public uc_IngresoProducto(string pAsociado)
        {
            InitializeComponent();
            cmbMercado.Items.Add("Nacional");
            cmbMercado.Items.Add("Extranjero");
            DataClasses1DataContext dc = new DataClasses1DataContext();
            listaProductos = dc.SIGEEA_TipProductos.ToList();
            

            foreach (SIGEEA_TipProducto p in listaProductos) cmbProducto.Items.Add(p.Nombre_TipProducto);

            uc_FincaLote uControl = new uc_FincaLote(pAsociado);
            grdFincaLote.Children.Add(uControl);
        }

        public int getProducto()
        {
            int pkProducto = 0;
            foreach (SIGEEA_TipProducto p in listaProductos)
            {
                if (p.Nombre_TipProducto == (string)cmbProducto.SelectedValue)
                    pkProducto = p.PK_Id_TipProducto;
            }
            return pkProducto;
        }

        public int getMercado()
        {
            if ((string)cmbMercado.SelectedValue == "Nacional")
                return 1;
            else if ((string)cmbMercado.SelectedValue == "Extranjero")
                return 2;
            else
                return 0;
        }

        public int getLote()
        {
            int pkLote = 0;
            foreach (uc_FincaLote l in grdFincaLote.Children)
            {
                pkLote = l.getLote();
            }
            return pkLote;
        }

        public double getCantidad()
        {
            return Convert.ToDouble(txbCantidadTotal.Text);
        }

    }
}
