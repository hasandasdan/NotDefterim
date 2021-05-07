using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class SqlDataProvider
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
    

 

        public SqlDataProvider(string connStr)
        {
            Connection = new SqlConnection(connStr);
            Command = Connection.CreateCommand();
        }
        //public object Reader(string connStr, string query)
        //{
        //    SqlCommand cmd = new SqlCommand(query);
        //    return;

        //}
        //Tablo döndürcez
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
        
        public int RunQuery(string sorgu)
        {

            int result = 0;
            Command.CommandText = sorgu;
            Connection.Open();
            result = Command.ExecuteNonQuery(); 

            Connection.Close();
            return result;
        }
    }
}
