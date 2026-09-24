using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBBDD.DBConn
{
    public sealed class ConnJobs
    {
        public SqlConnection Conexion { get; }
        public ConnJobs()
        {
            var CadenaConexion = new SqlConnectionStringBuilder
            {
                DataSource = "46.183.118.102,54321",
                InitialCatalog = "CarmenEmployees",
                UserID = "sa",
                Password = "Sql#123456789"
            };

            Conexion = new SqlConnection(CadenaConexion.ToString());

            try
            {
                Conexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
