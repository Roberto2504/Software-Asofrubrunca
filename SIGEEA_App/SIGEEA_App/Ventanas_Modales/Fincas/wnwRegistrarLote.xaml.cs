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
using SIGEEA_App.Ventanas_Modales.Fincas;
namespace SIGEEA_App.Ventanas_Modales.Fincas
{
    /// <summary>
    /// Interaction logic for wnwRegistrarLote.xaml
    /// </summary>
    public partial class wnwRegistrarLote : MetroWindow
    {
        public wnwRegistrarLote(string ptipo, string pTamaño, int pNumLote)
        {
            InitializeComponent();
            tipo = ptipo;
            txtTipo.Text = ptipo;

            if (tipo == "Registrar")
            {
                txtTamaño.Text = "";
                numLote = pNumLote;
            }
            else
            {
                txtTamaño.Text = pTamaño;
                numLote = pNumLote;
            }

        }
        string tipo;
        string tamaño;
        int numLote;
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == "Registrar")
            {
                tamaño = txtTamaño.Text;
                ((wnwRegistrarFinca)this.Owner).agregarLote(tamaño, Lote:null);
                this.Close();
            }
            else
            {
                tamaño = txtTamaño.Text;
                ((wnwRegistrarFinca)this.Owner).EditarLote(numLote, tamaño);
                this.Close();
            }

        }
    }
}
