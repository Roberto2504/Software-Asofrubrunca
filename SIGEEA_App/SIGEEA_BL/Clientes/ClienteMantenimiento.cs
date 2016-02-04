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
        public void RegistrarCliente(SIGEEA_Persona persona, SIGEEA_Cliente cliente, SIGEEA_CatCliente catCliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            PersonaMantenimiento nuevaPersona = new PersonaMantenimiento();
            nuevaPersona.RegistrarPersona(persona);
            dc.SubmitChanges();
            dc.SIGEEA_CatClientes.InsertOnSubmit(catCliente);
            dc.SubmitChanges();
            cliente.FK_Id_Persona = persona.PK_Id_Persona;
            cliente.FK_Id_CatCliente = catCliente.PK_Id_CatCliente;
            cliente.Estado_Cliente = true;
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
        public void ModificarCliente(SIGEEA_Cliente cliente, SIGEEA_CatCliente catCliente, SIGEEA_Persona persona)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Persona pers = dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == cliente.FK_Id_Persona);
            SIGEEA_Cliente client = dc.SIGEEA_Clientes.First(c => c.FK_Id_Persona == pers.PK_Id_Persona);
            SIGEEA_CatCliente cred = dc.SIGEEA_CatClientes.First(c => c.PK_Id_CatCliente == client.FK_Id_CatCliente);
            client.FK_Id_CatCliente = cliente.FK_Id_CatCliente;
            PersonaMantenimiento nuevoMant = new PersonaMantenimiento();
            nuevoMant.ModificarPersona(pers);
            cred.Limite_CatCliente = catCliente.Limite_CatCliente;
            cred.TieMaximo_CatCliente = catCliente.TieMaximo_CatCliente;
            cred.RanPagos_CatCliente = catCliente.RanPagos_CatCliente;
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
        

        }
}
