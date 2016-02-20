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
            dc.SubmitChanges();
            cliente.FK_Id_Persona = persona.PK_Id_Persona;
            cliente.FK_Id_CatCliente = pkCategoria;
            cliente.Estado_Cliente = true;
            cliente.FK_Id_Empresa = 1;
            dc.SIGEEA_Clientes.InsertOnSubmit(cliente);
            dc.SubmitChanges();
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
        /// Modificar Cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="creCliente"></param>
        /// <param name="persona"></param>
        public void ModificarCliente(SIGEEA_Cliente cliente, int pkCategoria, SIGEEA_Persona pPersona)
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
        public SIGEEA_spObtenerCategoriaResult ObtenerCategorias(int pkCatCliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spObtenerCategoria(pkCatCliente).FirstOrDefault();
        }
        /// <summary>
        /// Listar Categorias
        /// </summary>
        /// <param name="Nombre"></param>
       
        public List<string> ListarCategorias()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<string> Categorias = new List<string>();
            Categorias = (from c in dc.SIGEEA_CatClientes select c.Nombre_CatCliente).ToList();
            return Categorias;
        }
        /// <summary>
        /// Listar Categorias
        /// </summary>
        /// <param name="Nombre"></param>

        public int ObtenerPkCategoria(string nombre)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();  
            return dc.SIGEEA_CatClientes.First(c => c.Nombre_CatCliente == nombre).PK_Id_CatCliente;
        }
       
    }
}
