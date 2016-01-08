using System.Linq;
using Dapper;
using MicroGarden.Settings.Core.Manage.Schemas.Models;
using MicroGarden.Settings.Core.Manage.Schemas.Services.Storage;
using MicroGarden.Settings.Stores.PostgreSQL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MicroGarden.Settings.Stores.PostgreSQL.Implementations.SchemaStorage
{
    public class NpgsqlSchemaStorage : ISchemaStorage
    {
        readonly NpgsqlConnectionService _connectionService;

        public NpgsqlSchemaStorage(NpgsqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public async Task Create(SettingsEntity entity)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                await connection.ExecuteAsync("INSERT INTO SettingsSchemas(Name, Key, Schema, Context) VALUES (@Key, @Name, @Schema::json, @Context)", new {
                    entity.Key,
                    entity.Name,
                    Schema = JsonConvert.SerializeObject(entity.Schema),
                    Context = ""
                });
            }
        }

        public async Task<IList<SettingsEntity>> List()
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                var records = await connection.QueryAsync<dynamic>("SELECT Name, Key, Schema FROM SettingsSchemas");

                return records
                    .Select(x => new SettingsEntity
                    {
                        Name = x.Name,
                        Key = x.Key,
                        Schema = JsonConvert.DeserializeObject<SettingsSchema>(x.Schema)
                    })
                    .ToList();
            }            
        }

        public async Task Remove(string key)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                await connection.ExecuteAsync("DELETE FROM SettingsSchemas WHERE Key = @Key", new {
                    Key = key                    
                });
            }
        }

        public async Task Update(string key, SettingsEntity entity)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {                
                await connection.ExecuteAsync("UPDATE SettingsSchemas SET Name=@Name, Key=@Key, Schema=@Schema::json, Context=@Context) WHERE Key = @OrginalKey", new {
                    OriginalKey = key,
                    entity.Key,
                    entity.Name,
                    Schema = JsonConvert.SerializeObject(entity.Schema),
                    Context = ""
                });
            }
        }
    }
}
