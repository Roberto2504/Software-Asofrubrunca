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

namespace SIGEEA_App.User_Controls.Productos
{
    /// <summary>
    /// Interaction logic for uc_ItemDetallePagoAsoc.xaml
    /// </summary>
    public partial class uc_ItemDetallePagoAsoc : UserControl
    {

        public uc_ItemDetallePagoAsoc()
        {
            InitializeComponent();
        }
        public uc_ItemDetallePagoAsoc(SIGEEA_spObtenerDetallesFacturaSinCancelarAsocResult pDetalleFactura, bool pColor)
        {
            InitializeComponent();
            this.PkDetalleFactura = pDetalleFactura.PK_Id_DetFacAsociado;
            this.InformacionDet = pDetalleFactura.canNeta + pDetalleFactura.Informacion;
            this.PrecioDet = pDetalleFactura.Precio;
            this.TotalDet = pDetalleFactura.Saldo;
            this.Color(pColor);
            this.Abono = false;
        }

        public bool Abono;
        public float Monto;
        public bool Seleccionado()
        {
            if (cbxCambioVista.IsChecked == true) return true;
            else return false;
        }
        #region Propiedades de dependencia
        public static DependencyProperty IdDetalleFactura = DependencyProperty.Register("IdDetalleFactura", typeof(int), typeof(uc_FacturaEntrega),
                                                                             new UIPropertyMetadata(IdDetalleFacturaAct));

        public static DependencyProperty Informacion = DependencyProperty.Register("Informacion", typeof(string), typeof(uc_FacturaEntrega),
                                                                             new UIPropertyMetadata(InformacionAct));

        public static DependencyProperty Precio = DependencyProperty.Register("Precio", typeof(string), typeof(uc_FacturaEntrega),
                                                                             new UIPropertyMetadata(PrecioAct));
        public static DependencyProperty Total = DependencyProperty.Register("Total", typeof(string), typeof(uc_FacturaEntrega),
                                                                             new UIPropertyMetadata(TotalAct));
        #endregion

        #region Propiedades
        public int PkDetalleFactura
        {
            get { return (int)GetValue(IdDetalleFactura); }
            set { SetValue(IdDetalleFactura, value); }
        }

        public string InformacionDet
        {
            get { return (string)GetValue(Informacion); }
            set { SetValue(Informacion, value); }
        }

        public string PrecioDet
        {
            get { return (string)GetValue(Precio); }
            set { SetValue(Precio, value); }
        }

        public string TotalDet
        {
            get { return (string)GetValue(Total); }
            set { SetValue(Total, value); }
        }

        #endregion

        #region Métodos privados
        private static void IdDetalleFacturaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_FacturaEntrega nAsociado = (uc_FacturaEntrega)d;
            nAsociado.FacturaId = Convert.ToInt32(e.NewValue);
        }
        private static void InformacionAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_FacturaEntrega nAsociado = (uc_FacturaEntrega)d;
            nAsociado.FacturaFecha = e.NewValue as string;
        }

        private static void PrecioAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_FacturaEntrega nAsociado = (uc_FacturaEntrega)d;
            nAsociado.FacturaCantidad = e.NewValue as string;
        }

        private static void TotalAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_FacturaEntrega nAsociado = (uc_FacturaEntrega)d;
            nAsociado.FacturaUnidad = e.NewValue as string;
        }
        #endregion

        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (pColor == true) grdContenedor.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdContenedor.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }

        private void cbxCambioVista_Checked(object sender, RoutedEventArgs e)
        {
            lblTotal.Visibility = Visibility.Collapsed;
            txbMonto.Visibility = Visibility.Visible;
            cbxSeleccionar.IsChecked = true;
            cbxSeleccionar.IsEnabled = false;
            Abono = true;
        }

        private void cbxCambioVista_Unchecked(object sender, RoutedEventArgs e)
        {
            lblTotal.Visibility = Visibility.Visible;
            txbMonto.Visibility = Visibility.Collapsed;
            cbxSeleccionar.IsChecked = false;
            cbxSeleccionar.IsEnabled = true;
            Abono = false;
            txbMonto.Text = String.Empty;
        }
    }
}
