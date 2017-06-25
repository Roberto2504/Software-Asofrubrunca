using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL
{
    public class PersonaMantenimiento
    {
        /// <summary>
        /// Registrar una persona nueva
        /// </summary>
        /// <param name="persona"></param>
        public SIGEEA_Persona RegistrarPersona(SIGEEA_Persona persona)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            dc.SIGEEA_Personas.InsertOnSubmit(persona);
            dc.SubmitChanges();
            return persona;
        }
        public bool ValidaCedJuridica(string ced)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            if (dc.SIGEEA_Personas.FirstOrDefault(c => c.CedJuridica_Persona == ced) != null)
                return true;
            else
                return false;
        }
        public bool ValidaCedParticar(string ced)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            if (dc.SIGEEA_Personas.FirstOrDefault(c => c.CedParticular_Persona == ced) != null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Modificar datos de la persona
        /// </summary>
        /// <param name="persona"></param>
        public void ModificarPersona(SIGEEA_Persona persona)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Persona pers = dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == persona.PK_Id_Persona);
            pers.CedParticular_Persona = persona.CedParticular_Persona;
            pers.FecNacimiento_Persona = persona.FecNacimiento_Persona;
            pers.FK_Id_Direccion = persona.FK_Id_Direccion;
            pers.FK_Id_Nacionalidad = persona.FK_Id_Nacionalidad;
            pers.Genero_Persona = persona.Genero_Persona;
            pers.PriApellido_Persona = persona.PriApellido_Persona;
            pers.PriNombre_Persona = persona.PriNombre_Persona;
            pers.SegApellido_Persona = persona.SegApellido_Persona;
            pers.SegNombre_Persona = persona.SegNombre_Persona;
            dc.SubmitChanges();
        }        

        public List<string> ListarNacionalidades()
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            List<string> nacionalidades = (from c in dc.SIGEEA_Nacionalidads select c.Nombre_Nacionalidad).ToList();
            return nacionalidades;
        }

        public List<string> ListarProvinciasNacionales()
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            List<string> provincias = (from c in dc.SIGEEA_Provincias select c.Nombre_Provincia).ToList();
            return provincias;
        }

        public List<SIGEEA_spObtenerCantonesResult> ListarCantones(string Provincia)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            List<SIGEEA_spObtenerCantonesResult> listaCantones = new List<SIGEEA_spObtenerCantonesResult>();
            listaCantones = dc.SIGEEA_spObtenerCantones(Provincia).ToList();
            return listaCantones;
        }

        public List<SIGEEA_spObtenerDistritosResult> ListarDistritos(string Canton)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_spObtenerDistritos(Canton).ToList();
        }

        public void EditarDireccion(int pPersona, string pDetalles, string pDistrito)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Distrito distrito = dc.SIGEEA_Distritos.First(c => c.Nombre_Distrito == pDistrito);
            dc.SIGEEA_spEditarDireccion(pPersona, pDetalles, distrito.PK_Id_Distrito);
            dc.SubmitChanges();
        }

        public void AgregarDireccion(int pPersona, string pDetalles, string pDistrito)
        {

            //Agrega una nueva tupla de dirección
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Direccion nuevaDireccion = new SIGEEA_Direccion();
            nuevaDireccion.Detalles_Direccion = pDetalles;
            nuevaDireccion.FK_Id_Distrito = dc.SIGEEA_Distritos.First(c => c.Nombre_Distrito == pDistrito).PK_Id_Distrito;
            dc.SIGEEA_Direccions.InsertOnSubmit(nuevaDireccion);
            dc.SubmitChanges();

            //Le asigna la nueva dirección a la persona
            SIGEEA_Persona editarPersona = dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == pPersona);
            editarPersona.FK_Id_Direccion = nuevaDireccion.PK_Id_Direccion;

            dc.SubmitChanges();
        }

        public int AutenticaPersona(string pCedula)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            if (pCedula != null)
            {
                if (dc.SIGEEA_spAutenticaPersona(pCedula).FirstOrDefault() != null)
                {
                    return dc.SIGEEA_spAutenticaPersona(pCedula).FirstOrDefault().PK_Id_Persona;
                }
                else return 0;
            }
            else return 0;
        }

        public List<SIGEEA_spObtenerContactoResult> ListarContactos(int pPersona)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();

            return dc.SIGEEA_spObtenerContacto(pPersona).ToList();
        }

        public void AgregarContacto(int pPersona, string pDato, string pTipoContacto)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            int fk_tipoContacto = dc.SIGEEA_TipContactos.FirstOrDefault(c => c.Nombre_TipContacto == pTipoContacto).PK_Id_TipContacto;

            SIGEEA_Contacto nuevoContacto = new SIGEEA_Contacto();
            nuevoContacto.Dato_Contacto = pDato;
            nuevoContacto.FK_Id_Persona = pPersona;
            nuevoContacto.FK_Id_TipContacto = fk_tipoContacto;

            dc.SIGEEA_Contactos.InsertOnSubmit(nuevoContacto);
            dc.SubmitChanges();
        }

        public void EditarContacto(SIGEEA_Contacto pContacto)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Contacto contacto = dc.SIGEEA_Contactos.First(c => c.PK_Id_Contacto == pContacto.PK_Id_Contacto);
            contacto.Dato_Contacto = pContacto.Dato_Contacto;
            contacto.FK_Id_Persona = pContacto.FK_Id_Persona;
            contacto.FK_Id_TipContacto = pContacto.FK_Id_TipContacto;
            dc.SubmitChanges();
        }
    }
}
