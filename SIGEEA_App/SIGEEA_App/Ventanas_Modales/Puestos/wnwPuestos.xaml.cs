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

namespace SIGEEA_App.Ventanas_Modales.Puestos
{
    /// <summary>
    /// Interaction logic for wnwPuestos.xaml
    /// </summary>
    public partial class wnwPuestos : MetroWindow
    {
        public wnwPuestos()
        {
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (cmbOpciones.SelectedIndex == 0)//Agregar puesto
            {
                grdPrimera.Visibility = Visibility.Collapsed;
                grdAgregar.Visibility = Visibility.Visible;
            }
            else if (cmbOpciones.SelectedIndex == 1)//Editar puesto
            {
                SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
                List<SIGEEA_spListarPuestosResult> lista = dc.SIGEEA_spListarPuestos().ToList();
                foreach (SIGEEA_spListarPuestosResult p in lista)
                {
                    cmbPuestos.Items.Add(p.Nombre_Puesto);
                }
                grdPrimera.Visibility = Visibility.Collapsed;
                grdEditar.Visibility = Visibility.Visible;
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
                SIGEEA_PueTemporal nuevoPuesto = new SIGEEA_PueTemporal();
                nuevoPuesto.Nombre_Puesto = txbNombre.Text;
                nuevoPuesto.Estado_Puesto = true;
                nuevoPuesto.Tarifa_Puesto = Convert.ToDouble(txbTarifa.Text);
                nuevoPuesto.Actualizacion_Puesto = DateTime.Now;
                dc.SIGEEA_PueTemporals.InsertOnSubmit(nuevoPuesto);
                dc.SubmitChanges();
                MessageBox.Show("Se registró de manera correcta", "SIGEEA", MessageBoxButton.OK);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error al registrar", "SIGEEA", MessageBoxButton.OK);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ComboBoxItem item = (ComboBoxItem)cmbPuestos.SelectedItem;
                EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();
                empleado.EditarPuesto(cmbPuestos.SelectedItem.ToString(), Convert.ToDouble(txbTarifa1.Text));
                MessageBox.Show("Modificación realizada con éxito", "SIGEEA", MessageBoxButton.OK);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error al modificar", "SIGEEA", MessageBoxButton.OK);
            }
        }
    }
}
