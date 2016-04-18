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

using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_App.User_Controls.Productos;

namespace SIGEEA_App.Ventanas_Modales.Asociados
{
    /// <summary>
    /// Interaction logic for wnwFacturasIncompletas.xaml
    /// </summary>
    public partial class wnwFacturasIncompletas : MetroWindow
    {
        public wnwFacturasIncompletas(string pAsociado)
        {
            InitializeComponent();

            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<SIGEEA_spObtenerFacturasIncompletasResult> listaFacturas = dc.SIGEEA_spObtenerFacturasIncompletas(pAsociado).ToList();

            bool color = true;
            foreach (SIGEEA_spObtenerFacturasIncompletasResult f in listaFacturas)
            {
                uc_FacturaEntrega factura = new uc_FacturaEntrega();
                factura.FacturaId = f.PK_Id_FacAsociado;
                factura.FacturaCantidad = f.CanTotal_FacAsociado.ToString();
                factura.FacturaFecha = f.FECHA;
                
                factura.btnDetalles.Click += BtnDetalles_Click;
                factura.Color(color);
                color = !color;
                stpContenedor.Children.Add(factura);
            }
        }

        private void BtnDetalles_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
