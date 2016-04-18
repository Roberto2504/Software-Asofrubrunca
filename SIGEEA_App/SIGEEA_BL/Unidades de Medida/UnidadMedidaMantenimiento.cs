using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL
{
    public class UnidadMedidaMantenimiento
    {
        public List<string> listarUnidades ()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<string> unidadesDeMedida = new List<string>();
            unidadesDeMedida = (from c in dc.SIGEEA_UniMedidas select c.Nombre_UniMedida).ToList();
            return unidadesDeMedida;
        }
        public List<int> PkUniMedida(string nombre)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<int> pPkUniMedida = (from c in dc.SIGEEA_UniMedidas where c.Nombre_UniMedida == nombre select c.PK_Id_UniMedida).ToList();
            return pPkUniMedida;
        }
    }
}
