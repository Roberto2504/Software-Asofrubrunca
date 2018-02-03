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

namespace SIGEEA_App.Ventanas_Modales.Empleados
{
    /// <summary>
    /// Interaction logic for wnwReporteEmpleados.xaml
    /// </summary>
    public partial class wnwReporteEmpleados : MetroWindow
    {
        public wnwReporteEmpleados()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dtpFecInicio.SelectedDate.Value.ToString() != "" && dtpFecFinal.SelectedDate.Value.ToString() != "")
                {
                    SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
                    ReporteEmpleados.Reset();
                    List<SIGEEA_spGenerarReporteEmpleadosResult> ReporteEmpleado = new List<SIGEEA_spGenerarReporteEmpleadosResult>();
                    ReporteEmpleado = dc.SIGEEA_spGenerarReporteEmpleados(dtpFecInicio.SelectedDate.Value, dtpFecFinal.SelectedDate.Value, txtCedula.Text == "" ? null : txtCedula.Text).ToList();
                    var source = new ReportDataSource("Reporte_Empleado", helper.ConvertToDatatable(ReporteEmpleado));
                    ReporteEmpleados.LocalReport.DataSources.Add(source);
                    ReporteEmpleados.LocalReport.ReportEmbeddedResource = "SIGEEA_App.Reportes.Empleados.Re_Reporte_Empleados.rdlc";
                    ReporteEmpleados.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
