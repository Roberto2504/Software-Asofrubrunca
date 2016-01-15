using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

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
        public void RegistrarFinca(SIGEEA_Finca finca, SIGEEA_Asociado asociado, SIGEEA_Direccion direccion)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            dc.SIGEEA_Direccions.InsertOnSubmit(direccion);
            dc.SubmitChanges();
            finca.FK_Id_Direccion = direccion.PK_Id_Direccion;
            finca.FK_Id_Asociado = asociado.PK_Id_Asociado;
            dc.SIGEEA_Fincas.InsertOnSubmit(finca);
            dc.SubmitChanges();

            SIGEEA_Finca modFinca = dc.SIGEEA_Fincas.First(c => c.PK_Id_Finca == finca.PK_Id_Finca);
            SIGEEA_Persona persona = dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == asociado.FK_Id_Persona);
            modFinca.Codigo_Finca = "F" + finca.PK_Id_Finca + persona.PriNombre_Persona[0] + persona.PriApellido_Persona[0] + persona.SegApellido_Persona[0];
            dc.SubmitChanges();
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
           
        }
        /// <summary>
        /// Registrar Lote
        /// </summary>
        /// <param name="finca"></param>
        /// <param name="lote"></param>
        public void RegistrarLote(SIGEEA_Finca finca, SIGEEA_Lote lote)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            lote.FK_Id_Finca = finca.PK_Id_Finca;
            dc.SIGEEA_Lotes.InsertOnSubmit(lote);
            dc.SubmitChanges();

            SIGEEA_Lote modLote = dc.SIGEEA_Lotes.First(c => c.PK_Id_Lote == lote.PK_Id_Lote);
            modLote.Codigo_Lote = "F" + finca.PK_Id_Finca + "L" + modLote.PK_Id_Lote;
            dc.SubmitChanges();
        }
    }
}
