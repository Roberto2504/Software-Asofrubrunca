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
using SIGEEA_BL.Seguridad;
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
        public wnwRegistrarFinca(string ptipo, int pPkAsociado, SIGEEA_Finca pFinca)
        {
            InitializeComponent();
            tipo = ptipo;
            txtTipo.Text = tipo;
            ListarTipoFinca();
            pkAsociado = pPkAsociado;
            asociado = manFinca.ObtenerAsociado(pPkAsociado);
            ObtenerDatos(asociado.FK_Id_Persona);
            GenerarCodigoFinca();
            if (ptipo == "Editar")
            {
                finca = pFinca;
                CargarDatos(pFinca);
                
            }else
            {
                Conta = 0;
            }
        }
        string tipo;
        string nombreCompleto, Apellidos;
        List<string> listaTipoFinca = new List<string>();
        string tamaño;
        string tipoFinca;
        string codigoFinca;
        int pkAsociado;
        int Conta;
        FincaMantenimiento manFinca = new FincaMantenimiento();
        SIGEEA_Asociado asociado = new SIGEEA_Asociado();
        SIGEEA_Finca finca = new SIGEEA_Finca();
        public void CargarDatos(SIGEEA_Finca finca)
        {
            if (finca.Alquilada_Finca == false)
            {
                cmbTiposDeFinca.SelectedIndex = 1;
                grdDatosDueño.IsEnabled = false;

                txtPriNombre.Text = finca.PriNomDuenno_Finca;
                txtSegNombre.Text = finca.SegNomDuenno_Finca;
                txtPriApellido.Text = finca.PriApeDuenno_Finca;
                txtSegApellido.Text = finca.SegApeDuenno_Finca;

            }
            else
            {
                cmbTiposDeFinca.SelectedIndex = 0;
                grdDatosDueño.IsEnabled = true;
                txtPriNombre.Text = finca.PriNomDuenno_Finca;
                txtSegNombre.Text = finca.SegNomDuenno_Finca;
                txtPriApellido.Text = finca.PriApeDuenno_Finca;
                txtSegApellido.Text = finca.SegApeDuenno_Finca;
            }
            txtNumeroRegistro.Text = finca.NumRegistro_Finca;
            txtTamFinca.Text = finca.Tamanno_Finca.ToString();
            lbCodGenerado.Content = finca.Codigo_Finca;
            List<SIGEEA_Lote> listaLotes = manFinca.ListarLote(finca.PK_Id_Finca);
            foreach(SIGEEA_Lote lote in listaLotes)
            {
                agregarLote(lote.Tamanno_Lote, lote);
            }
            
        }
        public void GenerarCodigoFinca()
        {
            SIGEEA_Persona datos = manFinca.ObtenerInfoAsociado(asociado.FK_Id_Persona);
            if(tipo == "Registrar") {
                codigoFinca = ("F" + (manFinca.ObtenerIdUltimaFinca() + 1) + datos.PriNombre_Persona[0].ToString().ToUpper() + datos.PriApellido_Persona[0].ToString().ToUpper() + datos.SegApellido_Persona[0].ToString().ToUpper());
                lbCodGenerado.Content = codigoFinca;
            }
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
            if (tipo == "Registrar")
            {
                int idFinca;
            if (tipoFinca == "Alquilada")
            {
                nueva.Alquilada_Finca = true;
            }
            else
            {
                nueva.Alquilada_Finca = false;
            }
            nueva.PriNomDuenno_Finca = txtPriNombre.Text;
            nueva.SegNomDuenno_Finca = txtSegNombre.Text;
            nueva.PriApeDuenno_Finca = txtPriApellido.Text;
            nueva.SegApeDuenno_Finca = txtSegApellido.Text;
            nueva.NumRegistro_Finca = txtNumeroRegistro.Text;
            nueva.Tamanno_Finca = Convert.ToDouble(txtTamFinca.Text);
            nueva.FK_Id_Empleado = UsuarioGlobal.InfoUsuario.PK_Id_Empleado; 
            nueva.Estado_Finca = "1";
            nueva.PK_Id_Finca = manFinca.ObtenerIdUltimaFinca()+1;
            nueva.FK_Id_Direccion = 0;
                nueva.Codigo_Finca = lbCodGenerado.Content.ToString();
            idFinca = manFinca.RegistrarFinca(nueva, asociado);
            foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
            {
                SIGEEA_Lote nuevolote = new SIGEEA_Lote();
                nuevolote.Tamanno_Lote = lote.txbTamaño.Text;
                nuevolote.Codigo_Lote = lote.txbCodigo.Text;
                nuevolote.FK_Id_Finca = idFinca;
                    nuevolote.Estado_Lote = true;
                manFinca.RegistrarLote(nuevolote);
            }
            wnwDirecciones nuevaDireccion = new wnwDirecciones(pCedula_pCodigo: null, tipoPersona: "Finca", pkFinca: idFinca);
            nuevaDireccion.ShowDialog();
                this.Close();
            }


            else
            {
                if (tipoFinca == "Alquilada")
                {
                    nueva.Alquilada_Finca = true;
                }
                else
                {
                    nueva.Alquilada_Finca = false;
                }
                nueva.PriNomDuenno_Finca = txtPriNombre.Text;
                nueva.SegNomDuenno_Finca = txtSegNombre.Text;
                nueva.PriApeDuenno_Finca = txtPriApellido.Text;
                nueva.SegApeDuenno_Finca = txtSegApellido.Text;
                nueva.NumRegistro_Finca = txtNumeroRegistro.Text;
                nueva.Tamanno_Finca = Convert.ToDouble(txtTamFinca.Text);
                nueva.FK_Id_Empleado = UsuarioGlobal.InfoUsuario.PK_Id_Empleado;
                nueva.Estado_Finca = "1";
                nueva.PK_Id_Finca = manFinca.ObtenerIdUltimaFinca() + 1;
                nueva.FK_Id_Direccion = 0;
                nueva.Codigo_Finca = lbCodGenerado.Content.ToString();
                nueva.PK_Id_Finca = finca.PK_Id_Finca;
                foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
                {
                    if (manFinca.ExisteLote(Convert.ToInt32(lote.btnOpcion.Tag)) == true){
                        SIGEEA_Lote editolote = new SIGEEA_Lote();
                        editolote.Tamanno_Lote = lote.txbTamaño.Text;
                        editolote.Codigo_Lote = lote.txbCodigo.Text;
                        editolote.FK_Id_Finca = finca.PK_Id_Finca;
                        editolote.PK_Id_Lote = Convert.ToInt32(lote.btnOpcion.Tag);
                        if (lote.txbEstado.Text == "true")
                        {
                            editolote.Estado_Lote = true;
                        }
                        else editolote.Estado_Lote = false;
                        manFinca.EditarLote(editolote);
                    }
                    else { 
                    SIGEEA_Lote nuevolote = new SIGEEA_Lote();
                    nuevolote.Tamanno_Lote = lote.txbTamaño.Text;
                    nuevolote.Codigo_Lote = lote.txbCodigo.Text;
                    nuevolote.FK_Id_Finca = finca.PK_Id_Finca;
                    manFinca.RegistrarLote(nuevolote);
                    }
                }
                MessageBox.Show("Finca editada con exito");
                this.Close();
            }
               
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            wnwRegistrarLote nuevo = new wnwRegistrarLote(ptipo: "Registrar", pTamaño: null, pNumLote: Conta);
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
        bool editar;
        public void agregarLote(string tamaño, SIGEEA_Lote Lote)
        {
            
                uc_Lote nuevo = new uc_Lote();
                nuevo.txbTamaño.Text = tamaño;
            Conta++;
            if (tipo == "Registrar")
            {
               
                nuevo.txbCodigo.Text = "F" + (manFinca.ObtenerIdUltimaFinca() + 1) + "L" + Conta;
                nuevo.btnOpcion.Tag = Conta;
                nuevo.btnOpcion2.Tag = Conta;
                nuevo.txbEstado.Text = "true";
                nuevo.btnOpcion2.Content = "Borrar";
                nuevo.grdLote.Background = new LinearGradientBrush(Colors.Azure, Colors.MediumAquamarine, 90);

            }
            else
            {
                if (Lote == null)
                {
                    nuevo.txbCodigo.Text = "F" + finca.PK_Id_Finca + "L" + Conta;
                    editar = false;
                    nuevo.txbEstado.Text = "true";
                    nuevo.btnOpcion2.Content = "Borrar";
                    nuevo.grdLote.Background = new LinearGradientBrush(Colors.Azure, Colors.MediumAquamarine, 90);
                    nuevo.btnOpcion.Tag = Conta;
                    nuevo.btnOpcion2.Tag = Conta;
                }
                else
                {
                    editar = true;
                    nuevo.txbCodigo.Text = Lote.Codigo_Lote;
                    nuevo.btnOpcion.Tag = Lote.PK_Id_Lote;
                    nuevo.btnOpcion2.Tag = Lote.PK_Id_Lote;
                    if (Lote.Estado_Lote == false)
                    {
                        nuevo.txbEstado.Text = "false";
                        nuevo.btnOpcion2.Content = "Activar";
                        nuevo.grdLote.Background = new LinearGradientBrush(Colors.Azure, Colors.Firebrick, 90);
                    }
                    else
                    {
                        nuevo.txbEstado.Text = "true";
                        nuevo.btnOpcion2.Content = "Borrar";
                        nuevo.grdLote.Background = new LinearGradientBrush(Colors.Azure, Colors.MediumAquamarine, 90); }
              }
               
                
                
            }
                nuevo.btnOpcion.Click += BtnOpcion_Click;
                nuevo.btnOpcion2.Click += BtnOpcion2_Click;
               
                stpLotes.Children.Add(nuevo);
            
            
        }

        private void BtnOpcion2_Click(object sender, RoutedEventArgs e)
        {
            var boton = (Button)sender;
            foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
            {
                if (tipo == "Registrar") {
                    string[] numLote = lote.txbCodigo.Text.ToString().Split('L');
                    if (boton.Tag.ToString() == numLote[1])
                    {
                        MessageBoxResult m = MessageBox.Show("Esta seguro que desea eliminar este lote", "Mensaje de Confirmación", MessageBoxButton.YesNo);
                        if (m == MessageBoxResult.Yes)
                        {
                            stpLotes.Children.Remove(lote);
                            RestablecerCuentaLote();
                        }
                    }
                }
                else
                {
                    string[] numLote = lote.txbCodigo.Text.ToString().Split('L');
                    if (editar == false && boton.Tag.ToString() == numLote[1])
                    {
                        MessageBoxResult m = MessageBox.Show("Esta seguro que desea eliminar este lote", "Mensaje de Confirmación", MessageBoxButton.YesNo);
                        if (m == MessageBoxResult.Yes)
                        {
                            
                           
                            foreach (uc_Lote lote1 in FindVisualChildren<uc_Lote>(stpLotes))
                            {
                                string[] numLote1 = lote1.txbCodigo.Text.ToString().Split('L');
                                if (Convert.ToInt32(numLote1[1]) > Convert.ToInt32(numLote[1]))
                                {
                                    lote1.txbCodigo.Text = "F" + finca.PK_Id_Finca + "L" + (Convert.ToInt32(numLote1[1]) - 1);
                                }
                                lote.btnOpcion.Tag = (Convert.ToInt32(numLote1[1]) - 1);
                                lote.btnOpcion2.Tag = (Convert.ToInt32(numLote1[1]) - 1);
                            }
                            stpLotes.Children.Remove(lote);
                            Conta--;
                        }
                    }
                    else
                    {
                        if (manFinca.ExisteLote(Convert.ToInt32(boton.Tag)) == true)
                        {
                            if (manFinca.ObtenerLote(Convert.ToInt32(boton.Tag)).Codigo_Lote == lote.txbCodigo.Text)
                            {
                                if (lote.txbEstado.Text == "false")
                                {
                                    MessageBoxResult m = MessageBox.Show("Esta seguro que desea activar este lote", "Mensaje de Confirmación", MessageBoxButton.YesNo);
                                    if (m == MessageBoxResult.Yes)
                                    {
                                        lote.btnOpcion2.Content = "Borrar";
                                        lote.txbEstado.Text = "true";
                                        lote.Background = new LinearGradientBrush(Colors.Azure, Colors.MediumAquamarine, 90);


                                        lote.grdLote.Background = new LinearGradientBrush(Colors.Azure, Colors.MediumAquamarine, 90);
                                    }
                                }
                                else
                                {
                                    MessageBoxResult m = MessageBox.Show("Esta seguro que desea eliminar este lote", "Mensaje de Confirmación", MessageBoxButton.YesNo);
                                    if (m == MessageBoxResult.Yes)
                                    {
                                        lote.btnOpcion2.Content = "Activar";
                                        lote.txbEstado.Text = "false";
                                        lote.grdLote.Background = new LinearGradientBrush(Colors.Azure, Colors.Firebrick, 90);


                                    }
                                }

                            }
                        }
                    }
                      
                }
            }
        }
        public void RestablecerCuentaLote()
        {
            Conta = 0;
            foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
            {
                Conta++;
                lote.txbCodigo.Text = "F" + (manFinca.ObtenerIdUltimaFinca() + 1) + "L" + Conta;
                lote.btnOpcion.Tag = Conta;
                lote.btnOpcion2.Tag = Conta;
                
            }
        }
        public void EditarLote(int pnumLote, string tamaño)
        {
            if (tipo == "Editar")
            {
                foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
                {
                    
                    if (Convert.ToInt32(lote.btnOpcion.Tag) == pnumLote)
                    {
                        lote.txbTamaño.Text = tamaño;
                    }
                }
            }
            else
            {
                foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
                {
                    string[] numLote = lote.txbCodigo.Text.ToString().Split('L');
                    if (numLote[1] == pnumLote.ToString())
                    {
                        lote.txbTamaño.Text = tamaño;
                    }
                }
            }
            
        }

        private void BtnOpcion_Click(object sender, RoutedEventArgs e)
        {
            Button btnLote = (Button)sender;

            foreach (uc_Lote lote in FindVisualChildren<uc_Lote>(stpLotes))
            {
                string[] numLote = lote.txbCodigo.Text.ToString().Split('L');
                if (btnLote.Tag.ToString() == numLote[1])
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
                SIGEEA_Persona infoAsociado = new SIGEEA_Persona();
                infoAsociado = manFinca.ObtenerInfoAsociado(asociado.FK_Id_Persona);
                txtPriNombre.Text = infoAsociado.PriNombre_Persona;
                txtSegNombre.Text = infoAsociado.SegNombre_Persona;
                txtPriApellido.Text = infoAsociado.PriApellido_Persona;
                txtSegApellido.Text = infoAsociado.SegApellido_Persona;  
            }
            else
            {
                grdDatosDueño.IsEnabled = true;
                txtPriNombre.Text = "";
                txtSegNombre.Text = "";
                txtPriApellido.Text = "";
                txtSegApellido.Text = "";
            }
        }
    }
}
