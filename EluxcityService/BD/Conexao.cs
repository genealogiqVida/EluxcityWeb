using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace EluxcityWeb.BD
{
    public class Conexao
    {


        private SqlConnection con = null;
        private string stringConnection = "";

        protected SqlConnection getConexao()
        {

            if (con == null)
            {


                string ConnectionFormat = "Data Source=aayu1i6nz8t6qh.cquw2frjvx7u.us-west-2.rds.amazonaws.com;Initial Catalog=eluxcity;User ID=administrador;Password=eluxcity123";

                con = new SqlConnection(ConnectionFormat);


                    //stringConnection = ConfigurationManager.ConnectionStrings["eluxcity"].ConnectionString;
               // con = new SqlConnection(stringConnection);
            }

            return con;
        }

    }
}
