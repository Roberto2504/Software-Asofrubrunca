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
using SIGEEA_App.Ventanas_Modales.Personas;
using SIGEEA_App.Ventanas_Modales.Direcciones;
using SIGEEA_App.Ventanas_Modales.Asociados;

namespace SIGEEA_App.User_Controls.Asociados
{
    /// <summary>
    /// Interaction logic for uc_ItemAsociado.xaml
    /// </summary>
    public partial class uc_ItemAsociado : UserControl
    {
        public uc_ItemAsociado()
        {
            InitializeComponent();
        }

        #region Propiedades de dependencia

        public static DependencyProperty IdPersona = DependencyProperty.Register("IdPersona", typeof(int), typeof(uc_ItemAsociado),
                                                                             new UIPropertyMetadata(IdPersonaAct));

        public static DependencyProperty IdAsociado = DependencyProperty.Register("IdAsociado", typeof(int), typeof(uc_ItemAsociado),
                                                                             new UIPropertyMetadata(IdAsociadoAct));

        public static DependencyProperty Cedula = DependencyProperty.Register("Cedula", typeof(string), typeof(uc_ItemAsociado),
                                                                             new UIPropertyMetadata(CedulaAct));


        public static DependencyProperty Codigo = DependencyProperty.Register("Codigo", typeof(string), typeof(uc_ItemAsociado),
                                                                             new UIPropertyMetadata(CodigoAct));

        public static DependencyProperty Nombre = DependencyProperty.Register("Nombre", typeof(string), typeof(uc_ItemAsociado),
                                                                             new UIPropertyMetadata(CodigoAct));

        #endregion

        #region Propiedades

        public int PersonaId
        {
            get { return (int)GetValue(IdPersona); }
            set { SetValue(IdPersona, value); }
        }

        public int AsociadoId
        {
            get { return (int)GetValue(IdAsociado); }
            set { SetValue(IdAsociado, value); }
        }

        public string CedulaAsociado
        {
            get { return (string)GetValue(Cedula); }
            set { SetValue(Cedula, value); }
        }

        public string CodigoAsociado
        {
            get { return (string)GetValue(Codigo); }
            set { SetValue(Codigo, value); }
        }

        public string NombreAsociado
        {
            get { return (string)GetValue(Nombre); }
            set { SetValue(Nombre, value); }
        }
        #endregion


        #region Métodos privados

        private static void IdAsociadoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_ItemAsociado nAsociado = (uc_ItemAsociado)d;
            nAsociado.AsociadoId = Convert.ToInt32(e.NewValue);
        }
        private static void IdPersonaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_ItemAsociado nAsociado = (uc_ItemAsociado)d;
            nAsociado.PersonaId = Convert.ToInt32(e.NewValue);
        }

        private static void CedulaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_ItemAsociado nAsociado = (uc_ItemAsociado)d;
            nAsociado.CedulaAsociado = e.NewValue as string;
        }

        private static void CodigoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_ItemAsociado nAsociado = (uc_ItemAsociado)d;
            nAsociado.CodigoAsociado = e.NewValue as string;
        }

        private static void NombreAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_ItemAsociado nAsociado = (uc_ItemAsociado)d;
            nAsociado.NombreAsociado = e.NewValue as string;
        }

        #endregion

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            AsociadoMantenimiento asociado = new AsociadoMantenimiento();
            wnwRegistrarPersona ventana = new wnwRegistrarPersona("Asociado", asociado.AutenticaAsociado(CedulaAsociado), null, null);
            ventana.ShowDialog();
        }

        private void btnDireccion_Click(object sender, RoutedEventArgs e)
        {
            wnwDirecciones ventana = new wnwDirecciones(CedulaAsociado, "Asociado", pkFinca: 0);
            ventana.ShowDialog();
        }

        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (pColor == true) grdPrincipal.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdPrincipal.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }

        private void btnInfoFamiliar_Click(object sender, RoutedEventArgs e)
        {
            wnwVistaFamiliares ventana = new wnwVistaFamiliares(CedulaAsociado);
            ventana.ShowDialog();
        }
    }
}
