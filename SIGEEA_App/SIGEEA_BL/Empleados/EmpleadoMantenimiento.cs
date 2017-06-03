using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL
{
    public class EmpleadoMantenimiento
    {
        /// <summary>
        /// Registrar empleado (se registra primero la persona, la escolaridad y luego el empleado)
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="empleado"></param>
        public void RegistrarEmpleado(SIGEEA_Persona persona, SIGEEA_Empleado empleado, SIGEEA_Escolaridad escolaridad)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            PersonaMantenimiento nuevaPersona = new PersonaMantenimiento();
            nuevaPersona.RegistrarPersona(persona);
            dc.SIGEEA_Escolaridads.InsertOnSubmit(escolaridad);
            dc.SubmitChanges();
            empleado.FK_Id_Persona = persona.PK_Id_Persona;
            empleado.FK_Id_Escolaridad = escolaridad.PK_Id_Escolaridad;
            empleado.Estado_Empleado = true;
            empleado.FK_Id_Empresa = 1;
            dc.SIGEEA_Empleados.InsertOnSubmit(empleado);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Obtiene la información del empleado a partir de su número de cédula
        /// </summary>
        /// <param name="pCedula"></param>
        /// <returns></returns>
        public SIGEEA_spObtenerEmpleadoResult AutenticaEmpleado(string pCedula)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_spObtenerEmpleado(pCedula).FirstOrDefault();
        }

        /// <summary>
        /// Edita la información personal y laboral de un empleado en particular
        /// </summary>
        /// <param name="pPersona"></param>
        /// <param name="pEscolaridad"></param>
        public void EditarEmpleado(SIGEEA_Persona pPersona, SIGEEA_Escolaridad pEscolaridad)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            PersonaMantenimiento mantPersona = new PersonaMantenimiento();
            mantPersona.ModificarPersona(pPersona);

            SIGEEA_Empleado editarEmpleado = new SIGEEA_Empleado();
            editarEmpleado = dc.SIGEEA_Empleados.First(c => c.FK_Id_Persona == pPersona.PK_Id_Persona);

            SIGEEA_Escolaridad editarEscolaridad = new SIGEEA_Escolaridad();
            editarEscolaridad = dc.SIGEEA_Escolaridads.First(c => c.PK_Id_Escolaridad == editarEmpleado.FK_Id_Escolaridad);
            editarEscolaridad.GradoAcad_Escolaridad = pEscolaridad.GradoAcad_Escolaridad;
            editarEscolaridad.Leer_Escolaridad = pEscolaridad.Leer_Escolaridad;
            editarEscolaridad.Observaciones_Escolaridad = pEscolaridad.Observaciones_Escolaridad;
            editarEscolaridad.Escribir_Escolaridad = pEscolaridad.Escribir_Escolaridad;

            dc.SubmitChanges();
        }

        /// <summary>
        /// Obtiene la dirección de un empleado en específico a partir de su número de cédula
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public SIGEEA_spObtenerDireccionEmpleadoResult ObtenerDireccionEmpleado(string cedula)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_spObtenerDireccionEmpleado(cedula).First();
        }

        /// <summary>
        /// Determina si un empleado ya tiene una dirección registrada
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public bool DireccionRegistradaEmpleado(string cedula)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_spObtenerDireccionEmpleadoResult direccion = new SIGEEA_spObtenerDireccionEmpleadoResult();

            if (cedula != null)
            {
                direccion = dc.SIGEEA_spObtenerDireccionEmpleado(cedula).FirstOrDefault();
                if (direccion != null) return true;
                else return false;
            }
            else return false;
        }
        //Pendiente
        /*public void EliminarEmpleado(SIGEEA_Empleado empleado)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Empleado emp = dc.SIGEEA_Empleados.First(c => c.PK_Id_Empleado == empleado.PK_Id_Empleado);
        }*/

        /// <summary>
        /// Ejecuta el procedimiento que permite editar un puesto temporal, que en este caso lo que hace es insertarse una nueva tupla con 
        /// la fecha actual.
        /// </summary>
        /// <param name="pPuesto"></param>
        /// <param name="pTarifa"></param>
        public void EditarPuesto(string pPuesto, double pTarifa)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            dc.SIGEEA_spEditarPuesto(pPuesto, pTarifa);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Verifica si existe una tupla incompleta con respecto a los días laborados
        /// </summary>
        /// <param name="pEmpleado"></param>
        /// <returns></returns>
        public bool DiaIncompleto(string pEmpleado)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_spObtenerDiaLaboralResult informacion = dc.SIGEEA_spObtenerDiaLaboral(pEmpleado).FirstOrDefault();

            if (informacion != null) return true; //Si tiene un día sin completar
            else return false; //Si no tiene días incompletos
        }

        /// <summary>
        /// Registra horas laboradas
        /// </summary>
        /// <param name="pEmpleado"></param>
        /// <param name="pPuesto"></param>
        public void RegistrarHoras(string pEmpleado, string pPuesto)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            dc.SIGEEA_spRegistraHorasLaboradas(pEmpleado, pPuesto);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Realiza un listado de horas pendientes de pago de un empleado en específico
        /// </summary>
        /// <param name="pCedula"></param>
        /// <returns></returns>
        public List<SIGEEA_spObtenerPagosEmpleadosPendientesResult> ListarPagosEmpleados(string pCedula)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_spObtenerPagosEmpleadosPendientes(pCedula).ToList();
        }

        /// <summary>
        /// Crea y cancela una factura de pago al empleado
        /// </summary>
        /// <param name="pLista"></param>
        /// <param name="pEmpleado"></param>

        public void CancelarPago(List<SIGEEA_spObtenerPagosEmpleadosPendientesResult> pLista, int pEmpleado)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();

            SIGEEA_PagEmpleado pagoEmpleado = new SIGEEA_PagEmpleado();
            pagoEmpleado.Fecha_PagEmpleados = DateTime.Now;
            pagoEmpleado.FK_Id_Cuenta = null;
            pagoEmpleado.FK_Id_Empleado = pEmpleado;

            dc.SIGEEA_PagEmpleados.InsertOnSubmit(pagoEmpleado);
            dc.SubmitChanges();

            foreach (SIGEEA_spObtenerPagosEmpleadosPendientesResult p in pLista)
            {
                string Total = p.Total.Remove(0, 1);

                dc.SIGEEA_spCancelarPagoEmpleado(p.PK_Id_HorLaboradas, pEmpleado, Convert.ToDouble(Total));

                SIGEEA_DetPagEmpleado detPago = new SIGEEA_DetPagEmpleado();

                detPago.FK_Id_HorLaboradas = p.PK_Id_HorLaboradas;
                detPago.Total_DetPagEmpleados = Convert.ToDouble(Total);
                detPago.FK_Id_PagEmpleados = pagoEmpleado.PK_Id_PagEmpleados;
                dc.SIGEEA_DetPagEmpleados.InsertOnSubmit(detPago);
                dc.SubmitChanges();
            }
        }
    }
}