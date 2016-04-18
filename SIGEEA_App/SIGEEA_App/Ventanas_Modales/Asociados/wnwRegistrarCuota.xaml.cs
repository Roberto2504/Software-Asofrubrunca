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
using SIGEEA_BL.Validaciones;
using SIGEEA_BL;
using SIGEEA_BO;

namespace SIGEEA_App.Ventanas_Modales.Asociados
{
    /// <summary>
    /// Interaction logic for wnwRegistrarCuota.xaml
    /// </summary>   
    public partial class wnwRegistrarCuota : MetroWindow
    {
        int pk_cuota;
        public wnwRegistrarCuota(int pIdCuota)
        {
            InitializeComponent();
            if (pIdCuota != 0)
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                SIGEEA_Cuota cuota = dc.SIGEEA_Cuotas.First(c => c.PK_Id_Cuota == pIdCuota);
                txbNombre.Text = cuota.Nombre_Cuota;
                txbMonto.Text = cuota.Monto_Cuota.ToString();
                dtpFecInicio.Text = cuota.FecInicio_Cuota.ToString();
                dtpFecFin.Text = cuota.FecFin_Cuota.ToString();
                ucMoneda.setMoneda(cuota.FK_Id_Moneda);
                pk_cuota = pIdCuota;
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidacionesMantenimiento validacion = new ValidacionesMantenimiento();
                bool valido = true;
                foreach (TextBox txb in grdValidar.Children)
                {
                    BrushConverter bc = new BrushConverter();
                    txb.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                    if (validacion.Validar(txb.Text, Convert.ToInt32(txb.Tag)) == false)
                    {
                        valido = false;
                        txb.Foreground = (Brush)bc.ConvertFrom("#FFFF0404");
                    }
                }

                if (valido == true)
                {
                    SIGEEA_Cuota cuota = new SIGEEA_Cuota();
                    AsociadoMantenimiento asociado = new AsociadoMantenimiento();
                    cuota.Nombre_Cuota = txbNombre.Text;
                    cuota.Monto_Cuota = Convert.ToDouble(txbMonto.Text);
                    cuota.FecInicio_Cuota = dtpFecInicio.SelectedDate.Value;
                    cuota.FecFin_Cuota = dtpFecFin.SelectedDate.Value;
                    cuota.FK_Id_Moneda = ucMoneda.getMoneda();
                    if (pk_cuota == 0) asociado.RegistrarCuota(cuota);
                    else
                    {
                        cuota.PK_Id_Cuota = pk_cuota;
                        asociado.EditarCuota(cuota);
                    }
                    MessageBox.Show("La cuota se ha registrado con éxito.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    throw new System.ArgumentException("Los datos ingresados no coinciden con los formatos requeridos.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
