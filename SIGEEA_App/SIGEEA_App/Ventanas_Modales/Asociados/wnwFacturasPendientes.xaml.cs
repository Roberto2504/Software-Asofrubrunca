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
    /// Interaction logic for wnwFacturasPendientes.xaml
    /// </summary>
    public partial class wnwFacturasPendientes : MetroWindow
    {
        public wnwFacturasPendientes(string pAsociado, bool pSolicitud)
        {
            InitializeComponent();
            Inicializar(pSolicitud, pAsociado);
        }

        private void BtnDetalles_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Inicializar(bool pSolicitud, string pAsociado)
        {
            //pSolicitud = true : si se desean obtener facturas pendientes
            //pSolicitud = false : si se desean obtener facturas incompletas
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<SIGEEA_spObtenerFacturasPendientesAsocResult> listaFacturasPendientes = new List<SIGEEA_spObtenerFacturasPendientesAsocResult>();
            List<SIGEEA_spObtenerFacturasIncompletasAsocResult> listaFacturasIncompletas = new List<SIGEEA_spObtenerFacturasIncompletasAsocResult>();


            if (pSolicitud == false)
            {
                listaFacturasIncompletas = dc.SIGEEA_spObtenerFacturasIncompletasAsoc(pAsociado).ToList();

                if (listaFacturasIncompletas.Count > 0)
                {
                    bool color = true;
                    foreach (SIGEEA_spObtenerFacturasIncompletasAsocResult f in listaFacturasIncompletas)
                    {
                        uc_FacturaEntrega factura = new uc_FacturaEntrega(pSolicitud);
                        factura.FacturaId = f.PK_Id_FacAsociado;
                        factura.FacturaFecha = f.FECHA;

                        factura.btnDetalles.Click += BtnDetalles_Click; ;
                        factura.Color(color);
                        color = !color;
                        stpContenedor.Children.Add(factura);
                    }
                }
            }
            else
            {
                listaFacturasPendientes = dc.SIGEEA_spObtenerFacturasPendientesAsoc(pAsociado).ToList();

                if (listaFacturasPendientes.Count > 0)
                {
                    bool color = true;
                    foreach (SIGEEA_spObtenerFacturasPendientesAsocResult f in listaFacturasPendientes)
                    {
                        uc_FacturaEntrega factura = new uc_FacturaEntrega(pSolicitud);
                        factura.FacturaId = f.PK_Id_FacAsociado;
                        factura.FacturaFecha = f.FECHA;

                        factura.btnDetalles.Click += BtnDetalles_Click; ;
                        factura.Color(color);
                        color = !color;
                        stpContenedor.Children.Add(factura);
                    }
                }
            }
            if (listaFacturasIncompletas.Count == 0 && listaFacturasPendientes.Count == 0)
            {
                Label lblVacio = new Label();
                lblVacio.Foreground = Brushes.IndianRed;
                lblVacio.FontSize = 18;
                lblVacio.Width = 430;
                lblVacio.Content = "No hay registros.";
                lblVacio.FontWeight = FontWeights.ExtraBold;
                stpContenedor.Children.Add(lblVacio);
            }
        }
    }
}
