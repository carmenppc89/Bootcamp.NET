using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connection
{
    public sealed class DBConnect
    {
        public SqlConnection SqlConn { get; }
        public ConnectionState ConnState { get { return SqlConn.State; } }
        public DBConnect()
        {
            var ConnectionSTR = new SqlConnectionStringBuilder
            {
                DataSource = "46.183.118.102,54321",
                InitialCatalog = "CarmenEmployees",
                UserID = "sa",
                Password = "Sql#123456789"
            };

            SqlConn = new SqlConnection(ConnectionSTR.ToString());
        }


        public bool OpenConnection()
        {
            try
            {
                SqlConn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"La conexion no se ha podido abrir:" +
                    $"\nError -> \n{ex.ToString()}");
                return false;
            }
            return true;
        }

        public bool CloseConnection()
        {
            try
            {
                SqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"La conexion no se ha podido cerrar:" +
                    $"\nError -> \n{ex.ToString()}");
                return false;
            }
            return true;
        }
    }
}
