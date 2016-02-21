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

using SIGEEA_BL;
using SIGEEA_BO;

namespace SIGEEA_App.User_Controls.Asociados
{
    /// <summary>
    /// Interaction logic for uc_ItemFamiliar.xaml
    /// </summary>
    public partial class uc_ItemFamiliar : UserControl
    {
        public uc_ItemFamiliar(SIGEEA_spListarFamiliaresResult pFamiliar, bool pEditar)
        {
            InitializeComponent();

            if (pEditar == true) CargaInformacion(pFamiliar);

            else
            {
                grdInformacion.IsEnabled = true;
                btnEditar.Visibility = Visibility.Hidden;
                btnEliminar.Visibility = Visibility.Hidden;
            }
        }

        private void CargaInformacion(SIGEEA_spListarFamiliaresResult pFamiliar)
        {
            txbNombre.Text = pFamiliar.Nombre_Familiar;
            txbDetalles.Text = pFamiliar.DesEstudios_Familiar;
            lblIdFamiliar.Content = pFamiliar.PK_Id_Familiar.ToString();
            btnEditar.Tag = pFamiliar.PK_Id_Familiar.ToString();

            foreach (RadioButton rb in grdEscolaridad.Children) if (rb.Name == "rbt" + pFamiliar.Escolaridad_Familiar.ToString()) rb.IsChecked = true;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            grdInformacion.IsEnabled = true;
        }

        public void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Realmente eliminar este registro?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                SIGEEA_Familiar eliminar = dc.SIGEEA_Familiars.First(c => c.PK_Id_Familiar == Convert.ToInt32(lblIdFamiliar.Content));
                dc.SIGEEA_Familiars.DeleteOnSubmit(eliminar);
                dc.SubmitChanges();
                MessageBox.Show("Registro borrado.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public int ObtieneIdFamiliar()
        {
            return Convert.ToInt32(lblIdFamiliar.Content);
        }

        public void Color(bool pColor)
        {
            BrushConverter bc = new BrushConverter();
            if (pColor == true) grdContenedor.Background = (Brush)bc.ConvertFrom("#FFC7DFE6");
            else grdContenedor.Background = (Brush)bc.ConvertFrom("#FF5A99AC");
        }

        public int Escolaridad()
        {
            int valor = -1;

            foreach (RadioButton rb in grdEscolaridad.Children)
            {
                if (rb.IsChecked == true)
                {
                    valor = Convert.ToInt32(rb.Tag);
                }
            }

            return valor;
        }
    }
}

