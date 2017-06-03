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
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            List<string> unidadesDeMedida = new List<string>();
            unidadesDeMedida = (from c in dc.SIGEEA_UniMedidas select c.Nombre_UniMedida).ToList();
            return unidadesDeMedida;
        }
        public List<int> PkUniMedida(string nombre)
        {
            SIGEEA_DiagramaDataContext dc = new SIGEEA_DiagramaDataContext();
            List<int> pPkUniMedida = (from c in dc.SIGEEA_UniMedidas where c.Nombre_UniMedida == nombre select c.PK_Id_UniMedida).ToList();
            return pPkUniMedida;
        }
    }
}
