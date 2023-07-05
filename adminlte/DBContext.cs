using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Npgsql;
using System;
using System.Data;


namespace adminlte
{
    public class DBContext : IDisposable
    {
        private NpgsqlConnection connection;

        public DBContext()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public void ExecuteNonQuery(string sql)
        {
            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string sql)
        {
            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                return command.ExecuteScalar();
            }
        }

        public DataTable ExecuteQuery(string sql)
        {
            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void Dispose()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
        }



    }
}

