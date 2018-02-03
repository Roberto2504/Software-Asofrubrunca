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
using SIGEEA_BO;
using Microsoft.Reporting.WinForms;


namespace SIGEEA_App.Ventanas_Modales.Asociados
{
    /// <summary>
    /// Interaction logic for wnwReportesAsociado.xaml
    /// </summary>
    public partial class wnwReportesAsociado : Window
    {
        List<SIGEEA_spGeneraReporteAsociadosConsolidadoResult> detallesConsolidado;
        List<SIGEEA_spGeneraReporteAsociadosPorIdResult> detallesIndividual;
        public wnwReportesAsociado(int indFactura = -1, int indAsociado = -1, string fecInicio = null, string fecFin = null, int idAsociado = -1)
        {
            InitializeComponent();

            try
            {
                string tmp_FecInicio, tmp_FecFin;

                tmp_FecInicio = Convert.ToDateTime(fecInicio).ToString("yyyy-MM-dd");
                tmp_FecFin = Convert.ToDateTime(fecFin).ToString("yyyy-MM-dd");

                SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();

                if (indAsociado == 0)//Todos los asociados
                {
                    wfhConsolidado.Visibility = Visibility.Visible;
                    detallesConsolidado = dc.SIGEEA_spGeneraReporteAsociadosConsolidado(indFactura, tmp_FecInicio.ToString(), tmp_FecFin.ToString()).ToList();
                    var source = new ReportDataSource("Detalle", SIGEEA.BL.Facturas.helper.ConvertToDatatable(detallesConsolidado));
                    rpwConsolidado.LocalReport.DataSources.Add(source);
                    rpwConsolidado.LocalReport.ReportEmbeddedResource = "SIGEEA_App.Reportes.Asociados.rptAsociadoConsolidado.rdlc";
                    rpwConsolidado.RefreshReport();
                }

                else if (indAsociado == 1)//Un asociado en particular
                {
                    wfhIndividual.Visibility = Visibility.Visible;
                    detallesIndividual = dc.SIGEEA_spGeneraReporteAsociadosPorId(indFactura, tmp_FecInicio.ToString(), tmp_FecFin.ToString(), idAsociado).ToList();
                    var source = new ReportDataSource("Detalle", SIGEEA.BL.Facturas.helper.ConvertToDatatable(detallesIndividual));
                    rpwIndividual.LocalReport.DataSources.Add(source);
                    rpwIndividual.LocalReport.ReportEmbeddedResource = "SIGEEA_App.Reportes.Asociados.rptAsociadoIndividual.rdlc";
                    rpwIndividual.RefreshReport();
                }         
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
