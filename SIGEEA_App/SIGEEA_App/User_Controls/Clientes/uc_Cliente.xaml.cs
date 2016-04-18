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
    /// Interaction logic for uc_Cliente.xaml
    /// </summary>
    public partial class uc_Cliente : UserControl
    {
        public uc_Cliente()
        {
            InitializeComponent();
        }
        #region DependencyProperty

        public static DependencyProperty dpIdCliente = DependencyProperty.Register
                                                                         ("IdCliente",
                                                                         typeof(string),
                                                                         typeof(uc_Cliente),
                                                                         new UIPropertyMetadata(idClienteAct));

        [Description("IdCliente"), Category("Common Properties")]
        [Bindable(true)]

        public string idCliente
        {
            get { return (string)GetValue(dpIdCliente); }
            set { SetValue(dpIdCliente, value); }
        }
        private static void idClienteAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cliente test = (uc_Cliente)d;
            test.idCliente = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpIdPersona = DependencyProperty.Register
                                                                         ("IdPersona",
                                                                         typeof(string),
                                                                         typeof(uc_Cliente),
                                                                         new UIPropertyMetadata(idPersonaAct));

        [Description("IdPersona"), Category("Common Properties")]
        [Bindable(true)]

        public string idPersona
        {
            get { return (string)GetValue(dpIdPersona); }
            set { SetValue(dpIdPersona, value); }
        }
        private static void idPersonaAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cliente test = (uc_Cliente)d;
            test.idPersona = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpNombreCompletoCliente = DependencyProperty.Register
                                                                         ("NombreCompletoCliente",
                                                                         typeof(string),
                                                                         typeof(uc_Cliente),
                                                                         new UIPropertyMetadata(NombreCompletoClienteAct));

        [Description("NombreCompletoCliente"), Category("Common Properties")]
        [Bindable(true)]

        public string NombreCompletoCliente
        {
            get { return (string)GetValue(dpNombreCompletoCliente); }
            set { SetValue(dpNombreCompletoCliente, value); }
        }
        private static void NombreCompletoClienteAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cliente test = (uc_Cliente)d;
            test.NombreCompletoCliente = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpCedulaCliente = DependencyProperty.Register
                                                                         ("CedulaCliente",
                                                                         typeof(string),
                                                                         typeof(uc_Cliente),
                                                                         new UIPropertyMetadata(CedulaClienteAct));

        [Description("CedulaCliente"), Category("Common Properties")]
        [Bindable(true)]

        public string CedulaCliente
        {
            get { return (string)GetValue(dpCedulaCliente); }
            set { SetValue(dpCedulaCliente, value); }
        }
        private static void CedulaClienteAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cliente test = (uc_Cliente)d;
            test.CedulaCliente = e.NewValue as string;
        }
        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpCatCliente = DependencyProperty.Register
                                                                         ("CatCliente",
                                                                         typeof(string),
                                                                         typeof(uc_Cliente),
                                                                         new UIPropertyMetadata(CatClienteAct));

        [Description("CatCliente"), Category("Common Properties")]
        [Bindable(true)]

        public string CatCliente
        {
            get { return (string)GetValue(dpCatCliente); }
            set { SetValue(dpCatCliente, value); }
        }
        private static void CatClienteAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cliente test = (uc_Cliente)d;
            test.CatCliente = e.NewValue as string;
        }
        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpProxPagCliente = DependencyProperty.Register
                                                                         ("ProxPagCliente",
                                                                         typeof(string),
                                                                         typeof(uc_Cliente),
                                                                         new UIPropertyMetadata(ProxPagClienteAct));

        [Description("ProxPagCliente"), Category("Common Properties")]
        [Bindable(true)]

        public string ProxPagCliente
        {
            get { return (string)GetValue(dpProxPagCliente); }
            set { SetValue(dpProxPagCliente, value); }
        }
        private static void ProxPagClienteAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cliente test = (uc_Cliente)d;
            test.ProxPagCliente = e.NewValue as string;
        }
        //-------------------------------------------------------------------------------------------------------//

        public static DependencyProperty dpColorCatCliente = DependencyProperty.Register
                                                                         ("ColorCatCliente",
                                                                         typeof(string),
                                                                         typeof(uc_Cliente),
                                                                         new UIPropertyMetadata(ColorCatClienteAct));

        [Description("ColorCatCliente"), Category("Common Properties")]
        [Bindable(true)]

        public string ColorCatCliente
        {
            get { return (string)GetValue(dpColorCatCliente); }
            set { SetValue(dpColorCatCliente, value); }
        }
        private static void ColorCatClienteAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cliente test = (uc_Cliente)d;
            test.ColorCatCliente = e.NewValue as string;
        }


        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpEstadoCliente = DependencyProperty.Register
                                                                        ("EstadoCliente",
                                                                        typeof(string),
                                                                        typeof(uc_Cliente),
                                                                        new UIPropertyMetadata(EstadoClienteAct));

        [Description("EstadoCliente"), Category("Common Properties")]
        [Bindable(true)]

        public string EstadoCliente
        {
            get { return (string)GetValue(dpEstadoCliente); }
            set { SetValue(dpEstadoCliente, value); }
        }
        private static void EstadoClienteAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Cliente test = (uc_Cliente)d;
            test.EstadoCliente = e.NewValue as string;
        }


        //-------------------------------------------------------------------------------------------------------//
        #endregion
    }
}
