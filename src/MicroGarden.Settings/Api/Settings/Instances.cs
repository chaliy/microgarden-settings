using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MicroGarden.Settings.Api.Settings.Models;
using MicroGarden.Settings.Core.Schemas.Services.Provider;
using MicroGarden.Settings.Core.Data.Services.Storage;

namespace MicroGarden.Settings.Api.Settings
{
    [Route("api/settings/[controller]")]
    public class Instances : Controller
    {
        readonly ISettingsSchemaProvider _provider;
        readonly ISettingsDataStorage _storage;

        public Instances(ISettingsSchemaProvider provider, ISettingsDataStorage storage)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (storage == null) throw new ArgumentNullException(nameof(storage));

            _provider = provider;
            _storage = storage;
        }

        [HttpGet]
        public async Task<IEnumerable<SettingsInstanceInfo>> Get()
        {
            return (await _provider.List()).Select(x => new SettingsInstanceInfo
            {
                Name = x.Name,
                DisplayName = x.DisplayName
            });
        }

        [HttpGet("{name}")]
        public async Task<SettingsInstance> Get(string name)
        {
            var entity = await _provider.Get(name);
            var data = await _storage.Get(name);

            return new SettingsInstance
            {
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Data = data,
                Schema = entity.Schema
            };
        }
    }
}
