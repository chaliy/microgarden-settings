using MicroGarden.Settings.Core.Schemas.Models;
using MicroGarden.Settings.Core.Schemas.Services.Storage;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroGarden.Settings.AspNetCore.Api.Schemas
{
    public class Schemas : Controller
    {
        readonly ISettingsSchemaStorage _storage;

        public Schemas(ISettingsSchemaStorage storage)
        {
            _storage = storage;
        }
        
        public async Task<IEnumerable<SettingsEntity>> Get()
        {
            return (await _storage.List());
        }

        public async Task<SettingsEntity> Item([FromRoute]string id)
        {
            System.Console.WriteLine(id);
            return await _storage.Get(id);
        }

        public async Task<SettingsEntity> Post([FromBody]SettingsEntity entity)
        {
            await _storage.Create(entity);

            return entity;
        }

        public async Task<SettingsEntity> Put(string id, [FromBody]SettingsEntity entity)
        {
            System.Console.WriteLine(id);
            await _storage.Update(id, entity);

            return entity;
        }

    }
}
