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

namespace SIGEEA_App.Ventanas_Modales.Empleados
{
    /// <summary>
    /// Interaction logic for wnwCancelarPagoEmpleado.xaml
    /// </summary>
    public partial class wnwCancelarPagoEmpleado : MetroWindow
    {
        double total = 0;
        int horas = 0;
        int pk_empleado;
        List<SIGEEA_spObtenerPagosEmpleadosPendientesResult> Lista = new List<SIGEEA_spObtenerPagosEmpleadosPendientesResult>();

        public wnwCancelarPagoEmpleado(List<SIGEEA_spObtenerPagosEmpleadosPendientesResult> pLista, int pEmpleado)
        {
            InitializeComponent();
            txbFactura.AppendText("Nombre:");
            txbFactura.AppendText(Environment.NewLine);
            Lista = pLista;
            pk_empleado = pEmpleado;

            foreach (SIGEEA_spObtenerPagosEmpleadosPendientesResult p in pLista)
            {
                total += Convert.ToDouble(p.Total.Remove(0, 1));
                horas += Convert.ToInt32(p.Diferencia);
            }

            txbFactura.AppendText("Total a cancelar: ₡" + total.ToString());
            txbFactura.AppendText(Environment.NewLine);
            txbFactura.AppendText("Horas laboradas: " + horas.ToString());
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente quiere realizar el pago?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();
                    empleado.CancelarPago(Lista, pk_empleado);
                    MessageBox.Show("Pago realizado exitosamente.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al realizar el pago solicitado: " + Ex.Message, "SIGEEA", MessageBoxButton.OK);
            }
        }
    }
}
