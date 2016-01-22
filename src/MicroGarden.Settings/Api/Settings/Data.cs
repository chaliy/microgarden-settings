using MicroGarden.Settings.Core.Data;
using MicroGarden.Settings.Core.Data.Services.Storage;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;

namespace MicroGarden.Settings.Api.Settings
{
    [Route("api/settings/[controller]")]
    public class Data : Controller
    {
        readonly ISettingsDataStorage _storage;

        public Data(ISettingsDataStorage storage)
        {
            _storage = storage;
        }

        [HttpPut("{name}")]
        public async Task<dynamic> Update(string name, [FromBody]dynamic changes)
        {
            var target = await _storage.Get(name);

            target = DataMerger.Merge(target, changes);
            await _storage.Update(name, target);
            return target;
        }

    }
}
