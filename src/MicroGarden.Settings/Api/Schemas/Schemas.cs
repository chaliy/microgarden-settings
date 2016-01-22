using MicroGarden.Settings.Core.Schemas.Models;
using MicroGarden.Settings.Core.Schemas.Services.Storage;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroGarden.Settings.Api.Schemas
{
    [Route("api/[controller]")]
    public class Schemas : Controller
    {
        readonly ISettingsSchemaStorage _storage;

        public Schemas(ISettingsSchemaStorage storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public async Task<IEnumerable<SettingsEntity>> Get()
        {
            return (await _storage.List());
        }

        [HttpPost]
        public async Task Create([FromBody]SettingsEntity entity)
        {
            await _storage.Create(entity);
        }

    }
}
