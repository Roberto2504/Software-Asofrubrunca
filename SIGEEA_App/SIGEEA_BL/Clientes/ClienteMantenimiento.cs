using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;
using System.Collections.ObjectModel;


namespace SIGEEA_BL
{

    public class ClienteMantenimiento
    {

        /// <summary>
        /// Registrar cliente (se registra primero la persona, y luego el cliente)
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="cliente"></param>
        /// <param name="creCliente"></param>
        public void RegistrarCliente(SIGEEA_Persona persona, SIGEEA_Cliente cliente, int pkCategoria)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            PersonaMantenimiento nuevaPersona = new PersonaMantenimiento();
            nuevaPersona.RegistrarPersona(persona);
          
            cliente.FK_Id_Persona = persona.PK_Id_Persona;
            cliente.FK_Id_CatCliente = pkCategoria;
            cliente.Estado_Cliente = true;
            cliente.FK_Id_Empresa = 1;
            dc.SIGEEA_Clientes.InsertOnSubmit(cliente);
            dc.SubmitChanges();
        }
        /// <summary>
        /// Registrar categoria
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="cliente"></param>
        /// <param name="creCliente"></param>
        public int RegistrarCategoria(SIGEEA_CatCliente catCliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            dc.SIGEEA_CatClientes.InsertOnSubmit(catCliente);
            dc.SubmitChanges();
            return catCliente.PK_Id_CatCliente;
        }
        /// <summary>
        /// Editar categoria
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="cliente"></param>
        /// <param name="creCliente"></param>
        public int EditarCategoria(SIGEEA_CatCliente catCliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_CatCliente Editar = dc.SIGEEA_CatClientes.First(c => c.PK_Id_CatCliente == catCliente.PK_Id_CatCliente);
            Editar.Limite_CatCliente = catCliente.Limite_CatCliente;
            Editar.RanPagos_CatCliente = catCliente.RanPagos_CatCliente;
            Editar.TieMaximo_CatCliente = catCliente.TieMaximo_CatCliente;
            Editar.FK_Id_TipCatCliente = catCliente.FK_Id_TipCatCliente;
            dc.SubmitChanges();
            return Editar.PK_Id_CatCliente;
        }
        /// <summary>
        /// Eliminar un cliente, solo cambia de estado
        /// </summary>
        /// <param name="cliente"></param>
        public void EliminarCliente(int pk_id_cliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Cliente nuevo = dc.SIGEEA_Clientes.First(c => c.PK_Id_Cliente == pk_id_cliente);
            nuevo.Estado_Cliente = false;
            dc.SubmitChanges();
        }
        /// <summary>
        /// Activar un cliente, solo cambia de estado
        /// </summary>
        /// <param name="cliente"></param>
        public void ActivarCliente(int pk_id_cliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Cliente nuevo = dc.SIGEEA_Clientes.First(c => c.PK_Id_Cliente == pk_id_cliente);
            nuevo.Estado_Cliente = true;
            dc.SubmitChanges();
        }
        /// <summary>
        /// Modificar Cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="creCliente"></param>
        /// <param name="persona"></param>
        public void ModificarCliente(int pkCategoria, SIGEEA_Persona pPersona)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            SIGEEA_Cliente client = dc.SIGEEA_Clientes.First(c => c.FK_Id_Persona == pPersona.PK_Id_Persona);
            client.FK_Id_CatCliente = pkCategoria;
            PersonaMantenimiento nuevoMant = new PersonaMantenimiento();
            nuevoMant.ModificarPersona(pPersona);
            dc.SubmitChanges();
        }
        /// <summary>
        /// Listar Cliente
        /// </summary>
        /// <param name="Cedula O Nombre"></param>
        public List<SIGEEA_spListarClienteResult> ListarClientes(string CedNombre)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spListarCliente(CedNombre).ToList();
        }
        /// <summary>
        /// Obtener Cliente
        /// </summary>
        /// <param name="PK_IdCliente"></param>
        public SIGEEA_spObtenerClienteResult ObtenerCliente(int pkIdCliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spObtenerCliente(pkIdCliente).First();
        }
        /// <summary>
        /// Obtener Categorias
        /// </summary>
        /// <param name="Nombre"></param>
        public SIGEEA_spObtenerCategoriaResult ObtenerCategorias(int pkIdCliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spObtenerCategoria(pkIdCliente).FirstOrDefault();
        }
        /// <summary>
        /// Obtener Categorias
        /// </summary>
        /// <param name="Nombre"></param>
        public SIGEEA_spObtenerCategoriaClienteResult ObtenerCategoriaCliente(int pkIdCliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spObtenerCategoriaCliente(pkIdCliente).FirstOrDefault();
        }
        /// <summary>
        /// Listar Categorias
        /// </summary>
        /// <param name="Nombre"></param>

        public List<string> ListarCategorias()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<string> Categorias = new List<string>();
            Categorias = (from c in dc.SIGEEA_TipCatClientes select c.Nombre_TipCatCliente).ToList();
            return Categorias;
        }
        /// <summary>
        /// Listar Categorias
        /// </summary>
        /// <param name="Nombre"></param>

        public SIGEEA_CatAsociado ObtenerCategoria(int pkCat)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return (from c in dc.SIGEEA_CatAsociados where pkCat == c.PK_Id_CatAsociado select c).FirstOrDefault(); ;
        }
        /// <summary>
        /// Listar Categorias
        /// </summary>
        /// <param name="Nombre"></param>

        public string ObtenerTipCategoria(int pkIdCatCliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_TipCatClientes.First(c => c.PK_Id_TipCatCliente == pkIdCatCliente).Nombre_TipCatCliente;
        }
        /// <summary>
        /// Listar Categorias
        /// </summary>
        /// <param name="Nombre"></param>

        public int ObtenerPkTipCategoria(string nombre)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_TipCatClientes.First(c => c.Nombre_TipCatCliente == nombre).PK_Id_TipCatCliente;
        }
        /// <summary>
        /// Restar Inventario
        /// </summary>
        /// <param name="PK_Id_TipProducto, Cantidad"></param>
        public void RestarInventario(int pIdTipProducto, double Cantidad)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_DetInvProducto detInvPro = dc.SIGEEA_DetInvProductos.First(c => c.FK_Id_TipProducto == pIdTipProducto);
            detInvPro.Cantidad_DetInvProductos = Cantidad;
            dc.SubmitChanges();
        }
        /// <summary>
        /// SumarInventario
        /// </summary>
        /// <param name="PK_Id_TipProducto, Cantidad"></param>
        public void SumarInventario(int pIdTipProducto, double Cantidad)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_DetInvProducto detInvPro = dc.SIGEEA_DetInvProductos.First(c => c.FK_Id_TipProducto == pIdTipProducto);
            detInvPro.Cantidad_DetInvProductos = Cantidad;
            dc.SubmitChanges();

        }

        /// <summary>
        /// ObtenerCreditosCliente
        /// </summary>
        /// <param name="PK_Id_Cliente"></param>
        public List<SIGEEA_spListarCreditoClienteResult> ListarCreditosCliente(int PK_Id_Cliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spListarCreditoCliente(PK_Id_Cliente).ToList(); ;
        }

        /// <summary>
        /// ObtenerLimiteCredito
        /// </summary>
        /// <param name="PK_Id_Cliente"></param>
        public SIGEEA_spObtenerCategoriaClienteResult LimiteCreditoCliente(int PK_Id_Cliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spObtenerCategoriaCliente(PK_Id_Cliente).FirstOrDefault();
        }

    }
}
