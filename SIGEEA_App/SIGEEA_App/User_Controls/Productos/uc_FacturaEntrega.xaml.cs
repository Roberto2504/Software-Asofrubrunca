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
using SIGEEA_App.Ventanas_Modales.Asociados;

namespace SIGEEA_App.User_Controls.Productos
{
    /// <summary>
    /// Interaction logic for uc_FacturaEntrega.xaml
    /// </summary>
    public partial class uc_FacturaEntrega : UserControl
    {
        bool Solicitud = true;
        public uc_FacturaEntrega(bool pSolicitud)
        {
            InitializeComponent();
            Solicitud = pSolicitud;
        }

        #region Propiedades de dependencia
        public static DependencyProperty IdFactura = DependencyProperty.Register("IdFactura", typeof(int), typeof(uc_FacturaEntrega),
                                                                             new UIPropertyMetadata(IdFacturaAct));

        public static DependencyProperty NumFactura = DependencyProperty.Register("NumFactura", typeof(int), typeof(uc_FacturaEntrega),
                                                                             new UIPropertyMetadata(NumFacturaAct));

        public static DependencyProperty FechaFactura = DependencyProperty.Register("FechaFactura", typeof(string), typeof(uc_FacturaEntrega),
                                                                             new UIPropertyMetadata(FechaFacturaAct));

        public static DependencyProperty CantidadFactura = DependencyProperty.Register("CantidadFactura", typeof(string), typeof(uc_FacturaEntrega),
                                                                             new UIPropertyMetadata(CantidadFacturaAct));
        public static DependencyProperty UnidadFactura = DependencyProperty.Register("UnidadFactura", typeof(string), typeof(uc_FacturaEntrega),
                                                                             new UIPropertyMetadata(UnidadFacturaAct));
        #endregion

        #region Propiedades
        public int FacturaId
        {
            get { return (int)GetValue(IdFactura); }
            set { SetValue(IdFactura, value); }
        }

        public int FacturaNum
        {
            get { return (int)GetValue(NumFactura); }
            set { SetValue(NumFactura, value); }
        }

        public string FacturaFecha
        {
            get { return (string)GetValue(FechaFactura); }
            set { SetValue(FechaFactura, value); }
        }

        public string FacturaCantidad
        {
            get { return (string)GetValue(CantidadFactura); }
            set { SetValue(CantidadFactura, value); }
        }

        public string FacturaUnidad
        {
            get { return (string)GetValue(UnidadFactura); }
            set { SetValue(UnidadFactura, value); }
        }

        #endregion

        #region Métodos privados
        private static void IdFacturaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_FacturaEntrega nAsociado = (uc_FacturaEntrega)d;
            nAsociado.FacturaId = Convert.ToInt32(e.NewValue);
        }

        private static void NumFacturaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_FacturaEntrega nAsociado = (uc_FacturaEntrega)d;
            nAsociado.FacturaNum = Convert.ToInt32(e.NewValue);
        }
        private static void FechaFacturaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_FacturaEntrega nAsociado = (uc_FacturaEntrega)d;
            nAsociado.FacturaFecha = e.NewValue as string;
        }

        private static void CantidadFacturaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_FacturaEntrega nAsociado = (uc_FacturaEntrega)d;
            nAsociado.FacturaCantidad = e.NewValue as string;
        }

        private static void UnidadFacturaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
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
        private void btnDetalles_Click(object sender, RoutedEventArgs e)
        {
            if (Solicitud == false)//Facturas incompletas
            {
                wnwCompletaEntrega ventana = new wnwCompletaEntrega(this.FacturaId);
                ventana.ShowDialog();
            }
            else//Facturas pendientes de pago
            {
                wnwFacturasPendientesPago ventana = new wnwFacturasPendientesPago(this.FacturaId);
                ventana.ShowDialog();
            }
        }
    }
}