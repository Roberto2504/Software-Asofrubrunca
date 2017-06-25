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

namespace SIGEEA_App.Ventanas_Modales.Direcciones
{
    /// <summary>
    /// Interaction logic for wnwDirecciones.xaml
    /// </summary>
    public partial class wnwDirecciones : MetroWindow
    {
        int pk_persona, pk_finca;
        bool editar;
        string tipo;
        public wnwDirecciones(string pCedula_pCodigo, string tipoPersona, int pkFinca)
        {
            InitializeComponent();
            PersonaMantenimiento persona = new PersonaMantenimiento();
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            AsociadoMantenimiento asociado = new AsociadoMantenimiento();
            cmbProvincia.ItemsSource = persona.ListarProvinciasNacionales();//Se carga el ComboBox de provincias
            pk_finca = pkFinca;
            tipo = tipoPersona;
            if (tipoPersona == "Asociado")
            {
                if (asociado.DireccionRegistradaAsociado(pCedula: pCedula_pCodigo, pCodigo: null) == true)//Si el asociado tiene ya una dirección registrada
                {
                    CargaInformacion(tipoPersona, pCedula: pCedula_pCodigo, pCodigo: null, pIdFinca:null);
                    editar = true;
                }
                else
                {
                    MessageBox.Show("Este asociado no cuenta con ninguna dirección registrada. Puede registrarla a continuación.", "SIGEEA", MessageBoxButton.OK);
                    editar = false;
                    if (pCedula_pCodigo.Length < 9)
                    {
                         
                        pk_persona = dc.SIGEEA_Asociados.FirstOrDefault(p => p.Codigo_Asociado == pCedula_pCodigo).FK_Id_Persona;
                    }else
                    {
                        pk_persona = dc.SIGEEA_Personas.First(p => p.CedParticular_Persona == pCedula_pCodigo).PK_Id_Persona;
                    }
                    
                }
            }
            else if (tipoPersona == "Empleado")
            {
                EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();
                if (empleado.DireccionRegistradaEmpleado(pCedula_pCodigo) == true)// Si el empleado ya tiene una dirección registrada
                {
                    CargaInformacion(tipoPersona, pCedula: pCedula_pCodigo, pCodigo: null, pIdFinca:null);
                    editar = true;
                }
                else
                {
                    MessageBox.Show("Este empleado no cuenta con ninguna dirección registrada. Puede registrarla a continuación.", "SIGEEA", MessageBoxButton.OK);
                    editar = false;
                    pk_persona = dc.SIGEEA_Personas.First(p => p.CedParticular_Persona == pCedula_pCodigo).PK_Id_Persona;
                }
            }
            else if (tipoPersona == "Finca")
            {
                FincaMantenimiento finca = new FincaMantenimiento();
                if (finca.DireccionRegistradaFinca(pk_finca.ToString()) == true)// Si el empleado ya tiene una dirección registrada
                {
                    CargaInformacion(tipoPersona, pCedula: pCedula_pCodigo, pCodigo: null, pIdFinca: null);
                    editar = true;
                }
                else
                {
                    MessageBox.Show("Esta Finca no cuenta con ninguna dirección registrada. Puede registrarla a continuación.", "SIGEEA", MessageBoxButton.OK);
                    editar = false;

                }
            }
        }

        private void cmbProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbCanton.Items.Clear();//Los ítems del ComboBox de cantones se limpian
            ComboBox combo = (ComboBox)sender;//Se hace un cast al ComboBox del sender 
            CargaCantones(combo.SelectedValue.ToString());//Se carga la lista de cantones con una provincia en común                     
        }

        /// <summary>
        /// Carga los ComboBox de los cantones
        /// </summary>
        /// <param name="pProvincia"></param>
        public void CargaCantones(string pProvincia)
        {
            PersonaMantenimiento persona = new PersonaMantenimiento();
            List<SIGEEA_spObtenerCantonesResult> lista = persona.ListarCantones(pProvincia);

            foreach (SIGEEA_spObtenerCantonesResult d in lista)
            {
                cmbCanton.Items.Add(d.Nombre_Canton);//Se agregan los ítems al ComboBox de cantones
            }
        }

        /// <summary>
        /// Carga la dirección del asociado a la interfaz gráfica
        /// </summary>
        /// <param name="pCedula"></param>
        /// <param name="pCodigo"></param>
        public void CargaInformacion(string tipoPersona, string pCedula, string pCodigo, string pIdFinca)
        {
            if (tipoPersona == "Asociado")
            {
                AsociadoMantenimiento asociado = new AsociadoMantenimiento();

                if (pCedula != null && pCodigo == null)
                {
                    SIGEEA_spObtenerDireccionAsociadoResult direccion = asociado.ObtenerDireccionAsociado(pCedula: pCedula, pCodigo: null);
                    CargaCantones(direccion.Nombre_Provincia);
                    CargaDistritos(direccion.Nombre_Canton);
                    pk_persona = direccion.PK_Id_Persona;

                    cmbProvincia.SelectedItem = direccion.Nombre_Provincia;
                    cmbCanton.SelectedItem = direccion.Nombre_Canton;
                    cmbDistrito.SelectedItem = direccion.Nombre_Distrito;
                    txbDetalles.Text = direccion.Detalles_Direccion;
                }
                else
                {
                    SIGEEA_spObtenerDireccionAsociadoResult direccion = asociado.ObtenerDireccionAsociado(pCedula: null, pCodigo: pCodigo);
                    CargaCantones(direccion.Nombre_Provincia);
                    CargaDistritos(direccion.Nombre_Canton);
                    pk_persona = direccion.PK_Id_Persona;

                    cmbProvincia.SelectedItem = direccion.Nombre_Provincia;
                    cmbCanton.SelectedItem = direccion.Nombre_Canton;
                    cmbDistrito.SelectedItem = direccion.Nombre_Distrito;
                    txbDetalles.Text = direccion.Detalles_Direccion;
                }
            }
            else if (tipoPersona == "Empleado")
            {
                EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();

                if (pCedula != null && pCodigo == null)
                {
                    SIGEEA_spObtenerDireccionEmpleadoResult direccion = empleado.ObtenerDireccionEmpleado(pCedula);
                    CargaCantones(direccion.Nombre_Provincia);
                    CargaDistritos(direccion.Nombre_Canton);
                    pk_persona = direccion.PK_Id_Persona;

                    cmbProvincia.SelectedItem = direccion.Nombre_Provincia;
                    cmbCanton.SelectedItem = direccion.Nombre_Canton;
                    cmbDistrito.SelectedItem = direccion.Nombre_Distrito;
                    txbDetalles.Text = direccion.Detalles_Direccion;
                }
            }
            else if (tipoPersona == "Finca")
            {
                FincaMantenimiento Finca = new FincaMantenimiento();

                if (pIdFinca == null)
                {
                    SIGEEA_spObtenerDireccionFincaResult direccion = Finca.ObtenerDireccionFinca(Convert.ToInt32(pIdFinca));
                    CargaCantones(direccion.Nombre_Provincia);
                    CargaDistritos(direccion.Nombre_Canton);
                    cmbProvincia.SelectedItem = direccion.Nombre_Provincia;
                    cmbCanton.SelectedItem = direccion.Nombre_Canton;
                    cmbDistrito.SelectedItem = direccion.Nombre_Distrito;
                    txbDetalles.Text = direccion.Detalles_Direccion;
                }
            }
        }

        private void cmbCanton_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbDistrito.Items.Clear();
            ComboBox combo = (ComboBox)sender;
            CargaDistritos(combo.SelectedValue.ToString());
        }

        /// <summary>
        /// Carga los ComboBox de los distritos
        /// </summary>
        /// <param name="pCanton"></param>

        public void CargaDistritos(string pCanton)
        {
            PersonaMantenimiento persona = new PersonaMantenimiento();
            List<SIGEEA_spObtenerDistritosResult> lista = persona.ListarDistritos(pCanton);

            foreach (SIGEEA_spObtenerDistritosResult d in lista)
            {
                cmbDistrito.Items.Add(d.Nombre_Distrito);//Se agregan los ítems al ComboBox de distritos
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            PersonaMantenimiento direccion = new PersonaMantenimiento();
            FincaMantenimiento direccionFinca = new FincaMantenimiento();
            if (editar == true)
            {
                try
                {

                    if (tipo == "Finca")
                    {
                        direccionFinca.EditarDireccion(pk_finca, txbDetalles.Text, (string)cmbDistrito.SelectedItem);
                        MessageBox.Show("Información de finca actualizada con éxito", "SIGEEA", MessageBoxButton.OK);
                    }
                    else
                    {
                        direccion.EditarDireccion(pk_persona, txbDetalles.Text, (string)cmbDistrito.SelectedItem);
                        MessageBox.Show("Dirección actualizada con éxito", "SIGEEA", MessageBoxButton.OK);
                    }
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("La operación solicitada falló.", "SIGEEA", MessageBoxButton.OK);
                }
            }
            else
            {
                try
                {
                    if (tipo == "Finca")
                    {
                        direccionFinca.AgregarDireccion(pk_finca, txbDetalles.Text, (string)cmbDistrito.SelectedItem);
                        MessageBox.Show("Finca registrada con éxito", "SIGEEA", MessageBoxButton.OK);
                    }
                    else
                    {
                        direccion.AgregarDireccion(pk_persona, txbDetalles.Text, (string)cmbDistrito.SelectedItem);
                        MessageBox.Show("Dirección registrada con éxito", "SIGEEA", MessageBoxButton.OK);
                    }
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("La operación solicitada falló.", "SIGEEA", MessageBoxButton.OK);
                }
            }
        }
    }
}
