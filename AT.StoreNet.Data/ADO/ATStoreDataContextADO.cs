using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AT.StoreNet.Data.ADO
{
    public class ATStoreDataContextADO : IDisposable
    {
        private readonly SqlConnection _conn;
        public ATStoreDataContextADO()
        {
            var connString = ConfigurationManager.ConnectionStrings["ATStore_DB"].ConnectionString;
            _conn = new SqlConnection(connString);
            _conn.Open();
        }

        public void ExecuteCommand(string sql)
        {
            var cmd = new SqlCommand()
            {
                CommandText = sql,
                CommandType = System.Data.CommandType.Text,
                Connection = _conn
            };

            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteCommandWithData(string query)
        {
            var cmd = new SqlCommand(query, _conn);
            return cmd.ExecuteReader();
        }

        public void Dispose()
        {
            if (_conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
            }
        }
    }
}
