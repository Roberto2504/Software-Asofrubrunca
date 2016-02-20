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

namespace SIGEEA_App.Custom_Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:SIGEEA_App.Custom_Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:SIGEEA_App.Custom_Controls;assembly=SIGEEA_App.Custom_Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ccProducto/>
    ///
    /// </summary>
    public class ccProducto : Button
    {
        static ccProducto()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ccProducto), new FrameworkPropertyMetadata(typeof(ccProducto)));
        }
        #region DependencyProperty
        /////////////////////////////////////////////////ID TIPO DE PRODUCTO///////////////////////////////////////////
        public static DependencyProperty dpIdTipProducto = DependencyProperty.Register
                                                                         ("IdTipProducto",
                                                                         typeof(string),
                                                                         typeof(ccProducto),
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
            ccProducto test = (ccProducto)d;
            test.IdTipProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////NOMBRE TIPO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpnomTipProducto = DependencyProperty.Register
                                                                         ("nomTipProducto",
                                                                         typeof(string),
                                                                         typeof(ccProducto),
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
            ccProducto test = (ccProducto)d;
            test.nomTipProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////DESCRIPCIÓN TIPO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpdesTipProducto = DependencyProperty.Register
                                                                         ("desTipProducto",
                                                                         typeof(string),
                                                                         typeof(ccProducto),
                                                                         new UIPropertyMetadata(desTipProductoAct));

        [Description("desTipProducto"), Category("Common Properties")]
        [Bindable(true)]

        public string desTipProducto
        {
            get { return (string)GetValue(dpdesTipProducto); }
            set { SetValue(dpdesTipProducto, value); }
        }
        private static void desTipProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ccProducto test = (ccProducto)d;
            test.desTipProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////CALIDAD TIPO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpcalTipProducto = DependencyProperty.Register
                                                                         ("calTipProducto",
                                                                         typeof(string),
                                                                         typeof(ccProducto),
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
            ccProducto test = (ccProducto)d;
            test.calTipProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////CANTIDAD INVENTARIO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpcanInvProducto = DependencyProperty.Register
                                                                         ("canInvProducto",
                                                                         typeof(string),
                                                                         typeof(ccProducto),
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
            ccProducto test = (ccProducto)d;
            test.canInvProducto = e.NewValue as string;
        }

        //////////////////////////////////////////////PRECIO NACIONAL DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dppreNacProducto = DependencyProperty.Register
                                                                         ("preNacProducto",
                                                                         typeof(string),
                                                                         typeof(ccProducto),
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
            ccProducto test = (ccProducto)d;
            test.preNacProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////PRECIO EXTRAJERO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dppreExtProducto = DependencyProperty.Register
                                                                         ("preExtProducto",
                                                                         typeof(string),
                                                                         typeof(ccProducto),
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
            ccProducto test = (ccProducto)d;
            test.preExtProducto = e.NewValue as string;
        }



        //////////////////////////////////////////////COLOR DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpdcolorProducto = DependencyProperty.Register
                                                                         ("colorProducto",
                                                                         typeof(string),
                                                                         typeof(ccProducto),
                                                                         new UIPropertyMetadata(colorProductoAct));

        [Description("colorProducto"), Category("Common Properties")]
        [Bindable(true)]

        public string colorProducto
        {
            get { return (string)GetValue(dpdcolorProducto); }
            set { SetValue(dpdcolorProducto, value); }
        }
        private static void colorProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ccProducto test = (ccProducto)d;
            test.colorProducto = e.NewValue as string;
        }

        //////////////////////////////////////////////IDMONEDA DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpIdMoneda = DependencyProperty.Register
                                                                         ("IdMoneda",
                                                                         typeof(string),
                                                                         typeof(ccProducto),
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
            ccProducto test = (ccProducto)d;
            test.IdMoneda = e.NewValue as string;
        }
        //////////////////////////////////////////////IDMONEDA DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpUniMedida = DependencyProperty.Register
                                                                         ("UniMedida",
                                                                         typeof(string),
                                                                         typeof(ccProducto),
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
            ccProducto test = (ccProducto)d;
            test.UniMedida = e.NewValue as string;
        }
        #endregion
    }
}
