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
using SIGEEA_App.Ventanas_Modales.Direcciones;
using SIGEEA_App.Ventanas_Modales.Fincas;
using SIGEEA_App.User_Controls.Fincas;
namespace SIGEEA_App.Ventanas_Modales.Fincas
{
    /// <summary>
    /// Interaction logic for wnwRegistrarFinca.xaml
    /// </summary>
    public partial class wnwRegistrarFinca : MetroWindow
    {
        public wnwRegistrarFinca(string ptipo, int pPkAsociado)
        {
            InitializeComponent();
            tipo = ptipo;
            ListarTipoFinca();
            asociado = manFinca.ObtenerAsociado(pPkAsociado);
            ObtenerDatos(asociado.FK_Id_Persona);
            if (ptipo == "Editar")
            {

            }
        }
        string tipo;
        string nombreCompleto, Apellidos;
        List<string> listaTipoFinca = new List<string>();
        string tamaño;
        string tipoFinca;
        FincaMantenimiento manFinca = new FincaMantenimiento();
        SIGEEA_Asociado asociado = new SIGEEA_Asociado();

        public void CargarDatos()
        {

        }
        public void ListarTipoFinca()
        {
            listaTipoFinca.Add("Alquilada");
            listaTipoFinca.Add("Propia");
            cmbTiposDeFinca.ItemsSource = listaTipoFinca;

        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void btnAgregarDireccion_Click(object sender, RoutedEventArgs e)
        {



        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            SIGEEA_Finca nueva = new SIGEEA_Finca();

            int idFinca;
            if (tipoFinca == "Alquilada")
            {
                nueva.Alquilada_Finca = true;
            }
            else
            {
                nueva.Alquilada_Finca = false;
            }
            nueva.ApeDuenno_Finca = txtApellidos.Text;
            nueva.NomDuenno_Finca = txtNombreComplet.Text;
            nueva.Estado_Finca = "1";
            nueva.NumRegistro_Finca = txtNumeroRegistro.Text;
            nueva.FK_Id_Direccion = 0;
            idFinca = manFinca.RegistrarFinca(nueva, asociado);
            foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
            {
                SIGEEA_Lote nuevolote = new SIGEEA_Lote();
                nuevolote.Tamanno_Lote = lote.txbTamaño.Text;
                nuevolote.Codigo_Lote = "F" + idFinca + "L" + lote.txbNumero.Text;
                nuevolote.FK_Id_Finca = idFinca;
                manFinca.RegistrarLote(nuevolote);
            }
            wnwDirecciones nuevaDireccion = new wnwDirecciones(pCedula_pCodigo: null, tipoPersona: "Finca", pkFinca: idFinca);
            nuevaDireccion.ShowDialog();

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarLote nuevo = new wnwRegistrarLote(ptipo: "Agregar", pTamaño: null, pNumLote: 0);
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
        int Conta = 1;
        public void agregarLote(string tamaño)
        {
            uc_Lote nuevo = new uc_Lote();
            nuevo.txbTamaño.Text = tamaño;
            nuevo.txbNumero.Text = Conta.ToString();
            nuevo.btnOpcion.Tag = Conta;
            nuevo.btnOpcion2.Tag = Conta;
            nuevo.btnOpcion.Click += BtnOpcion_Click;
            nuevo.btnOpcion2.Click += BtnOpcion2_Click;
            Conta++;
            stpLotes.Children.Add(nuevo);
        }

        private void BtnOpcion2_Click(object sender, RoutedEventArgs e)
        {
            var boton = (Button)sender;
            foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
            {
                if (boton.Tag.ToString() == lote.txbNumero.Text)
                {
                    MessageBoxResult m = MessageBox.Show("Esta seguro que desea eliminar este lote", "Mensaje de Confirmación", MessageBoxButton.YesNo);
                    if (m == MessageBoxResult.Yes)
                    {
                        stpLotes.Children.Remove(lote);
                        RestablecerCuentaLote();
                    }
                }

            }
        }
        public void RestablecerCuentaLote()
        {
            Conta = 1;
            foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
            {

                lote.txbNumero.Text = Conta.ToString();
                lote.btnOpcion.Tag = Conta;
                lote.btnOpcion2.Tag = Conta;
                Conta++;

            }
        }
        public void EditatLote(int numLote, string tamaño)
        {

            foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
            {
                if (Convert.ToInt32(lote.txbNumero.Text) == numLote)
                {
                    lote.txbTamaño.Text = tamaño;

                }


            }
        }

        private void BtnOpcion_Click(object sender, RoutedEventArgs e)
        {
            Button btnLote = (Button)sender;

            foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
            {
                if (btnLote.Tag.ToString() == lote.txbNumero.Text)
                {
                    tamaño = lote.txbTamaño.Text;
                }
            }


            wnwRegistrarLote nuevo = new wnwRegistrarLote(ptipo: "Editar", pTamaño: tamaño, pNumLote: Convert.ToInt32(btnLote.Tag));
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
        public void ObtenerDatos(int pFkPersona)
        {
            SIGEEA_Persona nueva = manFinca.ObtenerInfoAsociado(pFkPersona);
            nombreCompleto = string.Concat(nueva.PriNombre_Persona, " ", nueva.SegNombre_Persona);
            Apellidos = string.Concat(nueva.PriApellido_Persona, " ", nueva.SegApellido_Persona);
        }
        private void cmbTiposDeFinca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tipoFinca = this.cmbTiposDeFinca.SelectedItem.ToString();

            if (tipoFinca == "Propia")
            {
                grdDatosDueño.IsEnabled = false;
                txtNombreComplet.Text = nombreCompleto;
                txtApellidos.Text = Apellidos;
            }
            else
            {
                grdDatosDueño.IsEnabled = true;
                txtNombreComplet.Text = "";
                txtApellidos.Text = "";
            }
        }
    }
}
