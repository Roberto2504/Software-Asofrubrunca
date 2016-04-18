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
namespace SIGEEA_App.User_Controls.Insumos
{
    /// <summary>
    /// Interaction logic for uc_Insumo.xaml
    /// </summary>
    public partial class uc_Insumo : UserControl
    {
        public uc_Insumo()
        {
            InitializeComponent();
        }
        #region DependencyProperty

        public static DependencyProperty dpIdInsumo = DependencyProperty.Register
                                                                         ("IdInsumo",
                                                                         typeof(string),
                                                                         typeof(uc_Insumo),
                                                                         new UIPropertyMetadata(IdInsumoAct));

        [Description("IdInsumo"), Category("Common Properties")]
        [Bindable(true)]

        public string IdInsumo
        {
            get { return (string)GetValue(dpIdInsumo); }
            set { SetValue(dpIdInsumo, value); }
        }
        private static void IdInsumoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Insumo test = (uc_Insumo)d;
            test.IdInsumo = e.NewValue as string;
        }

        
        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpNombreInsumo = DependencyProperty.Register
                                                                         ("NombreInsumo",
                                                                         typeof(string),
                                                                         typeof(uc_Insumo),
                                                                         new UIPropertyMetadata(NombreInsumoAct));

        [Description("NombreInsumo"), Category("Common Properties")]
        [Bindable(true)]

        public string NombreInsumo
        {
            get { return (string)GetValue(dpNombreInsumo); }
            set { SetValue(dpNombreInsumo, value); }
        }
        private static void NombreInsumoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Insumo test = (uc_Insumo)d;
            test.NombreInsumo = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpDescripcion = DependencyProperty.Register
                                                                         ("Descripcion",
                                                                         typeof(string),
                                                                         typeof(uc_Insumo),
                                                                         new UIPropertyMetadata(DescripcionAct));

        [Description("Descripcion"), Category("Common Properties")]
        [Bindable(true)]

        public string Descripcion
        {
            get { return (string)GetValue(dpDescripcion); }
            set { SetValue(dpDescripcion, value); }
        }
        private static void DescripcionAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Insumo test = (uc_Insumo)d;
            test.Descripcion = e.NewValue as string;
        }
        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpCanInsumo = DependencyProperty.Register
                                                                         ("CanInsumo",
                                                                         typeof(string),
                                                                         typeof(uc_Insumo),
                                                                         new UIPropertyMetadata(CanInsumoAct));

        [Description("CanInsumo"), Category("Common Properties")]
        [Bindable(true)]

        public string CanInsumo
        {
            get { return (string)GetValue(dpCanInsumo); }
            set { SetValue(dpCanInsumo, value); }
        }
        private static void CanInsumoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Insumo test = (uc_Insumo)d;
            test.CanInsumo = e.NewValue as string;
        }
        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpUniMedidaInsumo = DependencyProperty.Register
                                                                         ("UniMedidaInsumo",
                                                                         typeof(string),
                                                                         typeof(uc_Insumo),
                                                                         new UIPropertyMetadata(UniMedidaInsumoAct));

        [Description("UniMedidaInsumo"), Category("Common Properties")]
        [Bindable(true)]

        public string UniMedidaInsumo
        {
            get { return (string)GetValue(dpUniMedidaInsumo); }
            set { SetValue(dpUniMedidaInsumo, value); }
        }
        private static void UniMedidaInsumoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Insumo test = (uc_Insumo)d;
            test.UniMedidaInsumo = e.NewValue as string;
        }
        //-------------------------------------------------------------------------------------------------------//

        public static DependencyProperty dpColorInsumo = DependencyProperty.Register
                                                                         ("ColorInsumo",
                                                                         typeof(string),
                                                                         typeof(uc_Insumo),
                                                                         new UIPropertyMetadata(ColorInsumoAct));

        [Description("ColorInsumo"), Category("Common Properties")]
        [Bindable(true)]

        public string ColorInsumo
        {
            get { return (string)GetValue(dpColorInsumo); }
            set { SetValue(dpColorInsumo, value); }
        }
        private static void ColorInsumoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Insumo test = (uc_Insumo)d;
            test.ColorInsumo = e.NewValue as string;
        }


        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpEstadoInsumo = DependencyProperty.Register
                                                                        ("EstadoInsumo",
                                                                        typeof(string),
                                                                        typeof(uc_Insumo),
                                                                        new UIPropertyMetadata(EstadoInsumoAct));

        [Description("EstadoInsumo"), Category("Common Properties")]
        [Bindable(true)]

        public string EstadoInsumo
        {
            get { return (string)GetValue(dpEstadoInsumo); }
            set { SetValue(dpEstadoInsumo, value); }
        }
        private static void EstadoInsumoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Insumo test = (uc_Insumo)d;
            test.EstadoInsumo = e.NewValue as string;
        }


        //-------------------------------------------------------------------------------------------------------//
        #endregion
    }
}
