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
    /// Lógica de interacción para wnwReporteVentasCliente.xaml
    /// </summary>
    public partial class wnwReporteVentasCliente : MetroWindow
    {
        int Cliente;
        public wnwReporteVentasCliente(int idCliente)
        {
            InitializeComponent();
            Cliente = idCliente;
            
        }
        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dtpFecInicio.SelectedDate.Value.ToString() != "" && dtpFecFinal.SelectedDate.Value.ToString() != "")
                {
                    SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
                    ReporteFacturaVenta.Reset();
                    List<SIGEEA_spReporteVentasProductoPorClienteResult> Detalle = new List<SIGEEA_spReporteVentasProductoPorClienteResult>();
                    List<SIGEEA_spEncabezadoReporteVentasPorClienteResult> Orden = new List<SIGEEA_spEncabezadoReporteVentasPorClienteResult>();
                    List<SIGEEA_spPieReporteVentasPorClienteResult> Pie = new List<SIGEEA_spPieReporteVentasPorClienteResult>();
                    List<SIGEEA_spSaldoCreditoClienteResult> SaldoCredito = new List<SIGEEA_spSaldoCreditoClienteResult>();
                    Detalle = dc.SIGEEA_spReporteVentasProductoPorCliente(Cliente, dtpFecInicio.SelectedDate.Value, dtpFecFinal.SelectedDate.Value).ToList();
                    Orden = dc.SIGEEA_spEncabezadoReporteVentasPorCliente(Cliente).ToList();
                    Pie = dc.SIGEEA_spPieReporteVentasPorCliente(Cliente, dtpFecInicio.SelectedDate.Value, dtpFecFinal.SelectedDate.Value).ToList();
                    SaldoCredito = dc.SIGEEA_spSaldoCreditoCliente(Cliente, dtpFecInicio.SelectedDate.Value, dtpFecFinal.SelectedDate.Value).ToList();
                    var source = new ReportDataSource("Detalle", helper.ConvertToDatatable(Detalle));
                    var source2 = new ReportDataSource("Encabezado", helper.ConvertToDatatable(Orden));
                    var source3 = new ReportDataSource("Pie", helper.ConvertToDatatable(Pie));
                    var source4 = new ReportDataSource("SaldoCredito", helper.ConvertToDatatable(SaldoCredito));
                    ReporteFacturaVenta.LocalReport.DataSources.Add(source);
                    ReporteFacturaVenta.LocalReport.DataSources.Add(source2);
                    ReporteFacturaVenta.LocalReport.DataSources.Add(source3);
                    ReporteFacturaVenta.LocalReport.DataSources.Add(source4);
                    ReporteFacturaVenta.LocalReport.ReportEmbeddedResource = "SIGEEA_App.Reportes.Clientes.Re_Reporte_Ventas_Cliente.rdlc";
                    ReporteFacturaVenta.RefreshReport();
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
