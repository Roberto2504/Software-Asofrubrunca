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
using SIGEEA_BL.Validaciones;
using SIGEEA_App.User_Controls.Asociados;

namespace SIGEEA_App.Ventanas_Modales.Asociados
{
    /// <summary>
    /// Interaction logic for wnwCuotas.xaml
    /// </summary>
    public partial class wnwCuotas : MetroWindow
    {
        public wnwCuotas()
        {
            InitializeComponent();
            AsociadoMantenimiento asociado = new AsociadoMantenimiento();
            List<SIGEEA_spObtenerCuotasResult> listaCuotas = asociado.ListarCuotasActivas();
            bool color = true;
            stpCuotas.Children.Clear();


            foreach (SIGEEA_spObtenerCuotasResult c in listaCuotas)
            {
                uc_Cuota cuota = new uc_Cuota();
                cuota.CuotaId = c.PK_ID_CUOTA;
                cuota.NombreCuota = c.NOMBRE_CUOTA;
                cuota.MontoCuota = c.MONTO;
                cuota.Rango = c.RANGO;
                cuota.Color(color);
                color = !color;
                cuota.btnSeleccionar.Click += BtnSeleccionar_Click;
                cuota.btnSeleccionar.Tag = cuota.getIdCuota();
                stpCuotas.Children.Add(cuota);
            }
        }

        int id_cuota_asociado;
        private void CargaDeudores(int pCuota)
        {
            AsociadoMantenimiento asociado = new AsociadoMantenimiento();
            List<SIGEEA_spObtenerDeudoresCuotasResult> deudores = asociado.ListarDeudoresCuotas(pCuota);
            bool color = true;

            if (deudores.Count > 0)
            {
                stpDeudores.Children.Clear();
                grdPrimaria.Visibility = Visibility.Collapsed;
                grdSecundaria.Visibility = Visibility.Visible;
                foreach (SIGEEA_spObtenerDeudoresCuotasResult d in deudores)
                {
                    uc_DeudorCuota deudor = new uc_DeudorCuota();
                    deudor.CuotaAsociadoId = d.PK_Id_Cuota_Asociado;
                    deudor.CedulaPersona = d.Cedula;
                    deudor.NombrePersona = d.NombrePersona;
                    deudor.NombreCuota = d.NombreCuota;
                    deudor.MontoCuota = d.MontoCuota;
                    deudor.SaldoPendiente = d.SaldoPendiente;
                    deudor.Color(color);
                    deudor.btnPagar.Tag = d.PK_Id_Cuota_Asociado;
                    deudor.btnPagar.Click += BtnPagar_Click;
                    color = !color;
                    stpDeudores.Children.Add(deudor);
                }
            }
        }

        /// <summary>
        /// Evento click del uc_DeudorCuota (Pagar)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPagar_Click(object sender, RoutedEventArgs e)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            Button boton = (Button)sender;
            id_cuota_asociado = Convert.ToInt32(boton.Tag);
            grdSecundaria.Visibility = Visibility.Collapsed;
            grdIndicarMonto.Visibility = Visibility.Visible;
            lblSimboloMoneda.Content = dc.SIGEEA_spObtenerMonedaCuota(id_cuota_asociado).First().Simbolo_Moneda;
        }

        private void BtnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            //tomar en cuenta el tag
            Button boton = (Button)sender;
            CargaDeudores(Convert.ToInt32(boton.Tag));
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            grdPrimaria.Visibility = Visibility.Visible;
            grdSecundaria.Visibility = Visibility.Collapsed;
        }

        private void btnPagarCuota_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente quiere realizar el pago?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ValidacionesMantenimiento validacion = new ValidacionesMantenimiento();
                    if (validacion.Validar(txbMonto.Text, Convert.ToInt32(txbMonto.Tag)) == true)
                    {
                        AsociadoMantenimiento asociado = new AsociadoMantenimiento();
                        SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
                        double SaldoAnterior = dc.SIGEEA_Cuota_Asociados.First(c => c.PK_Id_Cuota_Asociado == id_cuota_asociado).Saldo_Cuota_Asociado;

                        if (SaldoAnterior - Convert.ToDouble(txbMonto.Text) >= 0)
                        {
                            if (asociado.RealizarPagoCuota(id_cuota_asociado, Convert.ToDouble(txbMonto.Text)) == true)
                            {
                                MessageBox.Show("Pago realizado con éxito", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                SIGEEA_spGenerarFacturaCuotaResult factura = asociado.GenerarFacturaCuota(id_cuota_asociado, Convert.ToDouble(txbMonto.Text), SaldoAnterior);
                                txbFactura.AppendText(factura.Nombre_Empresa);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.CedJuridica);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.Direccion_Empresa);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.Telefono);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.Correo);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.Fecha);
                                txbFactura.AppendText("  " + factura.Hora);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.NombreAsociado);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.CedPersona);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.CodigoAsociado);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.NombreCuota);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.Total);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText("Saldo anterior: " + dc.SIGEEA_spObtenerMonedaCuota(id_cuota_asociado).First().Simbolo_Moneda + SaldoAnterior.ToString());
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.Monto);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(factura.Saldo);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText(Environment.NewLine);
                                txbFactura.AppendText("¡Gracias por su preferencia!");
                                grdIndicarMonto.Visibility = Visibility.Collapsed;
                                grdFactura.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                throw new System.ArgumentException("Ha sido imposible realizar el pago.");
                            }
                        }
                        else
                        {
                            throw new System.ArgumentException("El saldo actual es menor que el monto digitado.");
                        }
                    }
                    else
                    {
                        BrushConverter bc = new BrushConverter();
                        txbMonto.Foreground = (Brush)bc.ConvertFrom("#FFFF0404");
                        throw new System.ArgumentException("El formato del monto es incorrecto");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            grdIndicarMonto.Visibility = Visibility.Collapsed;
            grdSecundaria.Visibility = Visibility.Visible;
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
