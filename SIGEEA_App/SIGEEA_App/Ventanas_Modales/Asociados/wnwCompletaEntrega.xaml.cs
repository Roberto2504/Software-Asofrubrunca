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
    /// Interaction logic for wnwCompletaEntrega.xaml
    /// </summary>
    public partial class wnwCompletaEntrega : MetroWindow
    {
        int PK_Factura;
        int PK_UMedida;
        public wnwCompletaEntrega(int pkFactura)
        {
            InitializeComponent();
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_spObtenerAsociadoFacturaResult informacion = dc.SIGEEA_spObtenerAsociadoFactura(pkFactura).First();
            lblAsociado.Content += " " + informacion.NombreAsociado;
            lblCedula.Content += " " + informacion.CedParticular_Persona;
            lblCodigo.Content += " " + informacion.Codigo_Asociado;
            lblFactura.Content += " " + informacion.Numero_FacAsociado;
            lblFecEntrega.Content += " " + informacion.Fecha;

            PK_Factura = pkFactura;
            List<SIGEEA_spObtenerInformacionEntregaResult> listaDetalles = dc.SIGEEA_spObtenerInformacionEntrega(pkFactura).ToList();
            PK_UMedida = dc.SIGEEA_spObtenerUnidadMedidaPorTipo(listaDetalles.First().FK_Id_TipProducto).First().PK_Id_UniMedida;
            bool color = true;

            foreach (SIGEEA_spObtenerInformacionEntregaResult e in listaDetalles)
            {
                uc_ItemEntrega item = new uc_ItemEntrega(e.Informacion, e.PK_Id_DetFacAsociado, e.FK_Id_TipProducto);
                item.Color(color);
                color = !color;
                stpContenedor.Children.Add(item);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AsociadoMantenimiento asociado = new AsociadoMantenimiento();
                foreach (uc_ItemEntrega item in stpContenedor.Children)
                {
                    if (item.Valida() == true)
                    {
                        if (item.txbCantidadNeta.Text == 0.ToString()) item.txbCantidadNeta.Text = (-1).ToString();
                        asociado.CompletarEntrega(item.getId(), Convert.ToDouble(item.txbCantidadNeta.Text), PK_UMedida, item.producto, item.getEstado());
                    }

                    else
                    {
                        item.txbCantidadNeta.Foreground = Brushes.Red;
                        throw new ArgumentException("Error de formato.");
                    }
                }
                asociado.RevisaFactura(PK_Factura);
                asociado.CantidadNetaFactura(PK_Factura);
                MessageBox.Show("Registro realizado con éxito.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
