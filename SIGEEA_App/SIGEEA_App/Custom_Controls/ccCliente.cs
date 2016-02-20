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
    ///     <MyNamespace:ccCliente/>
    ///
    /// </summary>
    public class ccCliente : Button
    {
        static ccCliente()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ccCliente), new FrameworkPropertyMetadata(typeof(ccCliente)));
        }
        #region DependencyProperty

        public static DependencyProperty dpIdCliente = DependencyProperty.Register
                                                                         ("IdCliente",
                                                                         typeof(string),
                                                                         typeof(ccCliente),
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
            ccCliente test = (ccCliente)d;
            test.idCliente = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpIdPersona = DependencyProperty.Register
                                                                         ("IdPersona",
                                                                         typeof(string),
                                                                         typeof(ccCliente),
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
            ccCliente test = (ccCliente)d;
            test.idPersona = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpNombreCompletoCliente = DependencyProperty.Register
                                                                         ("NombreCompletoCliente",
                                                                         typeof(string),
                                                                         typeof(ccCliente),
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
            ccCliente test = (ccCliente)d;
            test.NombreCompletoCliente = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpCedulaCliente = DependencyProperty.Register
                                                                         ("CedulaCliente",
                                                                         typeof(string),
                                                                         typeof(ccCliente),
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
            ccCliente test = (ccCliente)d;
            test.CedulaCliente = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//

        public static DependencyProperty dpColorCatCliente = DependencyProperty.Register
                                                                         ("ColorCatCliente",
                                                                         typeof(string),
                                                                         typeof(ccCliente),
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
            ccCliente test = (ccCliente)d;
            test.ColorCatCliente = e.NewValue as string;
        }

        //-------------------------------------------------------------------------------------------------------//
        public static DependencyProperty dpBtnEditar = DependencyProperty.Register
                                                                        ("BtnEditar",
                                                                        typeof(Button),
                                                                        typeof(ccCliente),
                                                                        new UIPropertyMetadata(BtnEditarAct));

        [Description("BtnEditar"), Category("Common Properties")]
        [Bindable(true)]

        public Button BtnEditar
        {
            get { return (Button)GetValue(dpBtnEditar); }
            set { SetValue(dpBtnEditar, value); }
        }
        private static void BtnEditarAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ccCliente test = (ccCliente)d;
            test.BtnEditar = e.NewValue as Button;
        }

        //-------------------------------------------------------------------------------------------------------//
        #endregion
    }
}
