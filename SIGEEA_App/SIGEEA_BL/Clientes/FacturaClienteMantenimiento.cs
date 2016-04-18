﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIGEEA_BO;
using System.Collections.ObjectModel;

namespace SIGEEA_BL
{
   public class FacturaClienteMantenimiento
    {
        /// <summary>
        /// Registrar Factura)
        /// </summary>
        /// <param name="pFacCliente"></param>
        /// <param name="pListaDetalle"></param>
        
        public void RegistrarFactura(SIGEEA_FacCliente pFacCliente, ObservableCollection<SIGEEA_DetFacCliente> pListaDetalle, SIGEEA_AboCliente pAboCliente)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            
            SIGEEA_FacCliente nuevaFactura = new SIGEEA_FacCliente();
            nuevaFactura.FecEntrega_FacCliente = DateTime.Now;
            nuevaFactura.FecPago_FacCliente = DateTime.Now;
            nuevaFactura.Observaciones_FacCliente = pFacCliente.Observaciones_FacCliente;
            nuevaFactura.FK_Id_Cliente = pFacCliente.FK_Id_Cliente;
            nuevaFactura.Estado_FacCliente = pFacCliente.Estado_FacCliente;
            nuevaFactura.MonTotal_FacCliente = pFacCliente.MonTotal_FacCliente;
            nuevaFactura.MonNeto_FacCliente = pFacCliente.MonNeto_FacCliente;
            nuevaFactura.Descuento_FacCliente = pFacCliente.Descuento_FacCliente;
            nuevaFactura.FK_Id_Moneda = pFacCliente.FK_Id_Moneda;
            nuevaFactura.FK_Id_Empresa = pFacCliente.FK_Id_Empresa;
            nuevaFactura.FK_Id_Empleado = pFacCliente.FK_Id_Empleado;
            dc.SIGEEA_FacClientes.InsertOnSubmit(nuevaFactura);
            dc.SubmitChanges();
            foreach (SIGEEA_DetFacCliente detFacCliente in pListaDetalle)
            {
                SIGEEA_DetFacCliente nuevoDetalle = new SIGEEA_DetFacCliente();
                nuevoDetalle.MonTotal_DetFacCliente = detFacCliente.MonTotal_DetFacCliente;
                nuevoDetalle.MonNeto_DetFacCliente = detFacCliente.MonNeto_DetFacCliente;
                nuevoDetalle.CanProducto_DetFacCliente = detFacCliente.CanProducto_DetFacCliente;
                nuevoDetalle.Descuento_DetFacCliente = detFacCliente.Descuento_DetFacCliente;
                nuevoDetalle.PreUnidad_DetFacCliente = detFacCliente.PreUnidad_DetFacCliente;
                nuevoDetalle.Moneda_DetFacCliente = detFacCliente.Moneda_DetFacCliente;
                nuevoDetalle.FK_Id_FacCliente = nuevaFactura.PK_Id_FacCliente;
                nuevoDetalle.FK_Id_UniMedida = detFacCliente.FK_Id_UniMedida;
                nuevoDetalle.FK_Id_TipProducto = detFacCliente.FK_Id_TipProducto;
                dc.SIGEEA_DetFacClientes.InsertOnSubmit(nuevoDetalle);
                dc.SubmitChanges();
            }
          
            if (pAboCliente != null)
            {
                SIGEEA_AboCliente nuevoAbono = new SIGEEA_AboCliente();
                nuevoAbono.Monto_AboCliente = pAboCliente.Monto_AboCliente;
                nuevoAbono.Metodo_AboCliente = pAboCliente.Metodo_AboCliente;
                nuevoAbono.Numero_AboCliente = pAboCliente.Numero_AboCliente;
                nuevoAbono.Fecha_AboCliente = DateTime.Now;
                nuevoAbono.FK_Id_Moneda = pAboCliente.FK_Id_Moneda;
                nuevoAbono.FK_Id_Empleado = pAboCliente.FK_Id_Empleado;
                nuevoAbono.Estado_AboCliente = pAboCliente.Estado_AboCliente;
                nuevoAbono.FK_Id_Cliente = pAboCliente.FK_Id_Cliente;
                nuevoAbono.FK_Id_FacCliente = nuevaFactura.PK_Id_FacCliente;
                dc.SIGEEA_AboClientes.InsertOnSubmit(nuevoAbono);
            }
            dc.SubmitChanges();
        }
    }
}
