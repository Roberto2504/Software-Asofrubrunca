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
        bool cedValida;
        int pk_Persona;
        string cedula;
        PersonaMantenimiento mantPersona = new PersonaMantenimiento();
        ClienteMantenimiento mantCliente = new ClienteMantenimiento();
        SIGEEA_spObtenerClienteResult Cliente = new SIGEEA_spObtenerClienteResult();
        public wnwRegistrarPersona(string pTipoPersona, SIGEEA_spObtenerAsociadoResult pAsociado, SIGEEA_spObtenerEmpleadoResult pEmpleado, SIGEEA_spObtenerClienteResult pCliente)
        {
            InitializeComponent();
            tipoPersona = pTipoPersona;
            btnSiguiente.Click += BtnSiguiente_Click;
            btnRegistrar.Click += BtnRegistrar_Click;
            PersonaMantenimiento persona = new PersonaMantenimiento();
            if (tipoPersona == "Cliente")
            {
                cbxEmpresa.Visibility = Visibility.Visible;
            }

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
                Cliente = pCliente;
                if (pCliente.CedJuridica_Persona != null)
                {
                    cedula = pCliente.CedJuridica_Persona;
                }
                else
                {
                    cedula = pCliente.CedParticular_Persona;
                }
            }
        }

        public void RegistrarPersona()
        {
            try
            {
                ValidacionesMantenimiento validacion = new ValidacionesMantenimiento();
                bool valido = true;
                //foreach (TextBox txb in grdValidar.Children)
                //{
                //    BrushConverter bc = new BrushConverter();
                //    txb.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                //    if (validacion.Validar(txb.Text, Convert.ToInt32(txb.Tag)) == false)
                //    {
                //        valido = false;
                //        txb.Foreground = (Brush)bc.ConvertFrom("#FFFF0404");
                //    }
                //}
                if (valido == true)
                {
                    nuevaPersona = new SIGEEA_Persona();
                    if (tipoPersona == "Cliente")
                    {
                        if (cbxEmpresa.IsChecked == false)
                        {
                            nuevaPersona.CedParticular_Persona = txbCedula.Text;
                            if (dtpFecNacimiento.SelectedDate != null)
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
                        else
                        {
                            nuevaPersona.CedParticular_Persona = null;
                            nuevaPersona.CedJuridica_Persona = txbCedula.Text;
                            if (dtpFecNacimiento.SelectedDate != null)
                                nuevaPersona.FecNacimiento_Persona = dtpFecNacimiento.SelectedDate.Value;
                            nuevaPersona.FK_Id_Direccion = null;
                            nuevaPersona.Tipo_Persona = false;
                            nuevaPersona.FK_Id_Nacionalidad = ucNacionalidad.getNacionalidad();

                            nuevaPersona.Genero_Persona = null;
                            nuevaPersona.PriApellido_Persona = null;
                            nuevaPersona.PriNombre_Persona = txbPriNombre.Text;
                            nuevaPersona.SegApellido_Persona = null;
                            nuevaPersona.SegNombre_Persona = null;
                        }
                        cbxEmpresa.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        nuevaPersona.CedParticular_Persona = txbCedula.Text;
                        if (dtpFecNacimiento.SelectedDate != null)
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
            if (pAsociado.FecNacimiento_Persona != null)
                dtpFecNacimiento.Text = pAsociado.FecNacimiento_Persona.ToString();
            if (pAsociado.Genero_Persona == "M") cbxGenero.SelectedIndex = 0; else cbxGenero.SelectedIndex = 1;
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            ucNacionalidad.setNacionalidad(dc.SIGEEA_Nacionalidads.First(c => c.PK_Id_Nacionalidad == pAsociado.FK_Id_Nacionalidad).Nombre_Nacionalidad);
            // ucEstrellas.cargaEstrellas((float)dc.SIGEEA_spObtenerCategoriaAsociado(pAsociado.PK_Id_Asociado).First().Categoria);
            //  ucEstrellas.Visibility = Visibility.Visible;
        }

        public void CargarInformacionEmpleado(SIGEEA_spObtenerEmpleadoResult pEmpleado)
        {
            txbCedula.Text = pEmpleado.CedParticular_Persona;
            txbPriNombre.Text = pEmpleado.PriNombre_Persona;
            txbSegNombre.Text = pEmpleado.SegNombre_Persona;
            txbPriApellido.Text = pEmpleado.PriApellido_Persona;
            txbSegApellido.Text = pEmpleado.SegApellido_Persona;
            if (pEmpleado.FecNacimiento_Persona != null)
                dtpFecNacimiento.Text = pEmpleado.FecNacimiento_Persona.ToString();
            if (pEmpleado.Genero_Persona == "M") cbxGenero.SelectedIndex = 0; else cbxGenero.SelectedIndex = 1;
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            ucNacionalidad.setNacionalidad(pEmpleado.Nombre_Nacionalidad);
            txbAdicional.Text = pEmpleado.Observaciones_Escolaridad;
            chkEscribir.IsChecked = pEmpleado.Escribir_Escolaridad;
            chkLeer.IsChecked = pEmpleado.Leer_Escolaridad;
            cmbGradoAcad.SelectedIndex = pEmpleado.GradoAcad_Escolaridad - 1;
        }
        public void CargarInformacionCliente(SIGEEA_spObtenerClienteResult pCliente)
        {
            if (pCliente.CedJuridica_Persona != null)
            {
                txbCedula.Text = pCliente.CedJuridica_Persona;
                cbxEmpresa.IsChecked = true;
                lblCedula.Content = "Cédula jurídica";
                lblPriNombre.Content = "Nombre";
                lblGenero.Visibility = Visibility.Hidden;
                lblSegNombre.Visibility = Visibility.Hidden;
                lblPriApellido.Visibility = Visibility.Hidden;
                lblSegApellido.Visibility = Visibility.Hidden;
                txbSegApellido.Visibility = Visibility.Hidden;
                txbPriApellido.Visibility = Visibility.Hidden;
                txbSegNombre.Visibility = Visibility.Hidden;
                cbxGenero.Visibility = Visibility.Hidden;
            }
            else
            {
                txbCedula.Text = pCliente.CedParticular_Persona;
                cbxEmpresa.IsChecked = false;
                lblCedula.Content = "Cédula";
                lblPriNombre.Content = "Primer nombre";
                lblGenero.Visibility = Visibility.Visible;
                lblSegNombre.Visibility = Visibility.Visible;
                lblPriApellido.Visibility = Visibility.Visible;
                lblSegApellido.Visibility = Visibility.Visible;
                txbSegApellido.Visibility = Visibility.Visible;
                txbPriApellido.Visibility = Visibility.Visible;
                txbSegNombre.Visibility = Visibility.Visible;
                cbxGenero.Visibility = Visibility.Visible;
            }

            txbPriNombre.Text = pCliente.PriNombre_Persona;
            txbSegNombre.Text = pCliente.SegNombre_Persona;
            txbPriApellido.Text = pCliente.PriApellido_Persona;
            txbSegApellido.Text = pCliente.SegApellido_Persona;
            dtpFecNacimiento.Text = pCliente.FecNacimiento_Persona.ToString();
            listarCategorias();
            lbPkCatCliente.Content = pCliente.PK_Id_TipCatCliente;
            txbCreMaximo.Text = pCliente.Limite_CatCliente.ToString();
            txbRango.Text = pCliente.RanPagos_CatCliente;
            txbTiempoMaximo.Text = pCliente.TieMaximo_CatCliente;
            lbPkCatCliente.Content = pCliente.PK_Id_CatCliente;
            cmbTipCliente.Text = pCliente.Nombre_TipCatCliente;
            if (pCliente.Genero_Persona == "M") cbxGenero.SelectedIndex = 0; else cbxGenero.SelectedIndex = 1;
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            ucNacionalidad.setNacionalidad(pCliente.Nombre_Nacionalidad);

        }
        public bool ValidaCedula()
        {
            if (tipoPersona == "Cliente")
            {
                if (cbxEmpresa.IsChecked == false)
                {
                    if (mantPersona.ValidaCedParticar(txbCedula.Text) == true)
                    {
                        cedValida = true;
                    }
                    else
                    {
                        cedValida = false;
                    }
                }
                else
                {
                    if (mantPersona.ValidaCedJuridica(txbCedula.Text) == true)
                    {
                        cedValida = true;
                    }
                    else
                    {
                        cedValida = false;
                    }
                }
            }
            else
            {
                if (mantPersona.ValidaCedJuridica(txbCedula.Text) == true)
                {
                    cedValida = true;
                }
                else
                {
                    cedValida = false;
                }
            }
            return cedValida;
        }
        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidaCedula();
                if (cedValida == false || (cedValida == true && cedula == txbCedula.Text))
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
                        RegistrarPersona();
                        grdPersona.Visibility = Visibility.Collapsed;
                        grdEmpleado.Visibility = Visibility.Visible;
                        grdCliente.Visibility = Visibility.Collapsed;
                    }
                    else if (tipoPersona == "Cliente")
                    {
                        RegistrarPersona();
                        grdPersona.Visibility = Visibility.Collapsed;
                        grdEmpleado.Visibility = Visibility.Collapsed;
                        grdCliente.Visibility = Visibility.Visible;
                        listarCategorias();
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe una persona registrada con es cédula");
                    txbCedula.Text = "";
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

                ValidaCedula();
                if (cedValida == false)
                {
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
                else
                {
                    MessageBox.Show("Ya existe una persona registrada con es cédula");
                    txbCedula.Text = "";
                }
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
                ValidaCedula();
                if (cedValida == false || (cedValida == true && cedula == txbCedula.Text))
                {
                    RegistrarPersona();
                    ClienteMantenimiento clienteMant = new ClienteMantenimiento();

                    if (editar == false)
                    {
                        SIGEEA_Cliente nuevoCliente = new SIGEEA_Cliente();
                        SIGEEA_CatCliente nuevaCat = new SIGEEA_CatCliente();
                        nuevaCat.FK_Id_TipCatCliente = Convert.ToInt32(lbPkCatCliente.Content);
                        nuevaCat.Limite_CatCliente = Convert.ToDouble(txbCreMaximo.Text);
                        nuevaCat.RanPagos_CatCliente = txbRango.Text;
                        nuevaCat.TieMaximo_CatCliente = txbTiempoMaximo.Text;
                        clienteMant.RegistrarCliente(nuevaPersona, nuevoCliente, clienteMant.RegistrarCategoria(nuevaCat));
                    }
                    else
                    {

                        SIGEEA_CatCliente nuevaCat = new SIGEEA_CatCliente();
                        nuevaCat.FK_Id_TipCatCliente = Convert.ToInt32(lbPkCatCliente.Content);
                        nuevaCat.Limite_CatCliente = Convert.ToDouble(txbCreMaximo.Text);
                        nuevaCat.RanPagos_CatCliente = txbRango.Text;
                        nuevaCat.TieMaximo_CatCliente = txbTiempoMaximo.Text;
                        nuevaCat.PK_Id_CatCliente = Cliente.PK_Id_CatCliente;
                        nuevaPersona.PK_Id_Persona = Cliente.PK_Id_Persona;
                        clienteMant.ModificarCliente(mantCliente.EditarCategoria(nuevaCat), nuevaPersona);
                    }

                    MessageBox.Show("La solicitud realizada se finalizó con éxito.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ya existe una persona registrada con es cédula");
                    txbCedula.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la solicitud." + ex.Message);
            }
        }
        public void listarCategorias()
        {
            ClienteMantenimiento mantCliente = new ClienteMantenimiento();
            cmbTipCliente.ItemsSource = mantCliente.ListarCategorias();

        }


        private void cmbTipCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ClienteMantenimiento mantCliente = new ClienteMantenimiento();
            lbPkCatCliente.Content = mantCliente.ObtenerPkTipCategoria(Convert.ToString(this.cmbTipCliente.SelectedItem));
        }




        private void cbxEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (cbxEmpresa.IsChecked == false)
            {
                cbxEmpresa.IsChecked = false;
                lblCedula.Content = "Cédula";
                lblPriNombre.Content = "Primer nombre";
                lblGenero.Visibility = Visibility.Visible;
                lblSegNombre.Visibility = Visibility.Visible;
                lblPriApellido.Visibility = Visibility.Visible;
                lblSegApellido.Visibility = Visibility.Visible;
                txbSegApellido.Visibility = Visibility.Visible;
                txbPriApellido.Visibility = Visibility.Visible;
                txbSegNombre.Visibility = Visibility.Visible;
                cbxGenero.Visibility = Visibility.Visible;

            }
            else
            {
                cbxEmpresa.IsChecked = true;
                lblCedula.Content = "Cédula jurídica";
                lblPriNombre.Content = "Nombre";
                lblGenero.Visibility = Visibility.Hidden;
                lblSegNombre.Visibility = Visibility.Hidden;
                lblPriApellido.Visibility = Visibility.Hidden;
                lblSegApellido.Visibility = Visibility.Hidden;
                txbSegApellido.Visibility = Visibility.Hidden;
                txbPriApellido.Visibility = Visibility.Hidden;
                txbSegNombre.Visibility = Visibility.Hidden;
                cbxGenero.Visibility = Visibility.Hidden;
            }
        }
    }
}