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

namespace SIGEEA_App.Ventanas_Modales.Empleados
{
    /// <summary>
    /// Interaction logic for wnwRegistrarHorasLaboradas.xaml
    /// </summary>
    public partial class wnwRegistrarHorasLaboradas : MetroWindow
    {
        public wnwRegistrarHorasLaboradas()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, RoutedEventArgs e)
        {
            
            EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();
            if (empleado.AutenticaEmpleado(txbCedula.Text) != null)
            {
                try
                {

                   
                    if (empleado.DiaIncompleto(txbCedula.Text) == false)//Tiene sus días laborales completos
                    {
                        SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
                        MessageBox.Show("A continuación debe elegir la labor que desempeñará el empleado el dia de hoy.", "SIGEEA", MessageBoxButton.OK);
                        cnvPrincipal.Visibility = Visibility.Collapsed;
                        cnvSecundaria.Visibility = Visibility.Visible;
                        btnValidar.IsDefault = false;
                        btnRegistrar.IsDefault = true;

                        List<SIGEEA_spListarPuestosResult> lista = dc.SIGEEA_spListarPuestos().ToList();

                        foreach (SIGEEA_spListarPuestosResult p in lista)
                        {
                            cmbPuestos.Items.Add(p.Nombre_Puesto);
                        }
                    }

                    else //Tiene un día laboral sin hora de salida
                    {
                        empleado.RegistrarHoras(txbCedula.Text, null);
                        MessageBox.Show("Día laboral concluido", "SIGEEA", MessageBoxButton.OK);
                        this.Close();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error en el sistema: " + Ex.Message, "SIGEEA", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Error. El número de cédula digitado no coincide con los registros.", "SIGEEA", MessageBoxButton.OK);
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmpleadoMantenimiento empleado = new EmpleadoMantenimiento();
                empleado.RegistrarHoras(txbCedula.Text, cmbPuestos.SelectedItem.ToString());
                MessageBox.Show("Día laboral iniciado", "SIGEEA", MessageBoxButton.OK);
                this.Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error en el sistema: " + Ex.Message, "SIGEEA", MessageBoxButton.OK);
            }
        }
    }
}
