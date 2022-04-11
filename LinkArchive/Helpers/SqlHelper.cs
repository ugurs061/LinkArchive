using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LinkArchive
{
    public class SqlHelper
    {
        // variables
        private string conString { get; set; }
        private SqlConnection con { get; set; }

        // constructor
        public SqlHelper(string connectingString)// classı her çağırdığımızda sql ile bağlantı sağlaması için constructor oluşturuyoruz.
        {
            conString = connectingString;
            con = new SqlConnection(conString);
        }

        // ExecuteProc - sqldeki proc ları çalıştımak için metod yazıyoruz.
        public void ExecuteProc(string procName, params SqlParameter[] ps)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            command.Parameters.AddRange(ps);
            command.Connection = con;
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        // GetTable - verileri getirtmek için metod tanımlıyoruz.
        public (bool, DataTable, string) GetTable(string query)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conString);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return (true, dt, string.Empty);
            }
            catch (System.Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        // ExecuteNoneQuery - parametreli sql komutu çalıştırır
        public (bool, string) ExecuteNoneQuery(string sql, List<SqlParameter> parameters = null)
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                cmd.ExecuteNonQuery();
                con.Close();
                return (true, String.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }


    }
}
