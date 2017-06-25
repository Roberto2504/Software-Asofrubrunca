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
        public void RegistrarInsumo(SIGEEA_Insumo insumo, string UnidadMedida, string Cantidad)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            insumo.Estado_Insumo = true;
            dc.SIGEEA_Insumos.InsertOnSubmit(insumo);
            dc.SubmitChanges();
            SIGEEA_UniMedida uniMedida = new SIGEEA_UniMedida();
            uniMedida = dc.SIGEEA_UniMedidas.First(c => c.Nombre_UniMedida == UnidadMedida);
            SIGEEA_InvInsumo invInsumo = new SIGEEA_InvInsumo();
            invInsumo.FK_UniMedida = uniMedida.PK_Id_UniMedida;
            invInsumo.Cantidad_InvInsumo = Convert.ToDouble(Cantidad);
            invInsumo.FK_Id_Insumo = insumo.PK_Id_Insumo;

            dc.SIGEEA_InvInsumos.InsertOnSubmit(invInsumo);
            dc.SubmitChanges();

        }
        /// <summary>
        /// Modificar insumo
        /// </summary>
        /// <param name="insumo"></param>
        public void ModificarInsumo(SIGEEA_Insumo insumo, SIGEEA_InvInsumo invInsumo, string UnidadMedida)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Insumo modInsumo = dc.SIGEEA_Insumos.First(c => c.PK_Id_Insumo == insumo.PK_Id_Insumo);
            modInsumo.Nombre_Insumo = insumo.Nombre_Insumo;
            modInsumo.Descripcion_Insumo = modInsumo.Descripcion_Insumo;
            SIGEEA_UniMedida uniMedida = new SIGEEA_UniMedida();
            uniMedida = dc.SIGEEA_UniMedidas.First(c => c.Nombre_UniMedida == UnidadMedida);
            SIGEEA_InvInsumo inv = dc.SIGEEA_InvInsumos.First(c => c.FK_Id_Insumo == insumo.PK_Id_Insumo);
            inv.Cantidad_InvInsumo = invInsumo.Cantidad_InvInsumo;
            inv.FK_UniMedida = uniMedida.PK_Id_UniMedida;
            dc.SubmitChanges();

        }
        /// <summary>
        /// Eliminar insumo (solo le cambia el estado)
        /// </summary>
        /// <param name="insumo"></param>
        public void EliminarInsumo(SIGEEA_Insumo insumo)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_Insumo modInsumo = dc.SIGEEA_Insumos.First(c => c.PK_Id_Insumo == insumo.PK_Id_Insumo);
            modInsumo.Estado_Insumo = false;
            dc.SubmitChanges();

        }
        /// <summary>
        /// Realizar Pedido
        /// </summary>
        /// <param name="NuevoPedido"></param>
        public void PedidoInsumo(SIGEEA_PedInsumo nuevoPedido)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            dc.SIGEEA_PedInsumos.InsertOnSubmit(nuevoPedido);
            dc.SubmitChanges();

        }
        /// <summary>
        /// Listar
        /// </summary>
        /// <param name="nomInsumo"></param>
        public List<SIGEEA_spListarInsumosResult> ListarInsumos(string nomInsumo)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_spListarInsumos(nomInsumo).ToList();
        }
        /// <summary>
        /// ObtenerInsumo
        /// </summary>
        /// <param name="pkInsumo"></param>
        public SIGEEA_spObtenerInsumoResult ObtenerInsumo(int pkInsumo)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            return dc.SIGEEA_spObtenerInsumo(pkInsumo).FirstOrDefault();
        }
        /// <summary>
        /// Sumar inventario
        /// </summary>
        /// <param name="pkInsumo"></param>
        public void SumarInventario(int invInsumo, double cantidad)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_InvInsumo insumo = dc.SIGEEA_InvInsumos.FirstOrDefault(c => c.FK_Id_Insumo == invInsumo);
            insumo.Cantidad_InvInsumo += cantidad;
            dc.SubmitChanges();

        }
        /// <summary>
        /// Restar inventario
        /// </summary>
        /// <param name="pkInsumo"></param>
        public void RestarInventario(int invInsumo, double cantidad)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            SIGEEA_InvInsumo insumo = dc.SIGEEA_InvInsumos.FirstOrDefault(c => c.FK_Id_Insumo == invInsumo);
            insumo.Cantidad_InvInsumo = insumo.Cantidad_InvInsumo - cantidad;
            dc.SubmitChanges();

        }
        public SIGEEA_FacInsumo AgregarFactura(SIGEEA_FacInsumo Factura)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            dc.SIGEEA_FacInsumos.InsertOnSubmit(Factura);
            dc.SubmitChanges();
            return Factura;
        }
        public void AgregarDetalleFactura(SIGEEA_DetFacInsumo Factura)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            dc.SIGEEA_DetFacInsumos.InsertOnSubmit(Factura);
            dc.SubmitChanges();
        }
    }
}
