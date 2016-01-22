using Npgsql;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace MicroGarden.Settings.Npgsql.Services
{
    public class NpgsqlConnectionService
    {
        private string _connectionString;        

        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public DbConnection OpenConnection()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new InvalidOperationException("Connection to PostgreSQL MicroGarden Settings storage is not configured yet. Consider using UseMicroGardenSettingsPostgreSQLStore in Configure");
            }

            var connection = new NpgsqlConnection(_connectionString);
            connection.OpenAsync();

            return connection;
        }

        public async Task<DbConnection> OpenConnectionAsync()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new InvalidOperationException("Connection to PostgreSQL MicroGarden Settings storage is not configured yet. Consider using UseMicroGardenSettingsPostgreSQLStore in Configure");
            }

            var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            return connection;
        }
    }
}
