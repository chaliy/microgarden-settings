using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroGarden.Settings.Core.Schemas.Models;
using MicroGarden.Settings.Core.Schemas.Services.Provider;
using MicroGarden.Settings.Core.Schemas.Services.Storage;

namespace MicroGarden.Settings.Npgsql.Implementations.SchemaProvider
{
    public class NpgsqlSettingsSchemaProvider : ISettingsSchemaProvider
    {
        readonly ISettingsSchemaStorage _storage;

        public NpgsqlSettingsSchemaProvider(ISettingsSchemaStorage storage)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));

            _storage = storage;
        } 

        public Task<SettingsEntity> Get(string id)
        {
            return _storage.Get(id);            
        }

        public Task<IReadOnlyList<SettingsEntity>> List()
        {
            return _storage.List();            
        }
    }
}
