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
using SIGEEA_App.User_Controls;
using SIGEEA_App.Ventanas_Modales.Empleados;

namespace SIGEEA_App.Ventanas_Modales.Empleados
{

    /// <summary>
    /// Interaction logic for wnwPagoEmpleados.xaml
    /// </summary>
    public partial class wnwPagoEmpleados : MetroWindow
    {
        SIGEEA_spObtenerEmpleadoResult Empleado;
        public wnwPagoEmpleados(string pCedula)
        {
            InitializeComponent();
            EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();
            bool color = true;
            Empleado = empleado.AutenticaEmpleado(pCedula);


            //dtgPagos.ItemsSource = empleado.ListarPagosEmpleados(pCedula);

            List<SIGEEA_spObtenerPagosEmpleadosPendientesResult> lista = new List<SIGEEA_spObtenerPagosEmpleadosPendientesResult>();
            lista = empleado.ListarPagosEmpleados(pCedula);


            foreach (SIGEEA_spObtenerPagosEmpleadosPendientesResult p in lista)
            {
                uc_PagoEmpleado Pago = new uc_PagoEmpleado();
                Pago.PagoId = p.PK_Id_HorLaboradas;
                Pago.Fechas = p.Fecha;
                Pago.CantidadHoras = Convert.ToInt32(p.Diferencia);
                Pago.Puestos = p.Nombre_Puesto;
                Pago.Tarifas = p.Tarifa;
                Pago.Totales = p.Total;
                Pago.Totale = Convert.ToDouble(p.eTotal);
                Pago.Tarifae = p.eTarifa;
                Pago.Color(color);
                color = !color;
                stpPagos.Children.Add(Pago);
            }
        }

        private void rbtTodos_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (uc_PagoEmpleado uPago in stpPagos.Children)
            {
                uPago.cbxCancelar.IsChecked = false;

            }
        }

        private void rbtTodos_Checked(object sender, RoutedEventArgs e)
        {
            foreach (uc_PagoEmpleado uPago in stpPagos.Children)
            {
                uPago.cbxCancelar.IsChecked = true;
            }
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            List<SIGEEA_spObtenerPagosEmpleadosPendientesResult> lista = new List<SIGEEA_spObtenerPagosEmpleadosPendientesResult>();

            foreach (uc_PagoEmpleado uPago in stpPagos.Children)
            {
                if (uPago.cbxCancelar.IsChecked == true)
                {
                    SIGEEA_spObtenerPagosEmpleadosPendientesResult pago = new SIGEEA_spObtenerPagosEmpleadosPendientesResult();
                    pago.Fecha = uPago.Fechas;
                    pago.Diferencia = uPago.CantidadHoras;
                    pago.Nombre_Puesto = uPago.Puestos;
                    pago.Tarifa = uPago.Tarifas;
                    pago.Total = uPago.Totales;
                    pago.PK_Id_HorLaboradas = uPago.PagoId;
                    pago.eTotal =  Math.Round(uPago.Totale,0);
                    pago.eTarifa = uPago.Tarifae;

                    lista.Add(pago);
                }
            }
            wnwCancelarPagoEmpleado ventana = new wnwCancelarPagoEmpleado(lista, Empleado.PK_Id_Empleado);
            ventana.ShowDialog();
            this.Close();
        }
    }
}

