using MicroGarden.Settings.Api.Settings.Models;
using MicroGarden.Settings.Core.Schemas.Services.Storage;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroGarden.Settings.Api.Settings
{
    [Route("api/settings/[controller]")]
    public class Data : Controller
    {
        readonly ISchemaStorage _storage;

        public Data(ISchemaStorage storage)
        {
            _storage = storage;
        }


    }
}
