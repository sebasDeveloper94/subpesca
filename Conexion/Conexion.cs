using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
namespace subpesca.Conexion
{
    public class Conexion
    {
        private string cadena = "Data Source=.;Initial Catalog=SubPesca;Integrated Security=True";
        SqlConnection con;

        public Conexion()
        {

        }

        public SqlConnection Conectar() {

            try
            {
                con = new SqlConnection(cadena);
                con.Open();

                return con;
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return con;

        }
    }
}
