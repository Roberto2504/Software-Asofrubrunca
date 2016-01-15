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
        }

        /// <summary>
        /// Modificar un tipo de producto
        /// </summary>
        /// <param name="producto"></param>
        public void ModificarTipoProducto(SIGEEA_TipProducto producto)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_TipProducto nuevo = dc.SIGEEA_TipProductos.First(c => c.PK_Id_TipProducto == producto.PK_Id_TipProducto);
            //nuevo.Nombre_TipProducto = producto.Nombre_TipProducto;
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
    }
}
