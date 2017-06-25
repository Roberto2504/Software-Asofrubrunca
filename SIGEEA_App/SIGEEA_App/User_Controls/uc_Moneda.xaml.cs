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

namespace SIGEEA_App.User_Controls
{
    /// <summary>
    /// Interaction logic for uc_Moneda.xaml
    /// </summary>
    public partial class uc_Moneda : UserControl
    {
        public uc_Moneda()
        {
            InitializeComponent();
            MonedaMantenimiento moneda = new MonedaMantenimiento();
            cmbLista.ItemsSource = moneda.SimboloMoneda();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

        }

        public int getMoneda()
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_Monedas.First(c => c.Simbolo_Moneda == cmbLista.SelectedItem.ToString()).PK_Id_Moneda;
        }

        public void setMoneda(int pMoneda)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            cmbLista.SelectedItem = dc.SIGEEA_Monedas.First(c => c.PK_Id_Moneda == pMoneda).Simbolo_Moneda;
        }
    }
}
