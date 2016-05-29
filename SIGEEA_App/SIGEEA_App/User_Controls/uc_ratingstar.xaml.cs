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
    /// Interaction logic for uc_ratingstar.xaml
    /// </summary>
    public partial class uc_ratingstar : UserControl
    {
        public uc_ratingstar()
        {
            InitializeComponent();
        }

        public void cargaEstrellas(float pValor)
        {
            int entero = (int)pValor;
            float decimales = pValor - entero;
            lblCalificacion.Text = pValor.ToString() + " puntos";
            for (int i = 1; i <= entero; i++)//Estrellas llenas
            {
                Image img = (Image)grdEstrellas.FindName("img" + i.ToString());
                img.Source = new BitmapImage(new Uri(@"/Imagenes/fullstar.png", UriKind.RelativeOrAbsolute));
            }

            if (decimales > 0)
            {
                Image img = (Image)grdEstrellas.FindName("img" + (entero + 1).ToString());
                img.Source = new BitmapImage(new Uri(@"/Imagenes/halfstar.png", UriKind.RelativeOrAbsolute));
            }


        }
    }
}
