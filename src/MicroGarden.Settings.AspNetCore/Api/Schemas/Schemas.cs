using MicroGarden.Settings.Core.Schemas.Models;
using MicroGarden.Settings.Core.Schemas.Services.Storage;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroGarden.Settings.AspNetCore.Api.Schemas
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

        [HttpGet("{id}")]
        public async Task<SettingsEntity> Get(string id)
        {
            return await _storage.Get(id);
        }

        [HttpPost]
        public async Task<SettingsEntity> Create([FromBody]SettingsEntity entity)
        {
            await _storage.Create(entity);

            return entity;
        }

        [HttpPut("{id}")]
        public async Task<SettingsEntity> Create(string id, [FromBody]SettingsEntity entity)
        {
            await _storage.Update(id, entity);

            return entity;
        }

    }
}
