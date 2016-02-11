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
    /// Interaction logic for uc_Puestos.xaml
    /// </summary>
    public partial class uc_Puestos : UserControl
    {
        public uc_Puestos()
        {
            InitializeComponent();
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<SIGEEA_spListarPuestosResult> lista = dc.SIGEEA_spListarPuestos().ToList();
            foreach(SIGEEA_spListarPuestosResult p in lista)
            {
                cmbLista.Items.Add(p.Nombre_Puesto);
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
