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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIGEEA_BL;
using SIGEEA_BO;
using SIGEEA_App.Ventanas_Modales.Clientes;
namespace SIGEEA_App.User_Controls.Clientes
{
    /// <summary>
    /// Interaction logic for uc_ContenedorFacturas.xaml
    /// </summary>
    public partial class uc_ContenedorFacturas : UserControl
    {
        public uc_ContenedorFacturas(int pidFactura, int pidCliente, string pTipo)
        {
            InitializeComponent();
            idCliente = pidCliente;
            idFactura = pidFactura;
            if (pTipo == "Todas")
            {
                CargarFacturasPendientes();
            }
            if (pTipo == "Por cliente")
            {
                CargarPorIdCliente(pidCliente);
            }
            if (pTipo == "Por factura")
            {
                CargarPorIdFactura(pidFactura);
            }
        }
        int idCliente, idFactura;

        FacturaClienteMantenimiento facCliMan = new FacturaClienteMantenimiento();
        public void CargarPorIdCliente(int idCliente)
        {
            foreach (SIGEEA_spListarFacturaPendientePorClienteResult pendiente in facCliMan.ListarPendientePorCliente(idCliente))
            {
                uc_Factura nueva = new uc_Factura();
                nueva.txtNumFacuta.Text = pendiente.PK_Id_FacCliente.ToString();
                nueva.txbNomCliente.Text = pendiente.NombreCompleto;

                nueva.txbFecProPago.Text = pendiente.FecProPago_CreCliente.ToShortDateString();
                nueva.txbFecLimPago.Text = pendiente.FecLimPago_CreCliente.ToShortDateString();
                nueva.txbMonto.Text = pendiente.Saldo;
                nueva.btnAbono.Tag = pendiente.PK_Id_FacCliente;
                nueva.btnAbono.Click += BtnAbono_Click;
                nueva.btnVerFactura.Click += BtnVerFactura_Click;
                wprPrincipal.Children.Add(nueva);
            }
        }
        public void CargarPorIdFactura(int idFactura)
        {
            foreach (SIGEEA_spListarFacturaPendientePorFacturaResult pendiente in facCliMan.ListarPendientePorFactura(idFactura))
            {
                uc_Factura nueva = new uc_Factura();
                nueva.txtNumFacuta.Text = pendiente.PK_Id_FacCliente.ToString();
                nueva.txbNomCliente.Text = pendiente.NombreCompleto;
                nueva.txbFecProPago.Text = pendiente.FecProPago_CreCliente.ToShortDateString();
                nueva.txbFecLimPago.Text = pendiente.FecLimPago_CreCliente.ToShortDateString();
                nueva.txbMonto.Text = pendiente.Saldo;
                nueva.btnAbono.Tag = pendiente.PK_Id_FacCliente;
                nueva.btnAbono.Click += BtnAbono_Click;
                nueva.btnVerFactura.Click += BtnVerFactura_Click;
                wprPrincipal.Children.Add(nueva);
            }
        }



        public void CargarFacturasPendientes()
        {
            foreach (SIGEEA_spListarFacturaPendienteClienteResult pendiente in facCliMan.ListarPendiente())
            {
                uc_Factura nueva = new uc_Factura();
                nueva.txtNumFacuta.Text = pendiente.PK_Id_FacCliente.ToString();
                nueva.txbNomCliente.Text = pendiente.NombreCompleto;
                nueva.txbFecProPago.Text = pendiente.FecProPago_CreCliente.ToShortDateString();
                nueva.txbFecLimPago.Text = pendiente.FecLimPago_CreCliente.ToShortDateString();
                nueva.txbMonto.Text = pendiente.Saldo;
                nueva.btnAbono.Tag = pendiente.PK_Id_FacCliente;
                nueva.btnAbono.Click += BtnAbono_Click;
                nueva.btnVerFactura.Click += BtnVerFactura_Click;
                wprPrincipal.Children.Add(nueva);
            }
        }

        private void BtnVerFactura_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void BtnAbono_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            wnwAbonoFactura nueva = new wnwAbonoFactura(Convert.ToInt32(boton.Tag));
            nueva.ShowDialog();

        }
    }
}
