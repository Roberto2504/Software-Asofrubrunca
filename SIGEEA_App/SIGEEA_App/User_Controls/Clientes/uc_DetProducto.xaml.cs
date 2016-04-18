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
using System.ComponentModel;

namespace SIGEEA_App.User_Controls.Clientes
{
    /// <summary>
    /// Interaction logic for uc_DetProducto.xaml
    /// </summary>
    public partial class uc_DetProducto : UserControl
    {
        public uc_DetProducto()
        {
            InitializeComponent();
        }
        #region DependencyProperty
        /////////////////////////////////////////////////ID TIPO DE PRODUCTO///////////////////////////////////////////
        public static DependencyProperty dpIdTipProducto = DependencyProperty.Register
                                                                         ("IdTipProducto",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(IdTipProductoAct));
        [Description("IdTipProducto"), Category("Common Properties")]
        [Bindable(true)]

        public string IdTipProducto
        {
            get { return (string)GetValue(dpIdTipProducto); }
            set { SetValue(dpIdTipProducto, value); }
        }
        private static void IdTipProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.IdTipProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////NOMBRE TIPO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpnomTipProducto = DependencyProperty.Register
                                                                         ("nomTipProducto",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(nomTipProductoAct));



        [Description("nomTipProducto"), Category("Common Properties")]
        [Bindable(true)]
        public string nomTipProducto
        {
            get { return (string)GetValue(dpnomTipProducto); }
            set { SetValue(dpnomTipProducto, value); }
        }
        private static void nomTipProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.nomTipProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////DESCUENTO TIPO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpdesProducto = DependencyProperty.Register
                                                                         ("desProducto",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(desProductoAct));

        [Description("desProducto"), Category("Common Properties")]
        [Bindable(true)]

        public string desProducto
        {
            get { return (string)GetValue(dpdesProducto); }
            set { SetValue(dpdesProducto, value); }
        }
        private static void desProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.desProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////CALIDAD TIPO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpcalTipProducto = DependencyProperty.Register
                                                                         ("calTipProducto",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(calTipProductoAct));


        [Description("calTipProducto"), Category("Common Properties")]
        [Bindable(true)]

        public string calTipProducto
        {
            get { return (string)GetValue(dpcalTipProducto); }
            set { SetValue(dpcalTipProducto, value); }
        }
        private static void calTipProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.calTipProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////CANTIDAD DISPONIBLE TIPO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpcanDisProducto = DependencyProperty.Register
                                                                         ("canDisProducto",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(canDisProductoAct));


        [Description("canDisProducto"), Category("Common Properties")]
        [Bindable(true)]

        public string canDisProducto
        {
            get { return (string)GetValue(dpcanDisProducto); }
            set { SetValue(dpcanDisProducto, value); }
        }
        private static void canDisProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.canDisProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////CANTIDAD INVENTARIO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpcanInvProducto = DependencyProperty.Register
                                                                         ("canInvProducto",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(canInvProductoAct));
        [Description("canInvProducto"), Category("Common Properties")]
        [Bindable(true)]
        public string canInvProducto
        {
            get { return (string)GetValue(dpcanInvProducto); }
            set { SetValue(dpcanInvProducto, value); }
        }
        private static void canInvProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.canInvProducto = e.NewValue as string;
        }

        //////////////////////////////////////////////PRECIO NETO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dppreNetProducto = DependencyProperty.Register
                                                                         ("preNetProducto",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(preNetProductoAct));

        [Description("preNetProducto"), Category("Common Properties")]
        [Bindable(true)]
        public string preNetProducto
        {
            get { return (string)GetValue(dppreNetProducto); }
            set { SetValue(dppreNetProducto, value); }
        }
        private static void preNetProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.preNetProducto = e.NewValue as string;
        }

        //////////////////////////////////////////////PRECIO BRUTO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dppreBruProducto = DependencyProperty.Register
                                                                         ("preBruProducto",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(preBruProductoAct));

        [Description("preBruProducto"), Category("Common Properties")]
        [Bindable(true)]
        public string preBruProducto
        {
            get { return (string)GetValue(dppreBruProducto); }
            set { SetValue(dppreBruProducto, value); }
        }
        private static void preBruProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.preBruProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////PRECIODE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dppreProducto = DependencyProperty.Register
                                                                         ("preProducto",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(preProductoAct));

        [Description("preProducto"), Category("Common Properties")]
        [Bindable(true)]
        public string preProducto
        {
            get { return (string)GetValue(dppreProducto); }
            set { SetValue(dppreProducto, value); }
        }
        private static void preProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.preProducto = e.NewValue as string;
        }




        //////////////////////////////////////////////IDMONEDA DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpIdMoneda = DependencyProperty.Register
                                                                         ("IdMoneda",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(IdMonedaAct));

        [Description("IdMoneda"), Category("Common Properties")]
        [Bindable(true)]
        public string IdMoneda
        {
            get { return (string)GetValue(dpIdMoneda); }
            set { SetValue(dpIdMoneda, value); }
        }
        private static void IdMonedaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.IdMoneda = e.NewValue as string;
        }
        //////////////////////////////////////////////Uni Medida  DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpUniMedida = DependencyProperty.Register
                                                                         ("UniMedida",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(UniMedidaAct));

        [Description("UniMedida"), Category("Common Properties")]
        [Bindable(true)]
        public string UniMedida
        {
            get { return (string)GetValue(dpUniMedida); }
            set { SetValue(dpUniMedida, value); }
        }
        private static void UniMedidaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.UniMedida = e.NewValue as string;
        }
        //////////////////////////////////////////////PRECIO NACIONAL DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dppreNacProducto = DependencyProperty.Register
                                                                         ("preNacProducto ",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(preNacProductoAct));

        [Description("preNacProducto"), Category("Common Properties")]
        [Bindable(true)]
        public string preNacProducto
        {
            get { return (string)GetValue(dppreNacProducto); }
            set { SetValue(dppreNacProducto, value); }
        }
        private static void preNacProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.preNacProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////PRECIO EXTRANJERO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dppreExtProducto = DependencyProperty.Register
                                                                         ("preExtProducto ",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(preExtProductoAct));

        [Description("preExtProducto"), Category("Common Properties")]
        [Bindable(true)]
        public string preExtProducto
        {
            get { return (string)GetValue(dppreExtProducto); }
            set { SetValue(dppreExtProducto, value); }
        }
        private static void preExtProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.preExtProducto = e.NewValue as string;
        }



        //////////////////////////////////////////////MONEDA DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpMoneda = DependencyProperty.Register
                                                                         ("Moneda",
                                                                         typeof(string),
                                                                         typeof(uc_DetProducto),
                                                                         new UIPropertyMetadata(MonedaAct));

        [Description("Moneda"), Category("Common Properties")]
        [Bindable(true)]
        public string Moneda
        {
            get { return (string)GetValue(dpMoneda); }
            set { SetValue(dpMoneda, value); }
        }
        private static void MonedaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_DetProducto test = (uc_DetProducto)d;
            test.Moneda = e.NewValue as string;
        }
        //////////////////////////////////////////////COLOR DE PRODUCTO//////////////////////////////////////////////////////////
        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (!pColor) grdPrincipal.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdPrincipal.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }
        #endregion
    }
}
