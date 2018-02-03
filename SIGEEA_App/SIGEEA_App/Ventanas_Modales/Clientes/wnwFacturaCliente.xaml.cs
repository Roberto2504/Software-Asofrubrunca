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
using SIGEEA_BO;
using SIGEEA_App.Facturas;
using Microsoft.Reporting.WinForms;

namespace SIGEEA_App.Ventanas_Modales.Clientes
{
    /// <summary>
    /// Lógica de interacción para wnwFacturaCliente.xaml
    /// </summary>
    public partial class wnwFacturaCliente : MetroWindow
    {
        public wnwFacturaCliente(int pidFactura, string pTipo)
        {
            InitializeComponent();


            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            if(pTipo == "Reporte")
            {
                inputGroup.Visibility = Visibility.Visible;
            } else
            {
                inputGroup.Visibility = Visibility.Hidden;
                cargarFactura(pidFactura);
            }
        }

        public void cargarFactura(int idFactura)
        {
            ReporteFacturaVenta.Reset();
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            ReporteFacturaVenta.Reset();
            List<SIGEEA_spDetalleFacturaClienteResult> Detalle = new List<SIGEEA_spDetalleFacturaClienteResult>();
            List<SIGEEA_spEncabezadoFacturaClienteResult> Orden = new List<SIGEEA_spEncabezadoFacturaClienteResult>();
            List<SIGEEA_spPieFacturaClienteResult> Pie = new List<SIGEEA_spPieFacturaClienteResult>();
            Detalle = dc.SIGEEA_spDetalleFacturaCliente(idFactura).ToList();
            Orden = dc.SIGEEA_spEncabezadoFacturaCliente(idFactura).ToList();
            Pie = dc.SIGEEA_spPieFacturaCliente(idFactura).ToList();
            var source = new ReportDataSource("Detalle", helper.ConvertToDatatable(Detalle));
            var source2 = new ReportDataSource("Orden", helper.ConvertToDatatable(Orden));
            var source3 = new ReportDataSource("Pie", helper.ConvertToDatatable(Pie));
            ReporteFacturaVenta.LocalReport.DataSources.Add(source);
            ReporteFacturaVenta.LocalReport.DataSources.Add(source2);
            ReporteFacturaVenta.LocalReport.DataSources.Add(source3);
            ReporteFacturaVenta.LocalReport.ReportEmbeddedResource = "SIGEEA_App.Facturas.Re_Cancelar_Factura_Cliente.rdlc";
            ReporteFacturaVenta.RefreshReport();
        }
        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {   
            try
            {
                cargarFactura(Convert.ToInt32(searchIn.Text));
            } catch (Exception ex)
            {

            }
        }
    }
}
