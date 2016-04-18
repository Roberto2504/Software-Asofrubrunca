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
using SIGEEA_App.Ventanas_Modales.Productos;

namespace SIGEEA_App.Ventanas_Modales.Productos
{
    /// <summary>
    /// Interaction logic for wnwEntregaProducto.xaml
    /// </summary>
    public partial class wnwEntregaProducto : MetroWindow
    {
        SIGEEA_spObtenerAsociadoResult asociado;
        List<SIGEEA_UniMedida> listaMedida;
        public wnwEntregaProducto(SIGEEA_spObtenerAsociadoResult pAsociado)
        {
            InitializeComponent();
            uc_IngresoProducto uProducto = new uc_IngresoProducto(pAsociado.Codigo_Asociado);
            DataClasses1DataContext dc = new DataClasses1DataContext();
            stpContenedor.Children.Add(uProducto);
            asociado = pAsociado;
            lblNombreAsociado.Content += " " + asociado.PriNombre_Persona + " " + asociado.PriApellido_Persona + " " + asociado.SegApellido_Persona;
            lblCedulaAsociado.Content += " " + asociado.CedParticular_Persona.ToString();
            lblCodigoAsociado.Content += " " + asociado.Codigo_Asociado.ToString();
            listaMedida = dc.SIGEEA_UniMedidas.ToList();

            foreach (SIGEEA_UniMedida p in listaMedida) cmbUniMedida.Items.Add(p.Nombre_UniMedida);
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            uc_IngresoProducto uProducto = new uc_IngresoProducto(asociado.Codigo_Asociado);
            stpContenedor.Children.Add(uProducto);
        }

        private void btnFacturar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Realmente quiere registrar la entrega?", "SIGEEA", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                RegistraEntrega();
            }
        }

        private void RegistraEntrega()
        {
            try
            {
                if (cmbUniMedida.SelectedValue != null)
                {
                    AsociadoMantenimiento asociadoM = new AsociadoMantenimiento();
                    List<SIGEEA_DetFacAsociado> listaDetalles = new List<SIGEEA_DetFacAsociado>();

                    SIGEEA_FacAsociado factura = new SIGEEA_FacAsociado();
                    factura.Estado_FacAsociado = true;
                    factura.FecEntrega_FacAsociado = DateTime.Now;
                    factura.FK_Id_Asociado = asociado.PK_Id_Asociado;
                    factura.FK_Id_UniMedida = getMedida();


                    foreach (uc_IngresoProducto ip in stpContenedor.Children)
                    {
                        SIGEEA_DetFacAsociado fac = new SIGEEA_DetFacAsociado();
                        fac.CanTotal_DetFacAsociado = ip.getCantidad();
                        fac.FK_Id_Lote = ip.getLote();
                        fac.Mercado_DetFacAsociado = ip.getMercado();
                        fac.FK_Id_PreProCompra = ip.getProducto();//Se le asigna la PK del producto, en la función de registrar de AsociadoMantenimiento se hace el cambio necesario.
                        listaDetalles.Add(fac);
                    }
                    asociadoM.RegistraEntrega(factura, listaDetalles);
                    MessageBox.Show("Entrega registrada con éxito.", "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    wnwFacturaEntrega ventana = new wnwFacturaEntrega(factura.PK_Id_FacAsociado);
                    ventana.ShowDialog();
                    this.Close();
                }
                else { throw new ArgumentException("Debe seleccionar la unidad de medida."); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public int getMedida()
        {
            int pkMedida = 0;
            foreach (SIGEEA_UniMedida m in listaMedida)
            {
                if ((string)cmbUniMedida.SelectedValue == m.Nombre_UniMedida) pkMedida = m.PK_Id_UniMedida;
            }
            return pkMedida;
        }
    }
}

