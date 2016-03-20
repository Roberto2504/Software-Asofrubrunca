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

namespace SIGEEA_App.User_Controls.Asociados
{
    /// <summary>
    /// Interaction logic for uc_DeudorCuota.xaml
    /// </summary>
    public partial class uc_DeudorCuota : UserControl
    {
        public uc_DeudorCuota()
        {
            InitializeComponent();
        }

        #region Propiedades de dependencia

        public static DependencyProperty IdCuotaAsociado = DependencyProperty.Register("IdCuotaAsociado", typeof(int), typeof(uc_DeudorCuota),
                                                                             new UIPropertyMetadata(IdCuotaAsociadoAct));


        public static DependencyProperty PersonaNombre = DependencyProperty.Register("NombrePersona", typeof(string), typeof(uc_DeudorCuota),
                                                                             new UIPropertyMetadata(NombrePersonaAct));


        public static DependencyProperty PersonaCedula = DependencyProperty.Register("CedulaPersona", typeof(string), typeof(uc_DeudorCuota),
                                                                             new UIPropertyMetadata(CedulaPersonaAct));

        public static DependencyProperty CuotaMonto = DependencyProperty.Register("MontoCuota", typeof(string), typeof(uc_DeudorCuota),
                                                                             new UIPropertyMetadata(MontoCuotaAct));

        public static DependencyProperty PendienteSaldo = DependencyProperty.Register("SaldoPendiente", typeof(string), typeof(uc_DeudorCuota),
                                                                             new UIPropertyMetadata(SaldoPendienteAct));

        public static DependencyProperty CuotaNombre = DependencyProperty.Register("NombreCuota", typeof(string), typeof(uc_DeudorCuota),
                                                                             new UIPropertyMetadata(NombreCuotaAct));
        #endregion

        #region Propiedades

        public int CuotaAsociadoId
        {
            get { return (int)GetValue(IdCuotaAsociado); }
            set { SetValue(IdCuotaAsociado, value); }
        }

        public string NombrePersona
        {
            get { return (string)GetValue(PersonaNombre); }
            set { SetValue(PersonaNombre, value); }
        }

        public string CedulaPersona
        {
            get { return (string)GetValue(PersonaCedula); }
            set { SetValue(PersonaCedula, value); }
        }

        public string MontoCuota
        {
            get { return (string)GetValue(CuotaMonto); }
            set { SetValue(CuotaMonto, value); }
        }

        public string SaldoPendiente
        {
            get { return (string)GetValue(PendienteSaldo); }
            set { SetValue(PendienteSaldo, value); }
        }

        public string NombreCuota
        {
            get { return (string)GetValue(CuotaNombre); }
            set { SetValue(CuotaNombre, value); }
        }
        #endregion

        #region Métodos privados
        private static void IdCuotaAsociadoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DeudorCuota nDeudor = (uc_DeudorCuota)d;
            nDeudor.CuotaAsociadoId = Convert.ToInt32(e.NewValue);
        }

        private static void NombrePersonaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DeudorCuota nDeudor = (uc_DeudorCuota)d;
            nDeudor.NombrePersona = e.NewValue as string;
        }

        private static void CedulaPersonaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DeudorCuota nDeudor = (uc_DeudorCuota)d;
            nDeudor.CedulaPersona = e.NewValue as string;
        }

        private static void MontoCuotaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DeudorCuota nDeudor = (uc_DeudorCuota)d;
            nDeudor.MontoCuota = e.NewValue as string;
        }

        private static void SaldoPendienteAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DeudorCuota nDeudor = (uc_DeudorCuota)d;
            nDeudor.SaldoPendiente = e.NewValue as string;
        }

        private static void NombreCuotaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DeudorCuota nDeudor = (uc_DeudorCuota)d;
            nDeudor.NombreCuota = e.NewValue as string;
        }
        #endregion

        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (pColor == true) grdPrincipal.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdPrincipal.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }

        public void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            //Realiza el pago
        }
    }
}
