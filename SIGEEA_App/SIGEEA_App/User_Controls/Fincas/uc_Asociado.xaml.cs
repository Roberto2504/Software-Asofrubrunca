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
namespace SIGEEA_App.User_Controls.Fincas
{
    /// <summary>
    /// Interaction logic for uc_Asociado.xaml
    /// </summary>
    public partial class uc_Asociado : UserControl
    {
        public uc_Asociado()
        {
            InitializeComponent();
        }
        #region DependencyProperty

        public static DependencyProperty dpIdAsociado = DependencyProperty.Register
                                                                         ("IdAsociado",
                                                                         typeof(string),
                                                                         typeof(uc_Asociado),
                                                                         new UIPropertyMetadata(IdAsociadoAct));

        [Description("IdAsociado"), Category("Common Properties")]
        [Bindable(true)]

        public string IdAsociado
        {
            get { return (string)GetValue(dpIdAsociado); }
            set { SetValue(dpIdAsociado, value); }
        }
        private static void IdAsociadoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Asociado test = (uc_Asociado)d;
            test.IdAsociado = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpIdPersona = DependencyProperty.Register
                                                                         ("IdPersona",
                                                                         typeof(string),
                                                                         typeof(uc_Asociado),
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
            uc_Asociado test = (uc_Asociado)d;
            test.idPersona = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpNombreCompletoAsociado = DependencyProperty.Register
                                                                         ("NombreCompletoAsociado",
                                                                         typeof(string),
                                                                         typeof(uc_Asociado),
                                                                         new UIPropertyMetadata(NombreCompletoAsociadoAct));

        [Description("NombreCompletoAsociado"), Category("Common Properties")]
        [Bindable(true)]

        public string NombreCompletoAsociado
        {
            get { return (string)GetValue(dpNombreCompletoAsociado); }
            set { SetValue(dpNombreCompletoAsociado, value); }
        }
        private static void NombreCompletoAsociadoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Asociado test = (uc_Asociado)d;
            test.NombreCompletoAsociado = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpCodigo = DependencyProperty.Register
                                                                         ("Codigo",
                                                                         typeof(string),
                                                                         typeof(uc_Asociado),
                                                                         new UIPropertyMetadata(CodigoAct));

        [Description("Codigo"), Category("Common Properties")]
        [Bindable(true)]

        public string Codigo
        {
            get { return (string)GetValue(dpCodigo); }
            set { SetValue(dpCodigo, value); }
        }
        private static void CodigoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Asociado test = (uc_Asociado)d;
            test.Codigo = e.NewValue as string;
        }
        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpEstadoAsociado = DependencyProperty.Register
                                                                         ("EstadoAsociado ",
                                                                         typeof(string),
                                                                         typeof(uc_Asociado),
                                                                         new UIPropertyMetadata(EstadoAsociadoAct));

        [Description("EstadoAsociado "), Category("Common Properties")]
        [Bindable(true)]

        public string EstadoAsociado
        {
            get { return (string)GetValue(dpEstadoAsociado); }
            set { SetValue(dpEstadoAsociado, value); }
        }
        private static void EstadoAsociadoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Asociado test = (uc_Asociado)d;
            test.EstadoAsociado = e.NewValue as string;
        }
        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpColorAsociado = DependencyProperty.Register
                                                                         ("ColorAsociado",
                                                                         typeof(string),
                                                                         typeof(uc_Asociado),
                                                                         new UIPropertyMetadata(ColorAsociadoAct));

        [Description("ColorAsociado"), Category("Common Properties")]
        [Bindable(true)]

        public string ColorAsociado
        {
            get { return (string)GetValue(dpColorAsociado); }
            set { SetValue(dpColorAsociado, value); }
        }
        private static void ColorAsociadoAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            uc_Asociado test = (uc_Asociado)d;
            test.ColorAsociado = e.NewValue as string;
        }




        //-------------------------------------------------------------------------------------------------------//
        #endregion
    }
}
