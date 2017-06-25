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
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            finca.FK_Id_Asociado = asociado.PK_Id_Asociado;
            finca.FecRegistro_Finca = DateTime.Now;
            finca.FK_Id_Direccion = null;
            dc.SIGEEA_Fincas.InsertOnSubmit(finca);
            dc.SubmitChanges();
            return finca.PK_Id_Finca;
        }
        /// <summary>
        /// Modificar Finca
        /// </summary>
        /// <param name="finca"></param>
        /// <param name="asociado"></param>
        /// <param name="direccion"></param>
        public void ModificarFinca(SIGEEA_Finca finca)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Finca editarFinca = dc.SIGEEA_Fincas.First(c => c.PK_Id_Finca == finca.PK_Id_Finca);
            editarFinca.PriNomDuenno_Finca = finca.PriNomDuenno_Finca;
            editarFinca.SegNomDuenno_Finca = finca.SegNomDuenno_Finca;
            editarFinca.PriApeDuenno_Finca = finca.PriApeDuenno_Finca;
            editarFinca.SegApeDuenno_Finca = finca.SegApeDuenno_Finca;
            editarFinca.Codigo_Finca = finca.Codigo_Finca;
            editarFinca.Alquilada_Finca = finca.Alquilada_Finca;
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
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
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
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            dc.SIGEEA_Lotes.InsertOnSubmit(lote);
            dc.SubmitChanges();
        }
        /// <summary>
        /// Editar Lote
        /// </summary>
        /// <param name="lote"></param>
        public void EditarLote(SIGEEA_Lote lote)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Lote editarLote = dc.SIGEEA_Lotes.FirstOrDefault(c => c.PK_Id_Lote == lote.PK_Id_Lote);
            editarLote.Tamanno_Lote = lote.Tamanno_Lote;
            editarLote.Estado_Lote = lote.Estado_Lote;
            dc.SubmitChanges();
        }
        /// <summary>
        /// Existe Lote
        /// </summary>
        /// <param name="lote"></param>
        public bool ExisteLote(int pklote)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Lote Lote = dc.SIGEEA_Lotes.FirstOrDefault(c => c.PK_Id_Lote == pklote);
            if (Lote != null) return true; else return false;
           
        }
        /// <summary>
        /// Eliminar finca, solo le cambia el estado
        /// </summary>
        /// <param name="pidFinca"></param>
        public void CambiarEstadoFinca(int pidFinca)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Finca editarFinca = dc.SIGEEA_Fincas.FirstOrDefault(c => c.PK_Id_Finca == pidFinca);
            if(editarFinca.Estado_Finca == "1")
            {
                editarFinca.Estado_Finca = "0";
            }else editarFinca.Estado_Finca = "1";
            dc.SubmitChanges();
        }
        /// <summary>
        /// Registrar Direcciones
        /// </summary>
        /// <param name="idFinca"></param>
        public SIGEEA_spObtenerDireccionFincaResult ObtenerDireccionFinca(int pkFinca)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_spObtenerDireccionFinca(pkFinca).First();
        }
        /// <summary>
        /// Determina si una finca ya tiene una dirección registrada
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public bool DireccionRegistradaFinca(string pkId)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
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
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Finca finca = dc.SIGEEA_Fincas.FirstOrDefault(c => c.FK_Id_Asociado == pkId);
            if (finca != null)
            {
                return true;
            }
            else return false;
        }
        public void EditarDireccion(int pFinca, string pDetalles, string pDistrito)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Distrito distrito = dc.SIGEEA_Distritos.First(c => c.Nombre_Distrito == pDistrito);
            dc.SIGEEA_spEditarDireccionFinca(pFinca, pDetalles, distrito.PK_Id_Distrito);
            dc.SubmitChanges();
        }
        public SIGEEA_Persona ObtenerInfoAsociado(int fk_persona)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Persona asociado = new SIGEEA_Persona();
            asociado = dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == fk_persona);
            return asociado;
        }
        public SIGEEA_Asociado ObtenerAsociado(int pkAsociado)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Asociado asociado = new SIGEEA_Asociado();
            asociado = dc.SIGEEA_Asociados.First(c => c.PK_Id_Asociado == pkAsociado);
            return asociado;
        }

        public void AgregarDireccion(int pFinca, string pDetalles, string pDistrito)
        {

            //Agrega una nueva tupla de dirección
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
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
        public List<SIGEEA_spListarFincasResult> ListarInfoFinca(int pPkAsociado, string pCodigo, string pNombre)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            if(pPkAsociado == 0)
            {
                return dc.SIGEEA_spListarFincas(pCodigo, null, pNombre).ToList();
            }else 
            return dc.SIGEEA_spListarFincas(pCodigo, pPkAsociado, pNombre).ToList();
        }
        public SIGEEA_Finca ObtenerFinca(int pkIdFinca)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_Fincas.FirstOrDefault(c => c.PK_Id_Finca == pkIdFinca);
        }
        public SIGEEA_Finca ObtenerFincaPorIdAsociado(int pkIdAsociado)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_Fincas.FirstOrDefault(c => c.FK_Id_Asociado == pkIdAsociado);
        }
        public int ObtenerIdUltimaFinca()
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();

            return Convert.ToInt32(dc.SIGEEA_spObtenerIdUltimaFinca().FirstOrDefault().PKFinca);
        }
        public List<SIGEEA_Lote> ListarLote(int fkFinca)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return (from c in dc.SIGEEA_Lotes where c.FK_Id_Finca == fkFinca select c).ToList();
        }
        public SIGEEA_Lote ObtenerLote(int pkLote)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return (from c in dc.SIGEEA_Lotes where c.PK_Id_Lote == pkLote select c).FirstOrDefault();
        }

    }
}