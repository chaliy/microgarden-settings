using MicroGarden.Settings.Api.Manage.Models;
using MicroGarden.Settings.Core.Manage.Schemas.Models;
using MicroGarden.Settings.Core.Manage.Schemas.Services.Storage;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroGarden.Settings.Api.Manage
{
    [Route("api/manage/[controller]")]
    public class Schemas : Controller
    {
        readonly ISchemaStorage _storage;

        public Schemas(ISchemaStorage storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public async Task<IEnumerable<SettingsEntityInfo>> Get()
        {
            var entities = await _storage.List();
            return entities.Select(x => new SettingsEntityInfo
            {
                Name = x.Name,
                Key = x.Key
            });
        }

        [HttpPost]
        public async Task Create([FromBody]SettingsEntity entity)
        {
            await _storage.Create(entity);
        }

    }
}
