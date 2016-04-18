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

namespace SIGEEA_App.User_Controls.Asociados
{
    /// <summary>
    /// Interaction logic for uc_Cuota.xaml
    /// </summary>
    public partial class uc_Cuota : UserControl
    {
        public uc_Cuota()
        {
            InitializeComponent();
        }

        #region Propiedades de dependencia

        public static DependencyProperty IdCuota = DependencyProperty.Register("IdCuota", typeof(int), typeof(uc_Cuota),
                                                                             new UIPropertyMetadata(IdCuotaAct));


        public static DependencyProperty Nombre = DependencyProperty.Register("Nombre", typeof(string), typeof(uc_Cuota),
                                                                             new UIPropertyMetadata(NombreAct));


        public static DependencyProperty Monto = DependencyProperty.Register("Monto", typeof(string), typeof(uc_Cuota),
                                                                             new UIPropertyMetadata(MontoAct));

        public static DependencyProperty RangoFechas = DependencyProperty.Register("RangoFechas", typeof(string), typeof(uc_Cuota),
                                                                             new UIPropertyMetadata(RangoFechasAct));

        #endregion

        #region Propiedades

        public int CuotaId
        {
            get { return (int)GetValue(IdCuota); }
            set { SetValue(IdCuota, value); }
        }

        public string NombreCuota
        {
            get { return (string)GetValue(Nombre); }
            set { SetValue(Nombre, value); }
        }

        public string MontoCuota
        {
            get { return (string)GetValue(Monto); }
            set { SetValue(Monto, value); }
        }

        public string Rango
        {
            get { return (string)GetValue(RangoFechas); }
            set { SetValue(RangoFechas, value); }
        }
        #endregion


        #region Métodos privados
        private static void IdCuotaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cuota nCuota = (uc_Cuota)d;
            nCuota.CuotaId = Convert.ToInt32(e.NewValue);
        }

        private static void MontoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cuota nCuota = (uc_Cuota)d;
            nCuota.MontoCuota = e.NewValue as string;
        }

        private static void RangoFechasAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cuota nCuota = (uc_Cuota)d;
            nCuota.Rango = e.NewValue as string;
        }

        private static void NombreAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cuota nCuota = (uc_Cuota)d;
            nCuota.NombreCuota = e.NewValue as string;
        }

        #endregion

        public void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {

        }

        public int getIdCuota()
        {
            return this.CuotaId;
        }

        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (pColor == true) grdPrincipal.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdPrincipal.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarCuota ventana = new wnwRegistrarCuota(this.CuotaId);
            ventana.ShowDialog();
        }
    }
}
