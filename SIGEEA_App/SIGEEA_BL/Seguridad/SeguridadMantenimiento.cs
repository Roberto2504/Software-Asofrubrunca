using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL.Seguridad
{
    class SeguridadMantenimiento
    {
        //public SIGEEA_Rol ObtenerRol(int pUsuario)
        //{
        //    DataClasses1DataContext dc = new DataClasses1DataContext();

        //    return dc.SIGEEA_Rols.First(c => c.)
        //}
        public List<SIGEEA_SubModulo> ListasSubModulos(int pkModulo)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            
            return (from c in dc.SIGEEA_SubModulos where c.PK_Id_SubModulo == pkModulo select c).ToList();
        }
        public int AutenticaUsuario(string pUsuario, string pClave)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Usuario Usuario = dc.SIGEEA_Usuarios.First(c => c.Nombre_Usuario == pUsuario && c.Clave_Usuario == pClave);
            if (Usuario != null)
                return Usuario.PK_Id_Usuario;
            else return 0;
        }
        //public int CargarUsuario(string pUsuario)
        //{
        //    DataClasses1DataContext dc = new DataClasses1DataContext();
        //    return 
        //}
    }
}
