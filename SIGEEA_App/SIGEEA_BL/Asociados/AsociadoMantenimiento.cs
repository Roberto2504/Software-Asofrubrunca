using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;
using SIGEEA_BL.Seguridad;


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
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                PersonaMantenimiento nuevaPersona = new PersonaMantenimiento();
                nuevaPersona.RegistrarPersona(persona);
                asociado.FK_Id_Persona = persona.PK_Id_Persona;
                asociado.Codigo_Asociado = "F";
                asociado.FK_Id_CatAsociado = null;
                dc.SIGEEA_Asociados.InsertOnSubmit(asociado);
                dc.SubmitChanges();

                string codigoAsociado = "F" + asociado.PK_Id_Asociado.ToString() + persona.PriNombre_Persona[0] + persona.PriApellido_Persona[0] + persona.SegApellido_Persona[0];

                dc.SIGEEA_spCodigoAsociado(asociado.PK_Id_Asociado, codigoAsociado);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error:" + ex.Message);
            }
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
                if (cuota.Saldo_Cuota_Asociado <= 0)//Si el asociado ya terminó de cancelar la cuota
                {
                    SIGEEA_Cuota cuotaPrincipal = dc.SIGEEA_Cuotas.First(c => c.PK_Id_Cuota == cuota.FK_Id_Cuota);

                    cuota.Estado_Cuota_Asociado = true;
                    dc.SubmitChanges();
                    ActualizarCategoriaCuota(cuotaPrincipal, cuota.FK_Id_Asociado);
                }
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza la categoría del asociado con respecto a las cuotas
        /// </summary>
        /// <param name="pCuota"></param>
        /// <param name="pAsociado"></param>
        private void ActualizarCategoriaCuota(SIGEEA_Cuota pCuota, int pAsociado)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                int calificacion;

                SIGEEA_Asociado asociado = dc.SIGEEA_Asociados.First(c => c.PK_Id_Asociado == pAsociado);
                List<SIGEEA_spObtenerInfoCategoriaAsocCuotasResult> lista = dc.SIGEEA_spObtenerInfoCategoriaAsocCuotas(pAsociado).ToList();
                double calificacionActual = dc.SIGEEA_CatAsociados.First(c => c.PK_Id_CatAsociado == asociado.FK_Id_CatAsociado).CuotasProm_CatAsociado;
                if (DateTime.Now > pCuota.FecFin_Cuota) calificacion = 1; //Si ya se pasó la fecha de pago
                else if (DateTime.Now == pCuota.FecFin_Cuota) calificacion = 3; //Si hoy es el día de pago
                else calificacion = 5; //Si va a pagar con antelación
                int cantidadPagos = lista.Count();
                double calificacionNuevaTotal = ((cantidadPagos - 1) * calificacionActual) + calificacion;
                double calificacionNuevaFinal = calificacionNuevaTotal / cantidadPagos;

                dc.SIGEEA_spActualizaCategoriaCuotas(asociado.FK_Id_CatAsociado, calificacionNuevaFinal);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {

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
                pFactura.CanNeta_FacAsociado = -1;
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
                    d.CanNeta_DetFacAsociado = -1;
                    d.Cancelado_DetFacAsociado = false;
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
        public void CompletarEntrega(int pkDetalle, double CantidadNeta, int unidadMedida, int pProducto, bool pEstado)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                SIGEEA_DetFacAsociado detalle = dc.SIGEEA_DetFacAsociados.First(c => c.PK_Id_DetFacAsociado == pkDetalle);
                ProductoMantenimiento producto = new ProductoMantenimiento();
                detalle.CanNeta_DetFacAsociado = CantidadNeta;
                detalle.CanTotal_DetFacAsociado = detalle.CanTotal_DetFacAsociado;
                detalle.Cancelado_DetFacAsociado = false;
                detalle.FK_Id_FacAsociado = detalle.FK_Id_FacAsociado;
                detalle.FK_Id_Lote = detalle.FK_Id_Lote;
                detalle.Saldo_DetFacAsociado = CantidadNeta * (detalle.Mercado_DetFacAsociado == 1 ? dc.SIGEEA_PreProCompras.First(c => c.PK_Id_PreProCompra == detalle.FK_Id_PreProCompra).PreNacional_PreProCompra : dc.SIGEEA_PreProCompras.First(c => c.PK_Id_PreProCompra == detalle.FK_Id_PreProCompra).PreExtranjero_PreProCompra);
                detalle.FK_Id_PreProCompra = detalle.FK_Id_PreProCompra;
                detalle.Mercado_DetFacAsociado = detalle.Mercado_DetFacAsociado;
                dc.SubmitChanges();

                if (pEstado == true) producto.IncrementarInventario(unidadMedida, pProducto, CantidadNeta);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Actualiza la factura con respecto a su cantidad neta
        /// </summary>
        /// <param name="pFactura"></param>
        public void CantidadNetaFactura(int pFactura)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_FacAsociado factura = dc.SIGEEA_FacAsociados.First(c => c.PK_Id_FacAsociado == pFactura);
            List<SIGEEA_spObtenerDetalleFacturaAsociadoResult> listaDetalles = dc.SIGEEA_spObtenerDetalleFacturaAsociado(factura.PK_Id_FacAsociado).ToList();
            double cantidadNeta = 0;

            foreach (SIGEEA_spObtenerDetalleFacturaAsociadoResult f in listaDetalles)
            {
                if (f.CanNeta_DetFacAsociado == -1) continue;
                cantidadNeta += (double)f.CanNeta_DetFacAsociado;
            }
            factura.CanNeta_FacAsociado = cantidadNeta;
            factura.CanTotal_FacAsociado = factura.CanTotal_FacAsociado;
            factura.Estado_FacAsociado = factura.Estado_FacAsociado;
            factura.FecEntrega_FacAsociado = factura.FecEntrega_FacAsociado;
            factura.FecPago_FacAsociado = factura.FecPago_FacAsociado;
            factura.FK_Id_Asociado = factura.FK_Id_Asociado;
            factura.Incompleta_FacAsociado = factura.Incompleta_FacAsociado;
            factura.Observaciones_FacAsociado = factura.Observaciones_FacAsociado;
            dc.SubmitChanges();

        }

        /// <summary>
        /// Obtiene la cantidad de producto neto pendiente de pago la factura con respecto a su cantidad neta
        /// </summary>
        /// <param name="pFactura"></param>
        public int SaldoFactura(int pFactura)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_FacAsociado factura = dc.SIGEEA_FacAsociados.First(c => c.PK_Id_FacAsociado == pFactura);
            List<SIGEEA_spObtenerDetalleFacturaAsociadoResult> listaDetalles = dc.SIGEEA_spObtenerDetalleFacturaAsociado(factura.PK_Id_FacAsociado).ToList();
            int cantidadNeta = 0;

            foreach (SIGEEA_spObtenerDetalleFacturaAsociadoResult f in listaDetalles)
            {
                if (f.CanNeta_DetFacAsociado == -1 || f.Cancelado_DetFacAsociado == true) continue;
                cantidadNeta += (int)f.CanNeta_DetFacAsociado;
            }
            return cantidadNeta;
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
                if (d.CanNeta_DetFacAsociado < 0)
                {
                    validador = false; //Existe al menos un detalle incompleto
                    break;
                }
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
                factura.Incompleta_FacAsociado = false;
                factura.Observaciones_FacAsociado = factura.Observaciones_FacAsociado;
                dc.SubmitChanges();
            }
        }


        /// <summary>
        /// Cancela las facturas 
        /// </summary>
        /// <param name="pDetalles"></param>
        /// <returns></returns>
        public bool CancelaFacturaAsociado(List<int> pDetalles, List<double> pMontos, int pMetodoPago = 0, string pNumChequeTransferencia = null, double pTotal = 0)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                if (pDetalles.Count > 0)
                {
                    int indice = 0;
                    int pkFactura = 0;
                    foreach (int i in pDetalles)
                    {
                        SIGEEA_DetFacAsociado detalle = dc.SIGEEA_DetFacAsociados.First(c => c.PK_Id_DetFacAsociado == i);
                        pkFactura = detalle.FK_Id_FacAsociado;
                        if (pMontos.ElementAt(indice) > detalle.Saldo_DetFacAsociado) return false;
                        else if (pMontos.ElementAt(indice) < detalle.Saldo_DetFacAsociado) detalle.Saldo_DetFacAsociado = detalle.Saldo_DetFacAsociado - pMontos.ElementAt(indice);
                        else detalle.Saldo_DetFacAsociado = 0;
                        detalle.PK_Id_DetFacAsociado = detalle.PK_Id_DetFacAsociado;
                        detalle.Cancelado_DetFacAsociado = detalle.Saldo_DetFacAsociado > 0 ? false : true;
                        detalle.CanNeta_DetFacAsociado = detalle.CanNeta_DetFacAsociado;
                        detalle.CanTotal_DetFacAsociado = detalle.CanTotal_DetFacAsociado;
                        detalle.FK_Id_FacAsociado = detalle.FK_Id_FacAsociado;
                        detalle.FK_Id_Lote = detalle.FK_Id_Lote;
                        detalle.FK_Id_PreProCompra = detalle.FK_Id_PreProCompra;
                        detalle.Mercado_DetFacAsociado = detalle.Mercado_DetFacAsociado;
                        dc.SubmitChanges();
                        indice++;
                    }
                    RevisaFacurasCanceladas(dc.SIGEEA_FacAsociados.First(c => c.PK_Id_FacAsociado == (dc.SIGEEA_DetFacAsociados.First(d => d.PK_Id_DetFacAsociado == pDetalles.First()).FK_Id_FacAsociado)).PK_Id_FacAsociado);
                    CrearBitacoraPago(pDetalles, pMetodoPago, UsuarioGlobal.InfoUsuario.PK_Id_Usuario, DateTime.Now, pNumChequeTransferencia, pTotal);
                }
                return true;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Crea la bitácora de pago
        /// </summary>
        /// <param name="pDetalles"></param>
        /// <param name="pMetodoPago"></param>
        /// <param name="pUsuario"></param>
        /// <param name="pFecha"></param>
        /// <param name="pChqRef"></param>
        /// <param name="pTotal"></param>
        private void CrearBitacoraPago(List<int> pDetalles, int pMetodoPago, int pUsuario, DateTime pFecha, string pChqRef, double pTotal)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_BitPago bitacora = new SIGEEA_BitPago();
            bitacora.Metodo_BitPagos = pMetodoPago;
            bitacora.FK_Id_Usuario = pUsuario;
            bitacora.Fecha_BitPagos = pFecha;
            bitacora.ChqRef_BitPagos = pChqRef;
            bitacora.Total_BitPagos = pTotal;
            dc.SIGEEA_BitPagos.InsertOnSubmit(bitacora);
            dc.SubmitChanges();
            foreach (int i in pDetalles)
            {
                SIGEEA_BitDetPago detalle = new SIGEEA_BitDetPago();
                detalle.FK_BitPagos = bitacora.PK_Id_BitPagos;
                detalle.FK_DetFacAsociado = i;
                dc.SIGEEA_BitDetPagos.InsertOnSubmit(detalle);
            }
            dc.SubmitChanges();
        }

        /// <summary>
        /// Determina si a una factura ya se le puede cambiar su estado de cancelado a partir de sus detalles
        /// </summary>
        /// <param name="pFactura"></param>
        private void RevisaFacurasCanceladas(int pFactura)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<SIGEEA_spObtenerDetalleFacturaAsociadoResult> lista = dc.SIGEEA_spObtenerDetalleFacturaAsociado(pFactura).ToList();
            bool validador = true;
            foreach (SIGEEA_spObtenerDetalleFacturaAsociadoResult d in lista)
            {
                if (d.Cancelado_DetFacAsociado == false)
                {
                    validador = false;
                    break;
                }
            }
            if (validador == true)
            {
                SIGEEA_FacAsociado factura = dc.SIGEEA_FacAsociados.First(c => c.PK_Id_FacAsociado == pFactura);
                factura.CanNeta_FacAsociado = factura.CanNeta_FacAsociado;
                factura.CanTotal_FacAsociado = factura.CanTotal_FacAsociado;
                factura.Estado_FacAsociado = false;
                factura.FecEntrega_FacAsociado = factura.FecEntrega_FacAsociado;
                factura.FecPago_FacAsociado = DateTime.Now;
                factura.FK_Id_Asociado = factura.FK_Id_Asociado;
                factura.Incompleta_FacAsociado = factura.Incompleta_FacAsociado;
                factura.Observaciones_FacAsociado = factura.Observaciones_FacAsociado;
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Registra una nueva asamblea de asociados
        /// </summary>
        /// <param name="pAsamblea"></param>
        /// <returns></returns>
        public bool RegistraAsamblea(SIGEEA_Asamblea pAsamblea)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                SIGEEA_Asamblea nuevaAsamblea = new SIGEEA_Asamblea();
                nuevaAsamblea.Fecha_Asamblea = pAsamblea.Fecha_Asamblea;
                nuevaAsamblea.NumActa_Asamblea = pAsamblea.NumActa_Asamblea;
                nuevaAsamblea.Observaciones_Asamblea = pAsamblea.Observaciones_Asamblea;
                nuevaAsamblea.Tipo_Asamblea = pAsamblea.Tipo_Asamblea;
                dc.SIGEEA_Asambleas.InsertOnSubmit(nuevaAsamblea);
                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza el estado de las personas que asistieron o no a una asamblea en particular a partir de una lista
        /// </summary>
        /// <param name="pLista"></param>
        /// <returns></returns>
        public bool ActualizarDetalleAsamblea(List<SIGEEA_spObtenerListadoAsistenciaResult> pLista)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                foreach (SIGEEA_spObtenerListadoAsistenciaResult a in pLista)
                {
                    SIGEEA_AsiAsamblea asamblea = dc.SIGEEA_AsiAsambleas.First(c => c.PK_Id_AsiAsamblea == a.PK_Id_AsiAsamblea);
                    asamblea.FK_Id_Asamblea = asamblea.FK_Id_Asamblea;
                    asamblea.FK_Id_Asociado = asamblea.FK_Id_Asociado;
                    asamblea.PK_Id_AsiAsamblea = asamblea.PK_Id_AsiAsamblea;
                    asamblea.Estado_AsiAsamblea = a.Estado_AsiAsamblea;
                    dc.SubmitChanges();
                    ActualizarCategoriaAsociacion(asamblea.FK_Id_Asociado, asamblea.Estado_AsiAsamblea);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza la categoría del asociado que se basa en las asambleas
        /// </summary>
        /// <param name="pAsociado"></param>
        /// <param name="pEstado"></param>
        private void ActualizarCategoriaAsociacion(int pAsociado, int pEstado)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            int calificacion = 1;

            SIGEEA_Asociado asociado = dc.SIGEEA_Asociados.First(c => c.PK_Id_Asociado == pAsociado);
            /*List<SIGEEA_spObtenerInfoCategoriaAsocAsambleasResult> listaCantidad = dc.SIGEEA_spObtenerInfoCategoriaAsocAsambleas(pAsociado).ToList();
            int cantidad = listaCantidad.Count();*/
            int cantidad = (int)dc.SIGEEA_spObtenerInfoCategoriaAsocAsambleas(pAsociado).First().Cantidad;
            double calificacionActual = dc.SIGEEA_CatAsociados.First(c => c.PK_Id_CatAsociado == asociado.FK_Id_CatAsociado).AsambleasProm_CatAsociado;

            if (pEstado == 3) calificacion = 1; //Ausencia injustificada
            else if (pEstado == 2) calificacion = 3; //Ausencia justificada
            else if (pEstado == 1) calificacion = 5; //Asistió

            double calificacionNuevaTotal = ((cantidad) * calificacionActual) + calificacion;
            double calificacionNuevaFinal = calificacionNuevaTotal / (cantidad + 1);

            dc.SIGEEA_spActualizaCategoriaAsambleas(asociado.FK_Id_CatAsociado, calificacionNuevaFinal);
            dc.SubmitChanges();
        }

        /// <summary>
        /// Obtiene el siguiente número de factura de entrega de producto 
        /// </summary>
        /// <returns></returns>
        public int ObtenerNumeroFacturaEntrega()
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                return Convert.ToInt32(dc.SIGEEA_spUltimaFacturaEntregaProducto().First().Numero_FacAsociado) + 1;
            }
            catch
            {
                return 0;
            }
        }

        public string AnularEntregaProducto(int pkFactura)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                dc.SIGEEA_spAnularEntregaProducto(pkFactura);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message + " Comuníquese con el administrador del sistema.";
            }
        }

        public SIGEEA_spObtenerAsociadoResult obtenerAsociadoPorID(string CedulaCodigo)
        {
            try
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                return dc.SIGEEA_spObtenerAsociado(CedulaCodigo).First();
            }
            catch (Exception ex)
            {
                SIGEEA_spObtenerAsociadoResult error = new SIGEEA_spObtenerAsociadoResult();
                error.PriNombre_Persona = ex.Message;
                return error;
            }
        }
    }
}