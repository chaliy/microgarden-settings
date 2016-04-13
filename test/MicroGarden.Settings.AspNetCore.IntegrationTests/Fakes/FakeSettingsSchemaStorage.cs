using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroGarden.Settings.Core.Schemas.Models;
using MicroGarden.Settings.Core.Schemas.Services.Storage;
using System.Linq;

namespace MicroGarden.Settings.AspNetCore.IntegrationTests.Fakes
{
    public class FakeSettingsSchemaStorage : ISettingsSchemaStorage
    {
        readonly List<SettingsEntity> _entities = new List<SettingsEntity>();

        public FakeSettingsSchemaStorage()
        {

        }

        public FakeSettingsSchemaStorage(IEnumerable<SettingsEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public Task Create(SettingsEntity entity)
        {
            if (String.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            _entities.Add(entity);

            return Task.FromResult(true);
        }

        public Task<SettingsEntity> Get(string id)
        {
            return Task.FromResult(_entities.First(x => x.Id == id));
        }

        public Task<IReadOnlyList<SettingsEntity>> List()
        {
            return Task.FromResult((IReadOnlyList<SettingsEntity>)_entities.AsReadOnly());
        }

        public Task Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(string id, SettingsEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
