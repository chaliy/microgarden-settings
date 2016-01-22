using System;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MicroGarden.Settings.Core.Data.Services.Storage;
using MicroGarden.Settings.Npgsql.Services;

namespace MicroGarden.Settings.Npgsql.Implementations.SettingsDataStorage
{
    public class NpgsqlSettingsDataStorage : ISettingsDataStorage
    {
        static readonly Func<dynamic, dynamic> ReadSettingsData = record =>
            JsonConvert.DeserializeObject<dynamic>(record.data ?? "{}");

        readonly NpgsqlConnectionService _connectionService;

        public NpgsqlSettingsDataStorage(NpgsqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public async Task<dynamic> Get(string name)
        {
            using (var connection = await _connectionService.OpenConnectionAsync())
            {
                var records = await connection.QueryAsync<dynamic>(
                  "SELECT name, data FROM settings WHERE name = @Name",
                  new
                  {
                      Name = name
                  });

                return records
                    .Select(ReadSettingsData)
                    .FirstOrDefault() ?? new {};
            }
        }

        public async Task Update(string name, dynamic data)
        {
            using (var connection = await _connectionService.OpenConnectionAsync())
            {
                await connection.ExecuteAsync(@"INSERT INTO settings(name, data, context)
                    VALUES(@Name, @Data::json, '')
                    ON CONFLICT (name) DO UPDATE SET data = EXCLUDED.data", new
                {
                     Name = name,
                     Data = JsonConvert.SerializeObject(data)
                });
            }
        }

        public void Up()
        {
            using (var connection = _connectionService.OpenConnection())
            {
                connection.Execute(@"CREATE TABLE IF NOT EXISTS settings
                (                    
                    name varchar(450) PRIMARY KEY,
                    data json NOT NULL,
                    context varchar(450) NOT NULL
                )");
            }
        }

        
    }
}
