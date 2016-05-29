using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEEA_BO;

namespace SIGEEA_BL.Seguridad
{
    public class SeguridadMantenimiento
    {
        public SIGEEA_Rol ObtenerRol(int pidRol)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_Rols.FirstOrDefault(c => c.PK_Id_Rol == pidRol);
        }

        public List<SIGEEA_spListarSubModulosResult> ListarSubModulos(int pkPermiso)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spListarSubModulos(pkPermiso).ToList();
        }
        public SIGEEA_spInfoUsuarioResult InfoUsuario(int pkUsuario)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spInfoUsuario(pkUsuario).FirstOrDefault();
        }
        public List<SIGEEA_spListarModulosResult> ListasModulos(int fkModulo)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spListarModulos(fkModulo).ToList();
        }
        public List<string> ObtenerSubModulos(int pfkModulo)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            List<string> Lista = (from c in dc.SIGEEA_SubModulos where c.FK_Id_Modulo == pfkModulo select c.Nombre_SubModulo).ToList();
            return Lista;
        }
        public List<SIGEEA_spListarPermisosResult> ListarPermisos(int rol)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_spListarPermisos(rol).ToList();
        }
        public int AutenticaUsuario(string pUsuario, string pClave)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            SIGEEA_Usuario Usuario = dc.SIGEEA_Usuarios.FirstOrDefault(c => c.Nombre_Usuario == pUsuario && c.Clave_Usuario == pClave);
            if (Usuario != null)
                return Usuario.PK_Id_Usuario;
            else return 0;
        }
        public SIGEEA_Usuario Usuario(int pIdUsuario)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_Usuarios.First(c => c.PK_Id_Usuario == pIdUsuario);

        }
        public SIGEEA_Empleado Empleado(int pIdEmpleado)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            return dc.SIGEEA_Empleados.First(c => c.PK_Id_Empleado == pIdEmpleado);

        }

    }
}
