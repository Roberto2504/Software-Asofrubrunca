using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL.Monedas
{
    public class MonedaMantenimiento
    {
        public List<string> SimboloMoneda()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<string> Simbolos = (from c in dc.SIGEEA_Monedas select c.Simbolo_Moneda).ToList();
            return Simbolos;
        }
    }
}
