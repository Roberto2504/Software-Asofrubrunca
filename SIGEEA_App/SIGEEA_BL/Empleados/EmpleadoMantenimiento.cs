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
            DataClasses1DataContext dc = new DataClasses1DataContext();
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

        public SIGEEA_spObtenerEmpleadoResult AutenticaEmpleado(string pCedula)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spObtenerEmpleado(pCedula).First();
        }

        public void EditarEmpleado(SIGEEA_Persona pPersona, SIGEEA_Escolaridad pEscolaridad)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
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

        public SIGEEA_spObtenerDireccionEmpleadoResult ObtenerDireccionEmpleado (string cedula)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spObtenerDireccionEmpleado(cedula).First();
        }

        public bool DireccionRegistradaEmpleado(string cedula)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Empleado emp = dc.SIGEEA_Empleados.First(c => c.PK_Id_Empleado == empleado.PK_Id_Empleado);
        }*/
    }
}
