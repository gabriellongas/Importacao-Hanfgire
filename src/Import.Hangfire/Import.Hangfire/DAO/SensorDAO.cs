using System.Data.SqlClient;
using Import.Hangfire.Models;

namespace Import.Hangfire.DAO
{
    public class SensorDAO
    {
        public static SqlParameter[] CriaParametros(SensorModel model)
        {
            SqlParameter[] parametros = new SqlParameter[]{
                new SqlParameter("idSensor", model.idSensor),
                new SqlParameter("Nivel", model.Nivel),
                new SqlParameter("DataHora", model.DataHora)
            };
            
            return parametros;
        }

        public static void InsertSensor(SensorModel model)
        {
            HelperDAO.ExecutaProc("spInsert_Registros", CriaParametros(model));
        }
    }
}
