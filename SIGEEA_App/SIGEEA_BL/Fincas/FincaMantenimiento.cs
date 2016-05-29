using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;
using System.Collections.ObjectModel;

namespace SIGEEA_BL
{
    public class FincaMantenimiento
    {
        /// <summary>
        /// Registrar Finca
        /// </summary>
        /// <param name="finca"></param>
        /// <param name="asociado"></param>
        /// <param name="direccion"></param>
        public int RegistrarFinca(SIGEEA_Finca finca, SIGEEA_Asociado asociado)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            finca.FK_Id_Asociado = asociado.PK_Id_Asociado;
            finca.Codigo_Finca = "hi";
            dc.SIGEEA_Fincas.InsertOnSubmit(finca);

            dc.SubmitChanges();

            SIGEEA_Finca modFinca = dc.SIGEEA_Fincas.First(c => c.PK_Id_Finca == finca.PK_Id_Finca);
            SIGEEA_Persona persona = dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == asociado.FK_Id_Persona);
            modFinca.Codigo_Finca = "F" + finca.PK_Id_Finca + persona.PriNombre_Persona[0] + persona.PriApellido_Persona[0] + persona.SegApellido_Persona[0];
            dc.SubmitChanges();
            return modFinca.PK_Id_Finca;
        }
        /// <summary>
        /// Modificar Finca
        /// </summary>
        /// <param name="finca"></param>
        /// <param name="asociado"></param>
        /// <param name="direccion"></param>
        public void ModificarFinca(SIGEEA_Finca finca)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Finca editarFinca = dc.SIGEEA_Fincas.First(c => c.PK_Id_Finca == finca.PK_Id_Finca);
            editarFinca.NomDuenno_Finca = finca.NomDuenno_Finca;
            editarFinca.ApeDuenno_Finca = finca.ApeDuenno_Finca;
            editarFinca.Codigo_Finca = finca.Codigo_Finca;
            editarFinca.FK_Id_Direccion = finca.FK_Id_Direccion;
            editarFinca.FK_Id_Asociado = finca.FK_Id_Asociado;
            dc.SubmitChanges();

        }
        /// <summary>
        /// Cambiar estado Lote
        /// </summary>
        /// <param name="lote"></param>

        public void CambiarEstadoLote(SIGEEA_Lote lote)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Lote cambioLote = dc.SIGEEA_Lotes.First(c => c.PK_Id_Lote == lote.PK_Id_Lote);
            cambioLote.Estado_Lote = lote.Estado_Lote;
            dc.SubmitChanges();
        }
        /// <summary>
        /// Registrar Lote
        /// </summary>
        /// <param name="finca"></param>
        /// <param name="lote"></param>
        public void RegistrarLote(SIGEEA_Lote lote)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            dc.SIGEEA_Lotes.InsertOnSubmit(lote);
            dc.SubmitChanges();
        }
        /// <summary>
        /// Editar Lote
        /// </summary>
        /// <param name="lote"></param>
        public void EditarLote(SIGEEA_Lote lote)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Lote editarLote = dc.SIGEEA_Lotes.First(c => c.PK_Id_Lote == lote.PK_Id_Lote);
            editarLote.Tamanno_Lote = lote.Tamanno_Lote;
            dc.SubmitChanges();
        }
        /// <summary>
        /// Registrar Direcciones
        /// </summary>
        /// <param name="idFinca"></param>
        public SIGEEA_spObtenerDireccionFincaResult ObtenerDireccionFinca(int pkFinca)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spObtenerDireccionFinca(pkFinca).First();
        }
        /// <summary>
        /// Determina si una finca ya tiene una dirección registrada
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public bool DireccionRegistradaFinca(string pkId)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_spObtenerDireccionFincaResult direccion = new SIGEEA_spObtenerDireccionFincaResult();

            if (pkId != null)
            {
                direccion = dc.SIGEEA_spObtenerDireccionFinca(Convert.ToInt32(pkId)).FirstOrDefault();
                if (direccion != null) return true;
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Determina si un asociado ya tiene una finca registrada
        /// </summary>
        /// <param name="pkId"></param>
        /// <returns></returns>
        public bool FincaRegistradaAsociado(int pkId)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Finca finca = dc.SIGEEA_Fincas.FirstOrDefault(c => c.FK_Id_Asociado == pkId);

            if (finca != null)
            {
                return true;
            }
            else return false;
        }
        public void EditarDireccion(int pFinca, string pDetalles, string pDistrito)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Distrito distrito = dc.SIGEEA_Distritos.First(c => c.Nombre_Distrito == pDistrito);
            dc.SIGEEA_spEditarDireccionFinca(pFinca, pDetalles, distrito.PK_Id_Distrito);
            dc.SubmitChanges();
        }
        public SIGEEA_Persona ObtenerInfoAsociado(int fk_persona)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Persona asociado = new SIGEEA_Persona();
            asociado = dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == fk_persona);
            return asociado;
        }
        public SIGEEA_Asociado ObtenerAsociado(int pkAsociado)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Asociado asociado = new SIGEEA_Asociado();
            asociado = dc.SIGEEA_Asociados.First(c => c.PK_Id_Asociado == pkAsociado);
            return asociado;
        }

        public void AgregarDireccion(int pFinca, string pDetalles, string pDistrito)
        {

            //Agrega una nueva tupla de dirección
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Direccion nuevaDireccion = new SIGEEA_Direccion();
            nuevaDireccion.Detalles_Direccion = pDetalles;
            nuevaDireccion.FK_Id_Distrito = dc.SIGEEA_Distritos.First(c => c.Nombre_Distrito == pDistrito).PK_Id_Distrito;
            dc.SIGEEA_Direccions.InsertOnSubmit(nuevaDireccion);
            dc.SubmitChanges();

            //Le asigna la nueva dirección a la persona
            SIGEEA_Finca editarFinca = dc.SIGEEA_Fincas.First(c => c.PK_Id_Finca == pFinca);
            editarFinca.FK_Id_Direccion = nuevaDireccion.PK_Id_Direccion;

            dc.SubmitChanges();
        }
        public SIGEEA_Finca ObtenerInfoFinca(SIGEEA_Asociado asociado)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Finca finca = dc.SIGEEA_Fincas.First(c => c.FK_Id_Asociado == asociado.PK_Id_Asociado);
            return finca;
        }

    }
}