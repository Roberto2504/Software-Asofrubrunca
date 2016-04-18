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

namespace SIGEEA_App.User_Controls
{
    /// <summary>
    /// Interaction logic for uc_CantidadPedidoProducto.xaml
    /// </summary>
    public partial class uc_CantidadPedidoProducto
    {
        public uc_CantidadPedidoProducto()
        {
            InitializeComponent();
        }
        #region DependencyProperty
        /////////////////////////////////////////////////ID TIPO DE PRODUCTO///////////////////////////////////////////
        public static DependencyProperty dpIdTipProducto = DependencyProperty.Register
                                                                         ("IdTipProducto",
                                                                         typeof(string),
                                                                         typeof(uc_CantidadPedidoProducto),
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
            uc_CantidadPedidoProducto test = (uc_CantidadPedidoProducto)d;
            test.IdTipProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////NOMBRE TIPO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpnomTipProducto = DependencyProperty.Register
                                                                         ("nomTipProducto",
                                                                         typeof(string),
                                                                         typeof(uc_CantidadPedidoProducto),
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
            uc_CantidadPedidoProducto test = (uc_CantidadPedidoProducto)d;
            test.nomTipProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////CANTIDAD DE PEDIDO TIPO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpPedProducto = DependencyProperty.Register
                                                                         ("PedProducto",
                                                                         typeof(string),
                                                                         typeof(uc_CantidadPedidoProducto),
                                                                         new UIPropertyMetadata(PedProductoAct));

        [Description("PedProducto"), Category("Common Properties")]
        [Bindable(true)]

        public string PedProducto
        {
            get { return (string)GetValue(dpPedProducto); }
            set { SetValue(dpPedProducto, value); }
        }
        private static void PedProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_CantidadPedidoProducto test = (uc_CantidadPedidoProducto)d;
            test.PedProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////TIPO DE PEDIDO DE PRODUCTO/AGREGAR Ó MODIFICAR//////////////////////////////////////////////////////////
        public static DependencyProperty dpTipPedido = DependencyProperty.Register
                                                                         ("TipPedido",
                                                                         typeof(string),
                                                                         typeof(uc_CantidadPedidoProducto),
                                                                         new UIPropertyMetadata(TipPedidoAct));


        [Description("TipPedido"), Category("Common Properties")]
        [Bindable(true)]

        public string TipPedido
        {
            get { return (string)GetValue(dpTipPedido); }
            set { SetValue(dpTipPedido, value); }
        }
        private static void TipPedidoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_CantidadPedidoProducto test = (uc_CantidadPedidoProducto)d;
            test.TipPedido = e.NewValue as string;
        }
        //////////////////////////////////////////////CANTIDAD INVENTARIO DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpcanInvProducto = DependencyProperty.Register
                                                                         ("canInvProducto",
                                                                         typeof(string),
                                                                         typeof(uc_CantidadPedidoProducto),
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
            uc_CantidadPedidoProducto test = (uc_CantidadPedidoProducto)d;
            test.canInvProducto = e.NewValue as string;
        }

        //////////////////////////////////////////////UNIDAD DE MEDIDA DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpUniMedProducto = DependencyProperty.Register
                                                                         ("UniMedProducto",
                                                                         typeof(string),
                                                                         typeof(uc_CantidadPedidoProducto),
                                                                         new UIPropertyMetadata(UniMedProductoAct));

        [Description("UniMedProducto"), Category("Common Properties")]
        [Bindable(true)]
        public string UniMedProducto
        {
            get { return (string)GetValue(dpUniMedProducto); }
            set { SetValue(dpUniMedProducto, value); }
        }
        private static void UniMedProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_CantidadPedidoProducto test = (uc_CantidadPedidoProducto)d;
            test.UniMedProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////PRECIO DE MEDIDA DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpPrecioProducto = DependencyProperty.Register
                                                                         ("PrecioProducto",
                                                                         typeof(string),
                                                                         typeof(uc_CantidadPedidoProducto),
                                                                         new UIPropertyMetadata(PrecioProductoAct));

        [Description("PrecioProducto"), Category("Common Properties")]
        [Bindable(true)]
        public string PrecioProducto
        {
            get { return (string)GetValue(dpPrecioProducto); }
            set { SetValue(dpPrecioProducto, value); }
        }
        private static void PrecioProductoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_CantidadPedidoProducto test = (uc_CantidadPedidoProducto)d;
            test.PrecioProducto = e.NewValue as string;
        }
        //////////////////////////////////////////////MONEDA DE MEDIDA DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpMoneda = DependencyProperty.Register
                                                                         ("Moneda",
                                                                         typeof(string),
                                                                         typeof(uc_CantidadPedidoProducto),
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
            uc_CantidadPedidoProducto test = (uc_CantidadPedidoProducto)d;
            test.Moneda = e.NewValue as string;
        }
        //////////////////////////////////////////////DESCUENTO DE MEDIDA DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpDescuento = DependencyProperty.Register
                                                                         ("Descuento",
                                                                         typeof(string),
                                                                         typeof(uc_CantidadPedidoProducto),
                                                                         new UIPropertyMetadata(DescuentoAct));

        [Description("Descuento"), Category("Common Properties")]
        [Bindable(true)]
        public string Descuento
        {
            get { return (string)GetValue(dpDescuento); }
            set { SetValue(dpDescuento, value); }
        }
        private static void DescuentoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_CantidadPedidoProducto test = (uc_CantidadPedidoProducto)d;
            test.Descuento = e.NewValue as string;
        }
        //////////////////////////////////////////////NUEVO PRECIO DE MEDIDA DE PRODUCTO//////////////////////////////////////////////////////////
        public static DependencyProperty dpNuevoPrecio = DependencyProperty.Register
                                                                         ("NuevoPrecio",
                                                                         typeof(string),
                                                                         typeof(uc_CantidadPedidoProducto),
                                                                         new UIPropertyMetadata(NuevoPrecioAct));

        [Description("NuevoPrecio"), Category("Common Properties")]
        [Bindable(true)]
        public string NuevoPrecio
        {
            get { return (string)GetValue(dpNuevoPrecio); }
            set { SetValue(dpNuevoPrecio, value); }
        }
        private static void NuevoPrecioAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_CantidadPedidoProducto test = (uc_CantidadPedidoProducto)d;
            test.NuevoPrecio = e.NewValue as string;
        }
        #endregion
    }
}
