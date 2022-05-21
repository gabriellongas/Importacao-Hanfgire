using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Hangfire.DAO
{
    public static class ConexaoSQL
    {
        public static SqlConnection getConnection()
        {
            string strConexao = "data source=DESKTOP-PEUQII0\\SQLEXPRESS;database=db_sme;Trusted_Connection=True";
            SqlConnection sqlConnection = new SqlConnection(strConexao);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
