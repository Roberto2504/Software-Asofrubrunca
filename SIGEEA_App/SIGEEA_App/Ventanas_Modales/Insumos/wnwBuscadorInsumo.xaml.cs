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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SIGEEA_App.User_Controls.Insumos;

namespace SIGEEA_App.Ventanas_Modales.Insumos
{
    /// <summary>
    /// Interaction logic for wnwBuscadorInsumo.xaml
    /// </summary>
    public partial class wnwBuscadorInsumo : MetroWindow
    {
        public wnwBuscadorInsumo(string tipo)
        {
            InitializeComponent();
            uc_ContenedorInsumos nuevo = new uc_ContenedorInsumos(pOpcion: tipo);
            grdBuscardorInsumo.Children.Add(nuevo);
        }
    }
}
