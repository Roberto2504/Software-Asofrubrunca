using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL
{
    public class InsumoMantenimiento
    {
        /// <summary>
        /// Registrar insumo
        /// </summary>
        /// <param name="insumo"></param>
        public void RegistrarInsumo(SIGEEA_Insumo insumo)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            insumo.Estado_Insumo = true;
            dc.SIGEEA_Insumos.InsertOnSubmit(insumo);
            dc.SubmitChanges();
            //me cago en todoooo
        }
        /// <summary>
        /// Modificar insumo
        /// </summary>
        /// <param name="insumo"></param>
        public void ModificarInsumo(SIGEEA_Insumo insumo)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Insumo modInsumo = dc.SIGEEA_Insumos.First(c => c.PK_Id_Insumo == insumo.PK_Id_Insumo);
            modInsumo.Nombre_Insumo = insumo.Nombre_Insumo;
            modInsumo.Descripcion_Insumo = modInsumo.Descripcion_Insumo;
            dc.SubmitChanges();
            //me cago en todoooo
        }
        /// <summary>
        /// Eliminar insumo (solo le cambia el estado)
        /// </summary>
        /// <param name="insumo"></param>
        public void EliminarInsumo(SIGEEA_Insumo insumo)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Insumo modInsumo = dc.SIGEEA_Insumos.First(c => c.PK_Id_Insumo == insumo.PK_Id_Insumo);
            modInsumo.Estado_Insumo = false;
            dc.SubmitChanges();
            //me cago en todoooo
        }
        /// <summary>
        /// Realizar Pedido
        /// </summary>
        /// <param name="insumo"></param>
        public void PedidoInsumo(SIGEEA_Insumo insumo)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Insumo modInsumo = dc.SIGEEA_Insumos.First(c => c.PK_Id_Insumo == insumo.PK_Id_Insumo);
            modInsumo.Nombre_Insumo = insumo.Nombre_Insumo;
            modInsumo.Descripcion_Insumo = modInsumo.Descripcion_Insumo;
            dc.SubmitChanges();
            //me cago en todoooo
        }
    }
}
