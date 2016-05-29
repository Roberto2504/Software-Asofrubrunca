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

namespace SIGEEA_App.User_Controls.Asociados
{
    /// <summary>
    /// Interaction logic for uc_AsociadoAsamblea.xaml
    /// </summary>
    public partial class uc_AsociadoAsamblea : UserControl
    {
        public uc_AsociadoAsamblea(int pPK, string pNombre, int pEstado, string pCedula)
        {
            InitializeComponent();
            this.AsociadoAsambleaCedula = pCedula;
            this.AsociadoAsambleaEstado = pEstado;
            this.AsociadoAsambleaId = pPK;
            this.AsociadoAsambleaNombre = pNombre;
            MarcaEstado();
            rbtAusenciaJus.IsEnabled = true;
        }

        #region Propiedades de dependencia

        public static DependencyProperty IdAsociadoAsamblea = DependencyProperty.Register("IdAsociadoAsamblea", typeof(int), typeof(uc_AsociadoAsamblea),
                                                                             new UIPropertyMetadata(IdAsociadoAsambleaAct));

        public static DependencyProperty EstadoAsociadoAsamblea = DependencyProperty.Register("EstadoAsociadoAsamblea", typeof(int), typeof(uc_AsociadoAsamblea),
                                                                             new UIPropertyMetadata(EstadoAsociadoAsambleaAct));

        public static DependencyProperty CedulaAsociadoAsamblea = DependencyProperty.Register("CedulaAsociadoAsamblea", typeof(string), typeof(uc_AsociadoAsamblea),
                                                                             new UIPropertyMetadata(CedulaAsociadoAsambleaAct));

        public static DependencyProperty NombreAsociadoAsamblea = DependencyProperty.Register("NombreAsociadoAsamblea", typeof(string), typeof(uc_AsociadoAsamblea),
                                                                             new UIPropertyMetadata(NombreAsociadoAsambleaAct));


        #endregion

        #region Propiedades

        public int AsociadoAsambleaId
        {
            get { return (int)GetValue(IdAsociadoAsamblea); }
            set { SetValue(IdAsociadoAsamblea, value); }
        }

        public int AsociadoAsambleaEstado
        {
            get { return (int)GetValue(EstadoAsociadoAsamblea); }
            set { SetValue(EstadoAsociadoAsamblea, value); }
        }

        public string AsociadoAsambleaNombre
        {
            get { return (string)GetValue(NombreAsociadoAsamblea); }
            set { SetValue(NombreAsociadoAsamblea, value); }
        }


        public string AsociadoAsambleaCedula
        {
            get { return (string)GetValue(CedulaAsociadoAsamblea); }
            set { SetValue(CedulaAsociadoAsamblea, value); }
        }

        #endregion


        #region Métodos privados

        private static void EstadoAsociadoAsambleaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_AsociadoAsamblea nAsociado = (uc_AsociadoAsamblea)d;
            nAsociado.AsociadoAsambleaEstado = Convert.ToInt32(e.NewValue);
        }
        private static void IdAsociadoAsambleaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_AsociadoAsamblea nAsociado = (uc_AsociadoAsamblea)d;
            nAsociado.AsociadoAsambleaId = Convert.ToInt32(e.NewValue);
        }

        private static void NombreAsociadoAsambleaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_AsociadoAsamblea nAsociado = (uc_AsociadoAsamblea)d;
            nAsociado.AsociadoAsambleaNombre = e.NewValue as string;
        }

        private static void CedulaAsociadoAsambleaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_AsociadoAsamblea nAsociado = (uc_AsociadoAsamblea)d;
            nAsociado.AsociadoAsambleaCedula = e.NewValue as string;
        }

        #endregion


        private void MarcaEstado()
        {
            if (this.AsociadoAsambleaEstado == 3) rbtAusenciaInj.IsChecked = true;
            else if (this.AsociadoAsambleaEstado == 2) rbtAusenciaJus.IsChecked = true;
            else if (this.AsociadoAsambleaEstado == 1) rbtPresente.IsChecked = true;
        }

        public int ObtenerEstado()
        {
            if (rbtAusenciaInj.IsChecked == true) return 3;
            else if (rbtAusenciaJus.IsChecked == true) return 2;
            else if (rbtPresente.IsChecked == true) return 1;
            else return 0;
        }

        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (pColor == true) grdPrincipal.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdPrincipal.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }
    }
}

