using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL
{
    public class ProductoMantenimiento
    {
        /// <summary>
        /// Registrar tipo de producto
        /// </summary>
        /// <param name="producto"></param>
        public void RegistrarTipoProducto(SIGEEA_TipProducto producto)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            dc.SIGEEA_TipProductos.InsertOnSubmit(producto);
            dc.SubmitChanges();
            SIGEEA_PreProCompra compra = new SIGEEA_PreProCompra();
            compra.FecRegistro_PreProCompra = DateTime.Now;
            compra.FK_Id_TipProducto = producto.PK_Id_TipProducto;
            compra.PreExtranjero_PreProCompra = 1;
            compra.PreNacional_PreProCompra = 1;
            dc.SIGEEA_PreProCompras.InsertOnSubmit(compra);
            SIGEEA_PreProVenta venta = new SIGEEA_PreProVenta();
            venta.FecRegistro_PreProVenta = DateTime.Now;
            venta.FK_Id_Moneda = 1;
            venta.FK_Id_TipProducto = producto.PK_Id_TipProducto;
            venta.PreExtranjero_PreProVenta = 1;
            venta.PreNacional_PreProVenta = 1;
            dc.SIGEEA_PreProVentas.InsertOnSubmit(venta);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Modificar un tipo de producto
        /// </summary>
        /// <param name="producto"></param>
        public void ModificarTipoProducto(SIGEEA_TipProducto producto)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_TipProducto nuevo = dc.SIGEEA_TipProductos.First(c => c.Nombre_TipProducto == producto.Nombre_TipProducto);
            nuevo.Nombre_TipProducto = producto.Nombre_TipProducto;
            nuevo.Calidad_TipProducto = producto.Calidad_TipProducto;
            nuevo.Descripcion_TipProducto = producto.Descripcion_TipProducto;
        }


        /// <summary>
        /// Modificar precio de compra (se inserta un nuevo registro)
        /// </summary>
        /// <param name="precio"></param>
        public void ActualizarPrecioCompra(SIGEEA_PreProCompra precio)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            dc.SIGEEA_PreProCompras.InsertOnSubmit(precio);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Modificar precio de venta (se inserta un nuevo registro)
        /// </summary>
        /// <param name="precio"></param>
        public void ActualizarPrecioVenta(SIGEEA_PreProVenta precio)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            dc.SIGEEA_PreProVentas.InsertOnSubmit(precio);
            SIGEEA_TipProducto produc = new SIGEEA_TipProducto();
            dc.SubmitChanges();
        }

        public List<string> ListarTipoProducto()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<string> tipos = new List<string>();
            tipos = (from c in dc.SIGEEA_TipProductos select c.Nombre_TipProducto).ToList();
            return tipos;
        }
        public List<SIGEEA_spListarProductosResult> ListarProductos(string nombre)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spListarProductos(nombre).ToList();
        }


        public void IncrementarInventario(int pUMedida, int pProducto, double pCantidad)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                List<SIGEEA_spObtenerInvProductoResult> inventario = dc.SIGEEA_spObtenerInvProducto().ToList();
                bool indicador = false;

                foreach (SIGEEA_spObtenerInvProductoResult item in inventario)
                {
                    if (item.FK_Id_TipProducto == pProducto && item.FK_Id_UniMedida == pUMedida)//Si ya existe inventario registrado del producto
                    {
                        ActualizarInvProducto(item.PK_Id_DetInvProductos, pCantidad);
                        indicador = true;
                        break;
                    }
                }

                if (indicador == false) //Si no existen registros del producto en el inventario
                {
                    InsertarInvProducto(pUMedida, pProducto, pCantidad);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al actualizar: " + ex.Message);
            }
        }

        private void ActualizarInvProducto(int pkDetalle, double pCantidad)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                SIGEEA_DetInvProducto detalle = dc.SIGEEA_DetInvProductos.First(c => c.PK_Id_DetInvProductos == pkDetalle);
                if (pCantidad <= 0) detalle.Cantidad_DetInvProductos += 0;
                else detalle.Cantidad_DetInvProductos += pCantidad;
                detalle.PK_Id_DetInvProductos = detalle.PK_Id_DetInvProductos;
                detalle.FK_Id_InvProductos = detalle.FK_Id_InvProductos;
                detalle.FK_Id_TipProducto = detalle.FK_Id_TipProducto;
                detalle.FK_Id_UniMedida = detalle.FK_Id_UniMedida;
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al actualizar: " + ex.Message);
            }
        }

        private void InsertarInvProducto(int pkUMedida, int pkProducto, double pCantidad)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                SIGEEA_DetInvProducto detalle = new SIGEEA_DetInvProducto();
                detalle.FK_Id_InvProductos = 1;
                detalle.FK_Id_TipProducto = pkProducto;
                detalle.FK_Id_UniMedida = pkUMedida;
                detalle.Cantidad_DetInvProductos = pCantidad;
                dc.SIGEEA_DetInvProductos.InsertOnSubmit(detalle);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al actualizar: " + ex.Message);
            }
        }
    }
}
