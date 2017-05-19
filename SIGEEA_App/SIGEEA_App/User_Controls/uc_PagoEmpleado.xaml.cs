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

namespace SIGEEA_App.User_Controls
{
    /// <summary>
    /// Interaction logic for uc_PagoEmpleado.xaml
    /// </summary>
    public partial class uc_PagoEmpleado : UserControl
    {
        public uc_PagoEmpleado()
        {
            InitializeComponent();
        }

        #region Propiedades de dependencia

        public static DependencyProperty IdPago = DependencyProperty.Register("IdPago", typeof(int), typeof(uc_PagoEmpleado),
                                                                              new UIPropertyMetadata(IdPagoAct));

        public static DependencyProperty Fecha = DependencyProperty.Register("Fecha", typeof(string), typeof(uc_PagoEmpleado),
                                                                            new UIPropertyMetadata(FechaAct));

        public static DependencyProperty Horas = DependencyProperty.Register("Horas", typeof(int), typeof(uc_PagoEmpleado),
                                                                             new UIPropertyMetadata(HorasAct));

        public static DependencyProperty Puesto = DependencyProperty.Register("Puesto", typeof(string), typeof(uc_PagoEmpleado),
                                                                              new UIPropertyMetadata(PuestoAct));

        public static DependencyProperty Tarifa = DependencyProperty.Register("Tarifa", typeof(string), typeof(uc_PagoEmpleado),
                                                                              new UIPropertyMetadata(TarifaAct));

        public static DependencyProperty Total = DependencyProperty.Register("Total", typeof(string), typeof(uc_PagoEmpleado),
                                                                             new UIPropertyMetadata(TotalAct));
        public static DependencyProperty eTotal = DependencyProperty.Register("eTotal", typeof(double), typeof(uc_PagoEmpleado),
                                                                              new UIPropertyMetadata(eTotalAct));

        public static DependencyProperty eTarifa = DependencyProperty.Register("eTarifa", typeof(double), typeof(uc_PagoEmpleado),
                                                                             new UIPropertyMetadata(eTarifaAct));

        #endregion

        #region Propiedades

        public int PagoId
        {
            get { return (int)GetValue(IdPago); }
            set { SetValue(IdPago, value); }
        }
        public double Totale
        {
            get { return (double)GetValue(eTotal); }
            set { SetValue(eTotal, value); }
        }
        public double Tarifae
        {
            get { return (double)GetValue(eTarifa); }
            set { SetValue(eTarifa, value); }
        }

        public string Fechas
        {
            get { return (string)GetValue(Fecha); }
            set { SetValue(Fecha, value); }
        }

        public int CantidadHoras
        {
            get { return (int)GetValue(Horas); }
            set { SetValue(Horas, value); }
        }

        public string Puestos
        {
            get { return (string)GetValue(Puesto); }
            set { SetValue(Puesto, value); }
        }

        public string Tarifas
        {
            get { return (string)GetValue(Tarifa); }
            set { SetValue(Tarifa, value); }
        }

        public string Totales
        {
            get { return (string)GetValue(Total); }
            set { SetValue(Total, value); }
        }

        public bool Marcado()
        {
            if (cbxCancelar.IsChecked == true) return true;
            else return false;
        }

        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (pColor == true) grdContenedor.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdContenedor.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }
        #endregion

        #region Métodos privados

        private static void IdPagoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_PagoEmpleado nPago = (uc_PagoEmpleado)d;
            nPago.PagoId = Convert.ToInt32(e.NewValue);
        }
        private static void eTotalAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_PagoEmpleado nPago = (uc_PagoEmpleado)d;
            nPago.Totale = Convert.ToDouble(e.NewValue);

        }
        private static void eTarifaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_PagoEmpleado nPago = (uc_PagoEmpleado)d;
            nPago.Tarifae = Convert.ToDouble(e.NewValue);

        }
        private static void FechaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_PagoEmpleado nPago = (uc_PagoEmpleado)d;
            nPago.Fechas = e.NewValue as string;
        }

        private static void HorasAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_PagoEmpleado nPago = (uc_PagoEmpleado)d;
            nPago.CantidadHoras = Convert.ToInt32(e.NewValue);
        }

        private static void PuestoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_PagoEmpleado nPago = (uc_PagoEmpleado)d;
            nPago.Puestos = e.NewValue as string;
        }

        private static void TarifaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_PagoEmpleado nPago = (uc_PagoEmpleado)d;
            nPago.Tarifas = e.NewValue as string;
        }

        private static void TotalAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_PagoEmpleado nPago = (uc_PagoEmpleado)d;
            nPago.Totales = e.NewValue as string;
        }
        #endregion
    }
}