using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL
{
    public class MonedaMantenimiento
    {
        public List<string> SimboloMoneda()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<string> Simbolos = (from c in dc.SIGEEA_Monedas select c.Simbolo_Moneda).ToList();
            return Simbolos;
        }
        public List<string> ListarMonedas()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<string> Monedas = (from c in dc.SIGEEA_Monedas select c.Nombre_Moneda).ToList();
            return Monedas;
        }

        public List<int> PkMonedas(string nombre)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<int> pkMonedas = (from c in dc.SIGEEA_Monedas where c.Nombre_Moneda == nombre select c.PK_Id_Moneda).ToList();
            return pkMonedas;
        }
        public double PrecioVenta(string id)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();     
            return dc.SIGEEA_spObtenerPrecioVentaMoneda(id).FirstOrDefault().PreVenta_Moneda;
        }

    }
}
