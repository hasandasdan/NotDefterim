using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerr
{
   public class SqlDataProviderr
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataProviderr(string connStr)
        {
            Connection = new SqlConnection(connStr);
            Command = Connection.CreateCommand();
        }
        public DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();
            Command.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            adapter.Fill(dt);
            return dt;
        }
        public object GetSingleData(string query)
        {
            object result = null;
            Connection.Open();
            result = Command.ExecuteScalar(); //ilk satır ilk hücreyi okur

            Connection.Close();
            return result;
        }
    }
}
