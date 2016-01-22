using System;
using System.Linq;
using Dapper;
using MicroGarden.Settings.Core;
using MicroGarden.Settings.Core.Schemas.Models;
using MicroGarden.Settings.Core.Schemas.Services.Storage;
using MicroGarden.Settings.Stores.PostgreSQL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MicroGarden.Settings.Stores.PostgreSQL.Implementations.SchemaStorage
{
    public class NpgsqlSchemaStorage : ISchemaStorage
    {
        static readonly Func<dynamic, SettingsEntity> ReadSettingsEntity = record => new SettingsEntity
        {
            Name = record.name,
            DisplayName = record.displayname,
            Schema = JsonConvert.DeserializeObject<SettingsSchema>(record.schema ?? "{}")
        };

        readonly NpgsqlConnectionService _connectionService;

        public NpgsqlSchemaStorage(NpgsqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public async Task Create(SettingsEntity entity)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                await connection.ExecuteAsync("INSERT INTO settingsschemas(name, displayname, schema, context) VALUES (@Name, @DisplayName, @Schema::json, @Context)", new {
                    entity.Name,
                    entity.DisplayName,
                    Schema = JsonConvert.SerializeObject(entity.Schema),
                    Context = ""
                });
            }
        }

        public async Task<IList<SettingsEntity>> List()
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                var records = await connection.QueryAsync<dynamic>("SELECT name, displayname, schema FROM settingsschemas");

                return records
                    .Select(ReadSettingsEntity)
                    .ToList();
            }
        }

        public async Task<SettingsEntity> Get(string name)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                var records = await connection.QueryAsync<dynamic>(
                  "SELECT name, displayname, schema FROM settingsschemas WHERE name = @Name",
                  new
                  {
                      Name = name
                  });

                var record = records
                    .Select(ReadSettingsEntity)
                    .FirstOrDefault();
                if (record == null)
                {
                    throw new EntityNotFoundException($"Settings entry '{name}' was not found");
                }
                return record;
            }
        }

        public async Task Remove(string name)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                await connection.ExecuteAsync("DELETE FROM settingsschemas WHERE name = @Name", new {
                    Name = name
                });
            }
        }

        public async Task Update(string name, SettingsEntity entity)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                await connection.ExecuteAsync("UPDATE settingsschemas SET name=@Name, displayname=@DysplayName, schema=@Schema::json, context=@Context) WHERE name = @OriginalName", new {
                    OriginalName = name,
                    entity.DisplayName,
                    entity.Name,
                    Schema = JsonConvert.SerializeObject(entity.Schema),
                    Context = ""
                });
            }
        }
    }
}
