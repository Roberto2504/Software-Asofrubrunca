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
using SIGEEA_App.User_Controls.Asociados;
using SIGEEA_BO;
using SIGEEA_BL;
using SIGEEA_BL.Validaciones;

namespace SIGEEA_App.Ventanas_Modales.Asociados
{
    /// <summary>
    /// Interaction logic for wnwAsambleas.xaml
    /// </summary>
    public partial class wnwAsambleas : MetroWindow
    {
        public wnwAsambleas()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            txbNumActa.Text = String.Empty;
            txbObservaciones.Text = String.Empty;
            dtpFecha.Text = String.Empty;
            grdPrincipal.Visibility = Visibility.Collapsed;
            grdRegistrar.Visibility = Visibility.Visible;
        }

        private void btnAdministrar_Click(object sender, RoutedEventArgs e)
        {
            CargarAsambleas();
        }

        private void CargarAsambleas()
        {
            stpAsambleas.Children.Clear();
            grdPrincipal.Visibility = Visibility.Collapsed;
            grdListar.Visibility = Visibility.Visible;
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<SIGEEA_spObtenerAsambleasResult> lista = dc.SIGEEA_spObtenerAsambleas().ToList();
            bool color = true;
            foreach (SIGEEA_spObtenerAsambleasResult a in lista)
            {
                uc_Asamblea asamblea = new uc_Asamblea(a.PK_Id_Asamblea, a.Fecha, a.TipoAsamblea, a.NumActa);
                asamblea.Color(color);
                asamblea.btnDetalles.Tag = asamblea.AsambleaId;
                asamblea.btnDetalles.Click += BtnDetalles_Click;
                stpAsambleas.Children.Add(asamblea);
                color = !color;
            }
        }

        private void BtnDetalles_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            wnwDetallesAsamblea ventana = new wnwDetallesAsamblea(Convert.ToInt32(btn.Tag));
            ventana.ShowDialog();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidacionesMantenimiento validacion = new ValidacionesMantenimiento();
                bool correcto = true;

                if (validacion.Validar(txbNumActa.Text, 4) == true) correcto = true;
                else
                {
                    correcto = false;
                    txbNumActa.BorderBrush = Brushes.Red;
                }


                if (correcto == true)
                {
                    AsociadoMantenimiento asociado = new AsociadoMantenimiento();
                    SIGEEA_Asamblea nuevaAsamblea = new SIGEEA_Asamblea();
                    nuevaAsamblea.Fecha_Asamblea = dtpFecha.SelectedDate.Value;
                    nuevaAsamblea.NumActa_Asamblea = txbNumActa.Text;
                    nuevaAsamblea.Observaciones_Asamblea = txbObservaciones.Text;
                    if (cmbTipoAsamblea.SelectedIndex == 0) nuevaAsamblea.Tipo_Asamblea = 1;
                    else if (cmbTipoAsamblea.SelectedIndex == 1) nuevaAsamblea.Tipo_Asamblea = 2;
                    asociado.RegistraAsamblea(nuevaAsamblea);
                    MessageBox.Show("¡Asamblea registrada con éxito!", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    throw new ArgumentException("Formato incorrecto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            grdListar.Visibility = Visibility.Collapsed;
            grdRegistrar.Visibility = Visibility.Collapsed;
            grdPrincipal.Visibility = Visibility.Visible;
        }
    }
}
