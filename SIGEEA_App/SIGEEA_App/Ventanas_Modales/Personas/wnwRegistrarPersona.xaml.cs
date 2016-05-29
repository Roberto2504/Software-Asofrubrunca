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

namespace SIGEEA_App.Ventanas_Modales.Personas
{
    /// <summary>
    /// Interaction logic for wnwRegistrarPersona.xaml
    /// </summary>
    public partial class wnwRegistrarPersona : MetroWindow
    {
        string tipoPersona;
        SIGEEA_Persona nuevaPersona;
        bool editar;
        int pk_Persona;

        ClienteMantenimiento mantCliente = new ClienteMantenimiento();
        public wnwRegistrarPersona(string pTipoPersona, SIGEEA_spObtenerAsociadoResult pAsociado, SIGEEA_spObtenerEmpleadoResult pEmpleado, SIGEEA_spObtenerClienteResult pCliente)
        {
            InitializeComponent();
            tipoPersona = pTipoPersona;
            btnSiguiente.Click += BtnSiguiente_Click;
            btnRegistrar.Click += BtnRegistrar_Click;
            PersonaMantenimiento persona = new PersonaMantenimiento();
            //cbxNacionalidad.ItemsSource = persona.ListarNacionalidades();
            if (pAsociado != null)//Si se desea editar un asociado
            {
                editar = true;
                CargarInformacionAsociado(pAsociado);
                pk_Persona = pAsociado.PK_Id_Persona;
            }
            if (pEmpleado != null)//Si se desea editar un empleado
            {
                editar = true;
                CargarInformacionEmpleado(pEmpleado);
                pk_Persona = pEmpleado.PK_Id_Persona;
            }
            if (pCliente != null)//Si se desea editar un cliente
            {
                editar = true;
                CargarInformacionCliente(pCliente);
                pk_Persona = pCliente.PK_Id_Persona;
            }
        }

        public void RegistrarPersona()
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
                        //txb.Foreground = (Brush)bc.ConvertFrom("#FFFF0404");
                        txb.BorderBrush = Brushes.Red;
                    }
                }
                if (valido == true)
                {
                    nuevaPersona = new SIGEEA_Persona();
                    nuevaPersona.CedParticular_Persona = txbCedula.Text;
                    nuevaPersona.FecNacimiento_Persona = dtpFecNacimiento.SelectedDate.Value;
                    nuevaPersona.FK_Id_Direccion = null;
                    nuevaPersona.Tipo_Persona = true;
                    nuevaPersona.CedJuridica_Persona = null;
                    nuevaPersona.FK_Id_Nacionalidad = ucNacionalidad.getNacionalidad();
                    ComboBoxItem item = (ComboBoxItem)cbxGenero.SelectedItem;
                    nuevaPersona.Genero_Persona = item.Content.ToString();
                    nuevaPersona.PriApellido_Persona = txbPriApellido.Text;
                    nuevaPersona.PriNombre_Persona = txbPriNombre.Text;
                    nuevaPersona.SegApellido_Persona = txbSegApellido.Text;
                    nuevaPersona.SegNombre_Persona = txbSegNombre.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Los datos ingresados no coinciden con los formatos del sistema: " + ex.Message, "SIGEEA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CargarInformacionAsociado(SIGEEA_spObtenerAsociadoResult pAsociado)
        {
            txbCedula.Text = pAsociado.CedParticular_Persona;
            txbPriNombre.Text = pAsociado.PriNombre_Persona;
            txbSegNombre.Text = pAsociado.SegNombre_Persona;
            txbPriApellido.Text = pAsociado.PriApellido_Persona;
            txbSegApellido.Text = pAsociado.SegApellido_Persona;
            dtpFecNacimiento.Text = pAsociado.FecNacimiento_Persona.ToString();
            if (pAsociado.Genero_Persona == "M") cbxGenero.SelectedIndex = 0; else cbxGenero.SelectedIndex = 1;
            DataClasses1DataContext dc = new DataClasses1DataContext();
            ucNacionalidad.setNacionalidad(dc.SIGEEA_Nacionalidads.First(c => c.PK_Id_Nacionalidad == pAsociado.FK_Id_Nacionalidad).Nombre_Nacionalidad);
            ucEstrellas.cargaEstrellas((float)dc.SIGEEA_spObtenerCategoriaAsociado(pAsociado.PK_Id_Asociado).First().Categoria);
            ucEstrellas.Visibility = Visibility.Visible;
        }

        public void CargarInformacionEmpleado(SIGEEA_spObtenerEmpleadoResult pEmpleado)
        {
            txbCedula.Text = pEmpleado.CedParticular_Persona;
            txbPriNombre.Text = pEmpleado.PriNombre_Persona;
            txbSegNombre.Text = pEmpleado.SegNombre_Persona;
            txbPriApellido.Text = pEmpleado.PriApellido_Persona;
            txbSegApellido.Text = pEmpleado.SegApellido_Persona;
            dtpFecNacimiento.Text = pEmpleado.FecNacimiento_Persona.ToString();
            if (pEmpleado.Genero_Persona == "M") cbxGenero.SelectedIndex = 0; else cbxGenero.SelectedIndex = 1;
            DataClasses1DataContext dc = new DataClasses1DataContext();
            ucNacionalidad.setNacionalidad(pEmpleado.Nombre_Nacionalidad);
            txbAdicional.Text = pEmpleado.Observaciones_Escolaridad;
            chkEscribir.IsChecked = pEmpleado.Escribir_Escolaridad;
            chkLeer.IsChecked = pEmpleado.Leer_Escolaridad;
            cmbGradoAcad.SelectedIndex = pEmpleado.GradoAcad_Escolaridad - 1;
        }
        public void CargarInformacionCliente(SIGEEA_spObtenerClienteResult pCliente)
        {
            txbCedula.Text = pCliente.CedParticular_Persona;
            txbPriNombre.Text = pCliente.PriNombre_Persona;
            txbSegNombre.Text = pCliente.SegNombre_Persona;
            txbPriApellido.Text = pCliente.PriApellido_Persona;
            txbSegApellido.Text = pCliente.SegApellido_Persona;
            dtpFecNacimiento.Text = pCliente.FecNacimiento_Persona.ToString();
            ObtenerCategorias(pCliente.PK_Id_CatCliente);
            lbPkCatCliente.Content = pCliente.PK_Id_CatCliente;
            cmbTipCliente.Text = pCliente.Nombre_CatCliente;
            if (pCliente.Genero_Persona == "M") cbxGenero.SelectedIndex = 0; else cbxGenero.SelectedIndex = 1;
            DataClasses1DataContext dc = new DataClasses1DataContext();
            ucNacionalidad.setNacionalidad(dc.SIGEEA_Nacionalidads.First(c => c.PK_Id_Nacionalidad == pCliente.FK_Id_Nacionalidad).Nombre_Nacionalidad);
            ObtenerCategorias(pCliente.PK_Id_CatCliente);
        }
        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tipoPersona == "Asociado")
                {
                    RegistrarPersona();
                    if (editar == false)
                    {
                        AsociadoMantenimiento Asociado = new AsociadoMantenimiento();
                        SIGEEA_Asociado nuevoAsociado = new SIGEEA_Asociado();
                        nuevoAsociado.Estado_Asociado = true;
                        nuevoAsociado.FK_Id_Representante = null;
                        nuevoAsociado.FecIngreso_Asociado = DateTime.Today;
                        nuevoAsociado.FK_Id_Empresa = 1;
                        Asociado.RegistrarAsociado(nuevaPersona, nuevoAsociado);
                    }
                    else
                    {
                        nuevaPersona.PK_Id_Persona = pk_Persona;
                        PersonaMantenimiento Persona = new PersonaMantenimiento();
                        Persona.ModificarPersona(nuevaPersona);
                    }

                    MessageBox.Show("Su solicitud se ha concluido de manera correcta.");
                    this.Close();
                }

                else if (tipoPersona == "Empleado")
                {
                    grdPersona.Visibility = Visibility.Collapsed;
                    grdEmpleado.Visibility = Visibility.Visible;
                    grdCliente.Visibility = Visibility.Collapsed;
                }
                else if (tipoPersona == "Cliente")
                {
                    grdPersona.Visibility = Visibility.Collapsed;
                    grdEmpleado.Visibility = Visibility.Collapsed;
                    grdCliente.Visibility = Visibility.Visible;
                    listarCategorias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe ingresar la información de manera correcta.");
            }
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegistrarPersona();
                nuevaPersona.PK_Id_Persona = pk_Persona;
                SIGEEA_Escolaridad nuevaEscolaridad = new SIGEEA_Escolaridad();
                nuevaEscolaridad.Leer_Escolaridad = chkLeer.IsChecked.GetValueOrDefault();
                nuevaEscolaridad.Escribir_Escolaridad = chkEscribir.IsChecked.GetValueOrDefault();
                nuevaEscolaridad.GradoAcad_Escolaridad = cmbGradoAcad.SelectedIndex + 1;
                nuevaEscolaridad.Observaciones_Escolaridad = txbAdicional.Text;
                EmpleadoMantenimiento empleadoMant = new EmpleadoMantenimiento();

                if (editar == false)
                {
                    SIGEEA_Empleado nuevoEmpleado = new SIGEEA_Empleado();
                    empleadoMant.RegistrarEmpleado(nuevaPersona, nuevoEmpleado, nuevaEscolaridad);
                }
                else
                {
                    empleadoMant.EditarEmpleado(nuevaPersona, nuevaEscolaridad);
                }

                MessageBox.Show("La solicitud realizada se finalizó con éxito.");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error al realizar la solicitud.");
            }
        }

        private void btnRegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegistrarPersona();
                nuevaPersona.PK_Id_Persona = pk_Persona;

                ClienteMantenimiento clienteMant = new ClienteMantenimiento();

                if (editar == false)
                {
                    SIGEEA_Cliente nuevoCliente = new SIGEEA_Cliente();
                    clienteMant.RegistrarCliente(nuevaPersona, nuevoCliente, Convert.ToInt32(lbPkCatCliente.Content));
                }
                else
                {
                    SIGEEA_Cliente nuevoCliente = new SIGEEA_Cliente();
                    clienteMant.ModificarCliente(nuevoCliente, Convert.ToInt32(lbPkCatCliente.Content), nuevaPersona);
                }

                MessageBox.Show("La solicitud realizada se finalizó con éxito.");
            }
            catch
            {
                MessageBox.Show("Error al realizar la solicitud.");
            }
        }
        public void listarCategorias()
        {
            ClienteMantenimiento mantCliente = new ClienteMantenimiento();
            cmbTipCliente.ItemsSource = mantCliente.ListarCategorias();

        }
        public void ObtenerCategorias(int pkCat)
        {
            ClienteMantenimiento mantCliente = new ClienteMantenimiento();
            SIGEEA_spObtenerCategoriaResult cat = mantCliente.ObtenerCategorias(pkCat);
            lbPkCatCliente.Content = cat.PK_Id_CatCliente.ToString();
            txbCreMaximo.Text = cat.Limite_CatCliente.ToString();
            txbRango.Text = cat.RanPagos_CatCliente;
            txbTiempoMaximo.Text = cat.TieMaximo_CatCliente;
        }

        private void cmbTipCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ObtenerCategorias(mantCliente.ObtenerPkCategoria(Convert.ToString(this.cmbTipCliente.SelectedItem)));
        }
    }
}
