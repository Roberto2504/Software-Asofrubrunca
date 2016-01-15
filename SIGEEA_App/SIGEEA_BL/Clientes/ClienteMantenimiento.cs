using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

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
        //public void RegistrarCliente(SIGEEA_Persona persona, SIGEEA_Cliente cliente, SIGEEA_CreCliente creCliente)
        //{
        //    DataClasses1DataContext dc = new DataClasses1DataContext();
        //    PersonaMantenimiento nuevaPersona = new PersonaMantenimiento();
        //    nuevaPersona.RegistrarPersona(persona);
        //    dc.SubmitChanges();
        //    dc.SIGEEA_CreClientes.InsertOnSubmit(creCliente);
        //    dc.SubmitChanges();
        //    cliente.FK_Id_Persona = persona.PK_Id_Persona;
        //    cliente.FK_Id_CreCliente = creCliente.PK_Id_CreCliente;
        //    cliente.Categoria_Cliente = 3;
        //    cliente.Estado_Cliente = true;
        //    dc.SIGEEA_Clientes.InsertOnSubmit(cliente);
        //    dc.SubmitChanges();
        //}
        ///// <summary>
        ///// Eliminar un cliente, solo cambia de estado
        ///// </summary>
        ///// <param name="cliente"></param>
        //public void EliminarCliente(SIGEEA_Cliente cliente)
        //{
        //    DataClasses1DataContext dc = new DataClasses1DataContext();
        //    SIGEEA_Cliente nuevo = dc.SIGEEA_Clientes.First(c => c.PK_Id_Cliente == cliente.PK_Id_Cliente);
        //    nuevo.Estado_Cliente = false;
        //    dc.SubmitChanges();
        //}
        ///// <summary>
        ///// Modificar Cliente
        ///// </summary>
        ///// <param name="cliente"></param>
        ///// <param name="creCliente"></param>
        ///// <param name="persona"></param>
        //public void ModificarCliente(SIGEEA_Cliente cliente, SIGEEA_CreCliente creCliente, SIGEEA_Persona persona)
        //{
        //    DataClasses1DataContext dc = new DataClasses1DataContext();
        //    SIGEEA_Persona pers = dc.SIGEEA_Personas.First(c => c.PK_Id_Persona == cliente.FK_Id_Persona);
        //    SIGEEA_Cliente client = dc.SIGEEA_Clientes.First(c => c.FK_Id_Persona == pers.PK_Id_Persona);
        //    SIGEEA_CreCliente cred = dc.SIGEEA_CreClientes.First(c => c.PK_Id_CreCliente == client.FK_Id_CreCliente);
        //    client.Categoria_Cliente = cliente.Categoria_Cliente;
        //    PersonaMantenimiento nuevoMant = new PersonaMantenimiento();
        //    nuevoMant.ModificarPersona(pers);
        //    cred.Limite_CreCliente = creCliente.Limite_CreCliente;
        //    cred.TieMaximo_CreCliente = creCliente.TieMaximo_CreCliente;
        //    cred.RanPagos_CreCliente = creCliente.RanPagos_CreCliente;
        //    dc.SubmitChanges();
        //}

    }
}
