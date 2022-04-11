using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkArchive
{
    public class SqlHelper
    {
        private string ConnectingString { get; set; }
        public SqlConnection Connection { get; set; }

        public SqlHelper()//classı her çağırdığımızda sql ile bağlantı sağlaması için constructor oluşturuyoruz.
        {
            ConnectingString = @"Data Source=DESKTOP-9UN9R3H;Initial Catalog=LinkArchive;Integrated Security=True";
            Connection = new SqlConnection(ConnectingString);
        }

        public void ExecuteProc(string procName,params SqlParameter[] ps)  //sqldeki proc ları çalıştımak için metod yazıyoruz.
        { 
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            command.Parameters.AddRange(ps);
            command.Connection = Connection;
            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();

        }

        public DataTable GetTable(string query) //verileri getirtmek için metod tanımlıyoruz.
        { 
            SqlDataAdapter adapter = new SqlDataAdapter(query,ConnectingString);
            DataTable dt=new DataTable();
            adapter.Fill(dt);
            return dt;

        }

    }
}
