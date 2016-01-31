using System;
using System.Linq;
using Dapper;
using MicroGarden.Settings.Core.Schemas.Models;
using MicroGarden.Settings.Core.Schemas.Services.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MicroGarden.Settings.Core.Schemas.Exceptions;
using MicroGarden.Settings.Npgsql.Services;

namespace MicroGarden.Settings.Stores.Npgsql.Implementations.SchemaStorage
{
    public class NpgsqlSettingsSchemaStorage : ISettingsSchemaStorage
    {
        static readonly Func<dynamic, SettingsEntity> ReadSettingsEntity = record => new SettingsEntity
        {
            Id = record.id,
            DisplayName = record.displayname,
            Schema = JsonConvert.DeserializeObject<SettingsSchema>(record.schema ?? "{}")
        };

        readonly NpgsqlConnectionService _connectionService;

        public NpgsqlSettingsSchemaStorage(NpgsqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public async Task Create(SettingsEntity entity)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                await connection.ExecuteAsync("INSERT INTO settingsschemas(id, displayname, schema, context) VALUES (@Id, @DisplayName, @Schema::json, @Context)", new {
                    entity.Id,
                    entity.DisplayName,
                    Schema = JsonConvert.SerializeObject(entity.Schema),
                    Context = ""
                });
            }
        }

        public async Task<IReadOnlyList<SettingsEntity>> List()
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                var records = await connection.QueryAsync<dynamic>("SELECT id, displayname, schema FROM settingsschemas");

                return records
                    .Select(ReadSettingsEntity)
                    .ToList();
            }
        }

        public async Task<SettingsEntity> Get(string id)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                var records = await connection.QueryAsync<dynamic>(
                  "SELECT id, displayname, schema FROM settingsschemas WHERE id = @Id",
                  new
                  {
                      Id = id
                  });

                var record = records
                    .Select(ReadSettingsEntity)
                    .FirstOrDefault();
                if (record == null)
                {
                    throw new SchemaNotFoundException(id);
                }
                return record;
            }
        }

        public async Task Remove(string id)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                await connection.ExecuteAsync("DELETE FROM settingsschemas WHERE id = @Id", new {
                    Id = id
                });
            }
        }

        public async Task Update(string id, SettingsEntity entity)
        {
            using(var connection = await _connectionService.OpenConnectionAsync())
            {
                await connection.ExecuteAsync("UPDATE settingsschemas SET id=@Id, displayname=@DisplayName, schema=@Schema::json, context=@Context WHERE id = @OriginalId", new {
                    OriginalId = id,
                    entity.DisplayName,
                    entity.Id,
                    Schema = JsonConvert.SerializeObject(entity.Schema),
                    Context = ""
                });
            }
        }

        public void Up()
        {
            using (var connection = _connectionService.OpenConnection())
            {
                connection.Execute(@"CREATE TABLE IF NOT EXISTS settingsschemas
                (
                    id varchar(450) NOT NULL,
                    displayname varchar(450) NOT NULL,
                    schema json NOT NULL,
                    context varchar(450) NOT NULL
                )");
            }
        }
    }
}
