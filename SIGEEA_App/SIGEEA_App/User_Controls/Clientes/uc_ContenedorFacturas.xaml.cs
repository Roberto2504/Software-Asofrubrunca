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
            tipo = pTipo;
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
        string tipo;
        string saldo = "";
        FacturaClienteMantenimiento facCliMan = new FacturaClienteMantenimiento();
        public string SepararMiles(double Cantidad)
        {
            return Cantidad.ToString("N2");
        }
        public void CargarPorIdCliente(int idCliente)
        {
            foreach (SIGEEA_spListarFacturaPendientePorClienteResult pendiente in facCliMan.ListarPendientePorCliente(idCliente))
            {
                saldo = "";
                uc_Factura nueva = new uc_Factura();
                nueva.txtNumFacuta.Text = pendiente.PK_Id_FacCliente.ToString();
                nueva.txbNomCliente.Text = pendiente.NombreCompleto;

                nueva.txbFecProPago.Text = pendiente.FecProPago_CreCliente.ToShortDateString();
                nueva.txbFecLimPago.Text = pendiente.FecLimPago_CreCliente.ToShortDateString();
                for (int i = 0; i < pendiente.Saldo.Length; i++)
                {
                    if (pendiente.Saldo[i] == '.') saldo += ','; else saldo += pendiente.Saldo[i];
                }
                nueva.txbMonto.Text = pendiente.Saldo[0]+SepararMiles(Convert.ToDouble(saldo.Remove(0,1)));
                nueva.btnAbono.Tag = pendiente.PK_Id_FacCliente;
                nueva.btnAbono.Click += BtnAbono_Click;
                wprPrincipal.Children.Add(nueva);
            }
        }
        public void CargarPorIdFactura(int idFactura)
        {
            foreach (SIGEEA_spListarFacturaPendientePorFacturaResult pendiente in facCliMan.ListarPendientePorFactura(idFactura))
            {
                saldo = "";
                uc_Factura nueva = new uc_Factura();
                nueva.txtNumFacuta.Text = pendiente.PK_Id_FacCliente.ToString();
                nueva.txbNomCliente.Text = pendiente.NombreCompleto;
                nueva.txbFecProPago.Text = pendiente.FecProPago_CreCliente.ToShortDateString();
                nueva.txbFecLimPago.Text = pendiente.FecLimPago_CreCliente.ToShortDateString();
                for (int i = 0; i < pendiente.Saldo.Length; i++)
                {
                    if (pendiente.Saldo[i] == '.') saldo += ','; else saldo += pendiente.Saldo[i];
                }
                nueva.txbMonto.Text = pendiente.Saldo[0] + SepararMiles(Convert.ToDouble(saldo.Remove(0, 1)));
                nueva.btnAbono.Tag = pendiente.PK_Id_FacCliente;
                nueva.btnAbono.Click += BtnAbono_Click;
                wprPrincipal.Children.Add(nueva);
            }
        }



        public void CargarFacturasPendientes()
        {
            wprPrincipal.Children.Clear();
            foreach (SIGEEA_spListarFacturaPendienteClienteResult pendiente in facCliMan.ListarPendiente())
            {
                saldo = "";
                uc_Factura nueva = new uc_Factura();
                nueva.txtNumFacuta.Text = pendiente.PK_Id_FacCliente.ToString();
                nueva.txbNomCliente.Text = pendiente.NombreCompleto;
                nueva.txbFecProPago.Text = pendiente.FecProPago_CreCliente.ToShortDateString();
                nueva.txbFecLimPago.Text = pendiente.FecLimPago_CreCliente.ToShortDateString();
                for (int i = 0; i < pendiente.Saldo.Length; i++)
                {
                    if (pendiente.Saldo[i] == '.') saldo += ','; else saldo += pendiente.Saldo[i];
                }
                nueva.txbMonto.Text = pendiente.Saldo[0] + SepararMiles(Convert.ToDouble(saldo.Remove(0, 1)));
                nueva.btnAbono.Tag = pendiente.PK_Id_FacCliente;
                nueva.btnAbono.Click += BtnAbono_Click;
                wprPrincipal.Children.Add(nueva);
            }
        }

        private void BtnAbono_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            wnwAbonoFactura nueva = new wnwAbonoFactura(Convert.ToInt32(boton.Tag));
            nueva.Closed += Nueva_Closed;
            nueva.ShowDialog();

        }

        private void Nueva_Closed(object sender, EventArgs e)
        {
            wprPrincipal.Children.Clear();
            if (tipo == "Todas")
            {
                CargarFacturasPendientes();
            }
            if (tipo == "Por cliente")
            {
                CargarPorIdCliente(idCliente);
            }
            if (tipo == "Por factura")
            {
                CargarPorIdFactura(idFactura);
            }
        }
    }
}
