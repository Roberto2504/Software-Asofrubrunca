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
    ///     <MyNamespace:ccBotonBasico/>
    ///
    /// </summary>
    public class ccBotonBasico : Button
    {
        static ccBotonBasico()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ccBotonBasico), new FrameworkPropertyMetadata(typeof(ccBotonBasico)));
        }

        /////////////////////////////////////////////////Nombre del botón///////////////////////////////////////////
        public static DependencyProperty dpNombre = DependencyProperty.Register
                                                                         ("Nombre",
                                                                         typeof(string),
                                                                         typeof(ccBotonBasico),
                                                                         new UIPropertyMetadata(NombreAct));

        [Description("Nombre"), Category("Common Properties")]
        [Bindable(true)]

        public string Nombre
        {
            get { return (string)GetValue(dpNombre); }
            set { SetValue(dpNombre, value); }
        }
        private static void NombreAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ccBotonBasico test = (ccBotonBasico)d;
            test.Nombre = e.NewValue as string;
        }
        /////////////////////////////////////////////////Color botón///////////////////////////////////////////
        public static DependencyProperty dpColor = DependencyProperty.Register
                                                                         ("Color",
                                                                         typeof(string),
                                                                         typeof(ccBotonBasico),
                                                                         new UIPropertyMetadata(ColorAct));

        [Description("Color"), Category("Common Properties")]
        [Bindable(true)]

        public string Color
        {
            get { return (string)GetValue(dpColor); }
            set { SetValue(dpColor, value); }
        }
        private static void ColorAct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ccBotonBasico test = (ccBotonBasico)d;
            test.Color = e.NewValue as string;
        }



    }
}
