using System.Data;
using System.Data.SqlClient;
using Import.Hangfire.DAO;

namespace Import.Hangfire.DAO
{
    public static class HelperDAO
    {
        public static void ExecutaProc(string nomeProc, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoSQL.getConnection())
            {
                using (SqlCommand comando = new SqlCommand(nomeProc, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }
    }
}
