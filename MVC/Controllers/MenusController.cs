using Dapper;
using subpesca.Conexion;
using subpesca.MVC.Models;

namespace subpesca.MVC.Controllers
{
    public class MenusController
    {
        Conexion.Conexion con = null;
        public List<Menus> GetMenus(int? menuId = null) {

            List<Menus> menus = new List<Menus>();

            try
            {
                con = new Conexion.Conexion();
                using (var sql = con.Conectar())
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("MENU_ID", menuId);
                    var lista = sql.Query<Menus>("SEL_MENUS", parametros, commandType: System.Data.CommandType.StoredProcedure);
                    menus = lista.ToList();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert:" + ex.Message);

            }
            return menus;
        }

        public bool InsertMenus(Menus menu)
        {

            try
            {
                con = new Conexion.Conexion();
                List<Menus> menus = new List<Menus>();

                using (var sql = con.Conectar())
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("mnu_nombre", menu.mnu_nombre);
                    parametros.Add("mnu_ruta", menu.mnu_ruta);
                    parametros.Add("mnu_nombre", menu.mnu_visible);
                    parametros.Add("mnu_habilitado", menu.mnu_habilitado);
                    var lista = sql.Execute("INS_MENUS", parametros, commandType: System.Data.CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert:" + ex.Message);
                return false;
            }
        }

        public bool UpdateMenus(Menus menu)
        {
            try
            {
                con = new Conexion.Conexion();
                List<Menus> menus = new List<Menus>();

                using (var sql = con.Conectar())
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("mnu_nombre", menu.mnu_nombre);
                    parametros.Add("mnu_ruta", menu.mnu_ruta);
                    parametros.Add("mnu_nombre", menu.mnu_visible);
                    parametros.Add("mnu_habilitado", menu.mnu_habilitado);
                    var lista = sql.Execute("UPD_MENUS", parametros, commandType: System.Data.CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert:" + ex.Message);
                return false;
            }
        }

        public bool DeleteMenus(int menuId = 0)
        {
            try
            {
                con = new Conexion.Conexion();
                List<Menus> menus = new List<Menus>();

                using (var sql = con.Conectar())
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("MENU_ID", menuId);
                    var lista = sql.Execute("DEL_MENUS", parametros, commandType: System.Data.CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert:" + ex.Message);
                return false;
            }
        }

    }
}
