using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL
{
    public class AsociadoMantenimiento
    {
        /// <summary>
        /// Registrar asociado (se registra primero la persona y luego el asociado)
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="asociado"></param>
        public void RegistrarAsociado(SIGEEA_Persona persona, SIGEEA_Asociado asociado)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            PersonaMantenimiento nuevaPersona = new PersonaMantenimiento();
            nuevaPersona.RegistrarPersona(persona);
            asociado.FK_Id_Persona = persona.PK_Id_Persona;
            asociado.Codigo_Asociado = "F";
            asociado.FK_Id_CatAsociado = 5;
            dc.SIGEEA_Asociados.InsertOnSubmit(asociado);
            dc.SubmitChanges();

            SIGEEA_Asociado modificarAsociado = new SIGEEA_Asociado();
            modificarAsociado = dc.SIGEEA_Asociados.First(c => c.PK_Id_Asociado == asociado.PK_Id_Asociado);
            modificarAsociado.Codigo_Asociado = "F" + modificarAsociado.PK_Id_Asociado.ToString() + persona.PriNombre_Persona[0] + persona.PriApellido_Persona[0] + persona.SegApellido_Persona[0];
            dc.SubmitChanges();
        }

        /// <summary>
        /// Eliminar asociado (cambia de estado).
        /// </summary>
        /// <param name="asociado"></param>

        public void EliminarAsociado(SIGEEA_Asociado asociado)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Asociado asoc = dc.SIGEEA_Asociados.First(c => c.PK_Id_Asociado == asociado.PK_Id_Asociado);
            asoc.Estado_Asociado = false;
            dc.SubmitChanges();
        }

        /// <summary>
        /// Hace la búsqueda del asociado que se desea ubicar
        /// </summary>
        /// <param name="codigo_cedula"></param>
        /// <returns></returns>
        public SIGEEA_spObtenerAsociadoResult AutenticaAsociado(string codigo_cedula)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_spObtenerAsociadoResult asociado = dc.SIGEEA_spObtenerAsociado(codigo_cedula).FirstOrDefault();
            return asociado;
        }
        /// <summary>
        /// Determina si el asociado tiene una dirección ya registrada
        /// </summary>
        /// <param name="pCedula"></param>
        /// <param name="pCodigo"></param>
        /// <returns></returns>
        public bool DireccionRegistradaAsociado(string pCedula, string pCodigo)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            SIGEEA_spObtenerDireccionAsociadoResult direccion = new SIGEEA_spObtenerDireccionAsociadoResult();

            if (pCedula != null && pCodigo == null)
            {
                direccion = dc.SIGEEA_spObtenerDireccionAsociado(pCedula, null).FirstOrDefault();
                if (direccion == null) return false;
                else return true;
            }
            else
            {
                direccion = dc.SIGEEA_spObtenerDireccionAsociado(null, pCodigo).FirstOrDefault();
                if (direccion == null) return false;
                else return true;
            }
        }

        /// <summary>
        /// Obtiene la dirección del asociado
        /// </summary>
        /// <param name="pCedula"></param>
        /// <param name="pCodigo"></param>
        /// <returns></returns>
        public SIGEEA_spObtenerDireccionAsociadoResult ObtenerDireccionAsociado(string pCedula, string pCodigo)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            if (pCedula != null && pCodigo == null)
            {
                return dc.SIGEEA_spObtenerDireccionAsociado(pCedula, null).First();
            }
            else
            {
                return dc.SIGEEA_spObtenerDireccionAsociado(null, pCodigo).First();
            }
        }

        /// <summary>
        /// Lista los asociados recibiendo de parámetro el nombre, apellido, cédula o código 
        /// </summary>
        /// <param name="pCedNombreCod"></param>
        /// <returns></returns>
        public List<SIGEEA_spListarAsociadoResult> ListarAsociados(string pCedNombreCod)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<SIGEEA_spListarAsociadoResult> lista = dc.SIGEEA_spListarAsociado(pCedNombreCod).ToList();
            return lista;
        }

        /// <summary>
        /// Lista los familiares de un asociado en específico
        /// </summary>
        /// <param name="pCedula"></param>
        /// <returns></returns>
        public List<SIGEEA_spListarFamiliaresResult> ListarFamiliares(string pCedula)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<SIGEEA_spListarFamiliaresResult> lista = dc.SIGEEA_spListarFamiliares(pCedula).ToList();
            return lista;
        }

        /// <summary>
        /// Agrega y edita familiares de los asociados
        /// </summary>
        /// <param name="pAsociado"></param>
        /// <param name="pLista"></param>
        public void AgregaEditaFamiliares(int pAsociado, List<SIGEEA_Familiar> pLista)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                foreach (SIGEEA_Familiar f in pLista)
                {
                    if (f.PK_Id_Familiar != -1) //Es edición
                    {
                        SIGEEA_Familiar familiar = dc.SIGEEA_Familiars.First(c => c.PK_Id_Familiar == f.PK_Id_Familiar);
                        familiar.Nombre_Familiar = f.Nombre_Familiar;
                        familiar.Escolaridad_Familiar = f.Escolaridad_Familiar;
                        familiar.DesEstudios_Familiar = f.DesEstudios_Familiar;
                        dc.SubmitChanges();
                    }
                    else //Es una inserción
                    {
                        f.FK_Id_Asociado = pAsociado;
                        dc.SIGEEA_Familiars.InsertOnSubmit(f);
                        dc.SubmitChanges();
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }

        /// <summary>
        /// Registra una nueva cuota a pagar por el asociado, automáticamente se ejecuta
        /// un trigger en la base de datos que le asigna de manera automática a cada asociado
        /// activo el pago pendiente de la misma.
        /// </summary>
        /// <param name="pCuota"></param>
        public void RegistrarCuota(SIGEEA_Cuota pCuota)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            dc.SIGEEA_Cuotas.InsertOnSubmit(pCuota);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Edita la información de una cuota existente
        /// </summary>
        /// <param name="pCuota"></param>
        public void EditarCuota(SIGEEA_Cuota pCuota)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Cuota cuota = dc.SIGEEA_Cuotas.First(c => c.PK_Id_Cuota == pCuota.PK_Id_Cuota);
            cuota.Monto_Cuota = pCuota.Monto_Cuota;
            cuota.FecFin_Cuota = pCuota.FecFin_Cuota;
            cuota.FecInicio_Cuota = pCuota.FecInicio_Cuota;
            cuota.FK_Id_Moneda = pCuota.FK_Id_Moneda;
            cuota.Nombre_Cuota = pCuota.Nombre_Cuota;
            dc.SubmitChanges();
        }

        /// <summary>
        /// Lista las cuotas que se encuentran actualmente activas
        /// </summary>
        /// <returns></returns>
        public List<SIGEEA_spObtenerCuotasResult> ListarCuotasActivas()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spObtenerCuotas().ToList();
        }

        /// <summary>
        /// Lista los asociados deudores de las cuotas
        /// </summary>
        /// <param name="pCuota"></param>
        /// <returns></returns>
        public List<SIGEEA_spObtenerDeudoresCuotasResult> ListarDeudoresCuotas(int pCuota)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spObtenerDeudoresCuotas(pCuota).ToList();
        }

        /// <summary>
        /// Se realiza el pago de una cuota de asociado
        /// </summary>
        /// <param name="pCuotaAsociado"></param>
        /// <param name="pMonto"></param>
        /// <returns></returns>
        public bool RealizarPagoCuota(int pCuotaAsociado, double pMonto)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                SIGEEA_Cuota_Asociado cuota = dc.SIGEEA_Cuota_Asociados.First(c => c.PK_Id_Cuota_Asociado == pCuotaAsociado);
                double saldo = dc.SIGEEA_Cuota_Asociados.First(c => c.PK_Id_Cuota_Asociado == pCuotaAsociado).Saldo_Cuota_Asociado;
                cuota.Saldo_Cuota_Asociado = saldo - pMonto;
                if (cuota.Saldo_Cuota_Asociado <= 0)
                    cuota.Estado_Cuota_Asociado = true;
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Genera la factura de la cuota de los asociados
        /// </summary>
        /// <param name="pCuotaAsociado"></param>
        /// <param name="pMonto"></param>
        /// <param name="pSaldoAnterior"></param>
        /// <returns></returns>
        public SIGEEA_spGenerarFacturaCuotaResult GenerarFacturaCuota(int pCuotaAsociado, double pMonto, double pSaldoAnterior)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spGenerarFacturaCuota(pCuotaAsociado, pMonto, pSaldoAnterior).First();
        }

        /// <summary>
        /// Registra la entrega del producto, a partir de los datos de una factura y una lista de detalles.
        /// </summary>
        /// <param name="pFactura"></param>
        /// <param name="pDetalles"></param>
        public void RegistraEntrega(SIGEEA_FacAsociado pFactura, List<SIGEEA_DetFacAsociado> pDetalles)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();

                pFactura.FecEntrega_FacAsociado = DateTime.Now;
                pFactura.CanNeta_FacAsociado = 0;
                double total = 0;
                foreach (SIGEEA_DetFacAsociado d in pDetalles) total += d.CanTotal_DetFacAsociado;
                pFactura.CanTotal_FacAsociado = total;
                pFactura.Incompleta_FacAsociado = true;
                pFactura.CanNeta_FacAsociado = -1;
                dc.SIGEEA_FacAsociados.InsertOnSubmit(pFactura);
                dc.SubmitChanges();

                foreach (SIGEEA_DetFacAsociado d in pDetalles)
                {
                    d.FK_Id_PreProCompra = dc.SIGEEA_spObtenerPrecioCompra(d.FK_Id_PreProCompra).First().PK_Id_PreProCompra;
                    d.FK_Id_FacAsociado = pFactura.PK_Id_FacAsociado;
                    d.CanNeta_DetFacAsociado = 0;
                    dc.SIGEEA_DetFacAsociados.InsertOnSubmit(d);
                }
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al registrar: " + ex.Message);
            }

        }

        /// <summary>
        /// Completa la entrega de un detalle en la factura
        /// </summary>
        /// <param name="pkDetalle"></param>
        /// <param name="CantidadNeta"></param>
        public void CompletarEntrega(int pkDetalle, double CantidadNeta)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                SIGEEA_DetFacAsociado detalle = dc.SIGEEA_DetFacAsociados.First(c => c.PK_Id_DetFacAsociado == pkDetalle);
                detalle.CanNeta_DetFacAsociado = CantidadNeta;
                detalle.CanTotal_DetFacAsociado = detalle.CanTotal_DetFacAsociado;
                detalle.FK_Id_FacAsociado = detalle.FK_Id_FacAsociado;
                detalle.FK_Id_Lote = detalle.FK_Id_Lote;
                detalle.FK_Id_PreProCompra = detalle.FK_Id_PreProCompra;
                detalle.Mercado_DetFacAsociado = detalle.Mercado_DetFacAsociado;
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Revisa y cambia el estado de las facturas, para que cuando se listen las facturas, puedan ser editables.
        /// </summary>
        /// <param name="pkFactura"></param>
        public void RevisaFactura(int pkFactura)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<SIGEEA_spObtenerDetalleFacturaAsociadoResult> listaDetalles = dc.SIGEEA_spObtenerDetalleFacturaAsociado(pkFactura).ToList();
            bool validador = true;

            foreach (SIGEEA_spObtenerDetalleFacturaAsociadoResult d in listaDetalles)
            {
                if (d.CanNeta_DetFacAsociado < 0) validador = false; //Existe al menos un detalle incompleto
            }

            if (validador == true)
            {
                SIGEEA_FacAsociado factura = dc.SIGEEA_FacAsociados.First(c => c.PK_Id_FacAsociado == pkFactura);
                factura.CanNeta_FacAsociado = factura.CanNeta_FacAsociado;
                factura.CanTotal_FacAsociado = factura.CanTotal_FacAsociado;
                factura.Estado_FacAsociado = factura.Estado_FacAsociado;
                factura.FecEntrega_FacAsociado = factura.FecEntrega_FacAsociado;
                factura.FecPago_FacAsociado = factura.FecPago_FacAsociado;
                factura.FK_Id_Asociado = factura.FK_Id_Asociado;
                factura.FK_Id_UniMedida = factura.FK_Id_UniMedida;
                factura.Incompleta_FacAsociado = false;
                factura.Observaciones_FacAsociado = factura.Observaciones_FacAsociado;
                dc.SubmitChanges();
            }
        }
    }
}