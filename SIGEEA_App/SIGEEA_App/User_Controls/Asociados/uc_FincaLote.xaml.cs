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
using SIGEEA_BO;

namespace SIGEEA_App.User_Controls.Asociados
{
    /// <summary>
    /// Interaction logic for uc_FincaLote.xaml
    /// </summary>
    public partial class uc_FincaLote : UserControl
    {
        List<SIGEEA_spObtenerFincasResult> listaFincas;
        List<SIGEEA_spObtenerLotesResult> listaLotes;
        public uc_FincaLote(string pAsociado)
        {
            InitializeComponent();
            DataClasses1DataContext dc = new DataClasses1DataContext();
            listaFincas = dc.SIGEEA_spObtenerFincas(pAsociado).ToList();

            foreach (SIGEEA_spObtenerFincasResult f in listaFincas)
                cmbFinca.Items.Add(f.Codigo_Finca);
        }


        public int getLote()
        {
            int pkLote = 0;
            foreach (SIGEEA_spObtenerLotesResult l in listaLotes)
            {
                if (l.Codigo_Lote == (string)cmbLote.SelectedValue)
                    pkLote = l.PK_Id_Lote;
            }
            return pkLote;
        }

        public int getFinca()
        {
            int pkFinca = 0;
            foreach (SIGEEA_spObtenerFincasResult f in listaFincas)
            {
                if (f.Codigo_Finca == (string)cmbFinca.SelectedValue)
                    pkFinca = f.PK_Id_Finca;
            }
            return pkFinca;
        }
        private void btnInfoFinca_Click(object sender, RoutedEventArgs e)
        {
            Informacion(true);
        }

        private void btnInfoLote_Click(object sender, RoutedEventArgs e)
        {
            Informacion(false);
        }

        private void cmbFinca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CargaLotes();
        }

        private void CargaLotes()
        {
            if ((string)cmbFinca.SelectedValue != null)
            {
                cmbLote.IsEnabled = true;
                btnInfoLote.IsEnabled = true;
                DataClasses1DataContext dc = new DataClasses1DataContext();
                foreach (SIGEEA_spObtenerFincasResult f in listaFincas)
                {
                    if (f.Codigo_Finca == (string)cmbFinca.SelectedValue)
                    {
                        listaLotes = dc.SIGEEA_spObtenerLotes(f.PK_Id_Finca).ToList();
                    }
                }

                foreach (SIGEEA_spObtenerLotesResult l in listaLotes)
                {
                    cmbLote.Items.Add(l.Codigo_Lote);
                }
            }
        }

        /// <summary>
        /// Envía los parámetros necesarios para abrir la ventana de información de la finca o el lote
        /// pAccion = true : Carga fincas
        /// pAccion = false : Carga lotes
        /// </summary>
        /// <param name="pAccion"></param>
        private void Informacion(bool pAccion)
        {
            if (pAccion)
            {
                if ((string)cmbFinca.SelectedValue != null)
                {
                    foreach (SIGEEA_spObtenerFincasResult f in listaFincas)
                    {
                        if (f.Codigo_Finca == (string)cmbFinca.SelectedValue)
                        {
                            //abre ventana de info
                        }
                    }
                }
            }
            else
            {
                if ((string)cmbLote.SelectedValue != null)
                {
                    foreach (SIGEEA_spObtenerLotesResult l in listaLotes)
                    {
                        if (l.Codigo_Lote == (string)cmbLote.SelectedValue)
                        {
                            //abre ventana de info del lote
                        }
                    }
                }
            }
        }
    }
}

