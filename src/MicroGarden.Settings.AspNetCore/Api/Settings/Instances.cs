using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MicroGarden.Settings.AspNetCore.Api.Settings.Models;
using MicroGarden.Settings.Core.Schemas.Services.Provider;
using MicroGarden.Settings.Core.Data.Services.Storage;

namespace MicroGarden.Settings.AspNetCore.Api.Settings
{    
    public class Instances : Controller
    {
        readonly ISettingsSchemaProvider _provider;
        readonly ISettingsDataStorage _storage;

        public Instances(ISettingsSchemaProvider provider,
            ISettingsDataStorage storage)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (storage == null) throw new ArgumentNullException(nameof(storage));

            _provider = provider;
            _storage = storage;
        }

        public async Task<IEnumerable<SettingsInstanceInfo>> Get()
        {
            return (await _provider.List()).Select(x => new SettingsInstanceInfo
            {
                Id = x.Id,
                DisplayName = x.DisplayName
            });
        }
        
        public async Task<SettingsInstance> Item(string id)
        {
            var entity = await _provider.Get(id);
            var data = await _storage.Get(id);

            return new SettingsInstance
            {
                Id = entity.Id,
                DisplayName = entity.DisplayName,
                Data = data,
                Schema = entity.Schema
            };
        }
    }
}
