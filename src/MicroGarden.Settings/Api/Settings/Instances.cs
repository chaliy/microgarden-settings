using MicroGarden.Settings.Api.Settings.Models;
using MicroGarden.Settings.Core.Schemas.Services.Storage;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroGarden.Settings.Api.Settings
{
    [Route("api/settings/[controller]")]
    public class Instances : Controller
    {
        readonly ISchemaStorage _storage;

        public Instances(ISchemaStorage storage)
        {
            _storage = storage;
        }

        [HttpGet("{name}")]
        public async Task<SettingsInstance> Get(string name)
        {
            var entity = await _storage.Get(name);

            return new SettingsInstance
            {
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Data = new Dictionary<string, object>
                {
                    { "test", new {
                        Field1 = "SuperValue"
                    } }
                },
                Schema = new Core.Schemas.Models.SettingsSchema
                {
                    Sections = new List<Core.Schemas.Models.SettingsSection>
                    {
                        new Core.Schemas.Models.SettingsSection
                        {
                            Name = "test",
                            DisplayName = "Test",
                            Description = "Test Descriptio",
                            Fields = new List<Core.Schemas.Models.SettingsField>
                            {
                                new Core.Schemas.Models.SettingsField
                                {
                                    Name = "field1",
                                    Type = "Text",
                                    DysplayName = "Field #1"
                                }
                            }
                        }
                    }
                }
                //Schema = entity.Schema
            };
        }
    }
}
