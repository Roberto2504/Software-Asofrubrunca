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
    /// Interaction logic for uc_Asamblea.xaml
    /// </summary>
    public partial class uc_Asamblea : UserControl
    {
        public uc_Asamblea(int pId, string pFecha, string pTipo, string pActa)
        {
            InitializeComponent();
            this.AsambleaId = pId;
            this.AsambleaFecha = pFecha;
            this.AsambleaTipo = pTipo;
            this.AsambleaActa = pActa;
        }

        #region Propiedades de dependencia

        public static DependencyProperty IdAsamblea = DependencyProperty.Register("IdAsamblea", typeof(int), typeof(uc_Asamblea),
                                                                             new UIPropertyMetadata(IdAsambleaAct));

        public static DependencyProperty FechaAsamblea = DependencyProperty.Register("FechaAsamblea", typeof(string), typeof(uc_Asamblea),
                                                                             new UIPropertyMetadata(FechaAsambleaAct));


        public static DependencyProperty TipoAsamblea = DependencyProperty.Register("TipoAsamblea", typeof(string), typeof(uc_Asamblea),
                                                                             new UIPropertyMetadata(TipoAsambleaAct));

        public static DependencyProperty ActaAsamblea = DependencyProperty.Register("ActaAsamblea", typeof(string), typeof(uc_Asamblea),
                                                                             new UIPropertyMetadata(ActaAsambleaAct));

        #endregion

        #region Propiedades

        public int AsambleaId
        {
            get { return (int)GetValue(IdAsamblea); }
            set { SetValue(IdAsamblea, value); }
        }

        public string AsambleaFecha
        {
            get { return (string)GetValue(FechaAsamblea); }
            set { SetValue(FechaAsamblea, value); }
        }

        public string AsambleaTipo
        {
            get { return (string)GetValue(TipoAsamblea); }
            set { SetValue(TipoAsamblea, value); }
        }

        public string AsambleaActa
        {
            get { return (string)GetValue(ActaAsamblea); }
            set { SetValue(ActaAsamblea, value); }
        }
        #endregion


        #region Métodos privados
        private static void IdAsambleaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Asamblea nAsamblea = (uc_Asamblea)d;
            nAsamblea.AsambleaId = Convert.ToInt32(e.NewValue);
        }

        private static void FechaAsambleaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Asamblea nAsamblea = (uc_Asamblea)d;
            nAsamblea.AsambleaFecha = e.NewValue as string;
        }

        private static void TipoAsambleaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Asamblea nAsamblea = (uc_Asamblea)d;
            nAsamblea.AsambleaTipo = e.NewValue as string;
        }

        private static void ActaAsambleaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Asamblea nAsamblea = (uc_Asamblea)d;
            nAsamblea.AsambleaActa = e.NewValue as string;
        }

        #endregion

        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (pColor == true) grdPrincipal.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdPrincipal.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }
    }
}
