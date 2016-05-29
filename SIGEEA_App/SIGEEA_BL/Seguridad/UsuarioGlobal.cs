using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL.Seguridad
{
    public static class UsuarioGlobal
    {
        public static List<SIGEEA_spListarPermisosResult> Permisos = new List<SIGEEA_spListarPermisosResult>();
        public static List<SIGEEA_spListarSubModulosResult> SubModulos = new List<SIGEEA_spListarSubModulosResult>();
        public static List<SIGEEA_spListarModulosResult> Modulos = new List<SIGEEA_spListarModulosResult>();
        public static SIGEEA_spInfoUsuarioResult InfoUsuario;

    }
}
