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
using SIGEEA_BO;
using SIGEEA_BL.Validaciones;

namespace SIGEEA_App.User_Controls.Productos
{
    /// Interaction logic for uc_ItemEntrega.xaml
    /// <summary>
    /// </summary>
    public partial class uc_ItemEntrega : UserControl
    {
        int PK_Detalle;
        double cantidad;
        public int producto;
        public uc_ItemEntrega(string Informacion, int pkDetalle, int pkProducto)
        {
            InitializeComponent();
            lblInformacion.Text = Informacion;
            PK_Detalle = pkDetalle;
            producto = pkProducto;
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_DetFacAsociado detalle = dc.SIGEEA_DetFacAsociados.First(c => c.PK_Id_DetFacAsociado == pkDetalle);
            cantidad = detalle.CanTotal_DetFacAsociado;
            if (detalle.CanNeta_DetFacAsociado > -1)
            {
                txbCantidadNeta.Text = detalle.CanNeta_DetFacAsociado.ToString();
                txbCantidadNeta.IsEnabled = false;
            }
        }

        public bool getEstado()
        {
            if (txbCantidadNeta.IsEnabled == true) return true;
            else return false;
        }
        public int getId()
        {
            return this.PK_Detalle;
        }

        public bool Valida()
        {
            ValidacionesMantenimiento validacion = new ValidacionesMantenimiento();
            if (txbCantidadNeta.Text == string.Empty) txbCantidadNeta.Text = 0.ToString();

            if (validacion.Validar(txbCantidadNeta.Text, 1) == true && this.cantidad >= Convert.ToDouble(txbCantidadNeta.Text)) return true;
            else return false;
        }
        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (pColor == true) grdContenedor.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdContenedor.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }
    }
}
