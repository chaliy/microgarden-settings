using System;
using System.Threading.Tasks;
using MicroGarden.Settings.Core.Data;
using MicroGarden.Settings.Core.Data.Services.Storage;
using MicroGarden.Settings.Core.Schemas.Services.Provider;
using Microsoft.AspNet.Mvc;

namespace MicroGarden.Settings.AspNetCore.Api.Settings
{
    [Route("api/settings/[controller]")]
    public class Data : Controller
    {
        readonly ISettingsSchemaProvider _provider;
        readonly ISettingsDataStorage _storage;

        public Data(ISettingsSchemaProvider provider, ISettingsDataStorage storage)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (storage == null) throw new ArgumentNullException(nameof(storage));

            _provider = provider;
            _storage = storage;
        }

        [HttpPut("{id}")]
        public async Task<dynamic> Update(string id, [FromBody]dynamic changes)
        {
            var target = await _storage.Get(id);

            target = DataMerger.Merge(target, changes);
            await _storage.Update(id, target);
            return target;
        }

    }
}
