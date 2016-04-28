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
    /// Interaction logic for uc_Contacto.xaml
    /// </summary>
    public partial class uc_Contacto : UserControl
    {
        
        #region Propiedades de dependencia
        public static DependencyProperty IdContacto = DependencyProperty.Register("IdContacto", typeof(int), typeof(uc_Contacto),
                                                                                 new UIPropertyMetadata(IdContactoAct));


        public static DependencyProperty Dato = DependencyProperty.Register("Dato", typeof(string), typeof(uc_Contacto),
                                                                             new UIPropertyMetadata(DatoAct));

        public static DependencyProperty TipoDato = DependencyProperty.Register("TipoDato", typeof(string), typeof(uc_Contacto),
                                                                                 new UIPropertyMetadata(TipoDatoAct));
        #endregion

        #region Propiedades

        public int ContactoId
        {
            get { return (int)GetValue(IdContacto); }
            set { SetValue(IdContacto, value); }
        }

        public string Info
        {
            get { return (string)GetValue(Dato); }
            set { SetValue(Dato, value); }
        }

        public string TipoInfo
        {
            get { return (string)GetValue(TipoDato); }
            set { SetValue(TipoDato, value); }
        }

        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (pColor == true) grdContenedor.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdContenedor.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }

        #endregion

        #region Constructor
        public uc_Contacto()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos privados
        private static void IdContactoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Contacto nContacto = (uc_Contacto)d;
            nContacto.ContactoId = Convert.ToInt32(e.NewValue);
        }

        private static void DatoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Contacto nContacto = (uc_Contacto)d;
            nContacto.Info = e.NewValue as string;
        }

        private static void TipoDatoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Contacto nContacto = (uc_Contacto)d;
            nContacto.TipoInfo = e.NewValue as string;
        }

        public void cambiaImagen(string url)
        {
            imgContacto.Source = new BitmapImage(new Uri(@url, UriKind.RelativeOrAbsolute));
        }
        #endregion
    }
}
