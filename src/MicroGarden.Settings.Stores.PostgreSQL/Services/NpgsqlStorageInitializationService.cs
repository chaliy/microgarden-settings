using System.Threading.Tasks;
using Dapper;

namespace MicroGarden.Settings.Stores.PostgreSQL.Services
{
    public class NpgsqlStorageInitializationService
    {
        readonly NpgsqlConnectionService _connectionService;

        public NpgsqlStorageInitializationService(NpgsqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public void Init()
        {
            using (var connection = _connectionService.OpenConnection())
            {   
                connection.Execute(@"CREATE TABLE IF NOT EXISTS SettingsSchemas
                (
                    Key varchar(450) PRIMARY KEY,
                    Name varchar(450) NOT NULL,
                    Schema json NOT NULL,
                    Context varchar(450) NOT NULL
                )");                               
            }            
        }
    }
}
