using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroGarden.Settings.Core.Schemas.Models;
using MicroGarden.Settings.Core.Schemas.Services.Provider;
using System.Linq;
using MicroGarden.Settings.Core.Schemas.Exceptions;

namespace MicroGarden.Settings.InMemory.Implementations.SchemaProvider
{
    public class InMemorySettingsSchemaProvider : ISettingsSchemaProvider
    {
        private readonly List<SettingsEntity> _entities;

        public InMemorySettingsSchemaProvider(IEnumerable<SettingsEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            _entities = new List<SettingsEntity>(entities);
        }

        public Task<SettingsEntity> Get(string name)
        {
            var result = _entities.FirstOrDefault(x => x.Name == name);
            if (result == null)
            {
                throw new SchemaNotFoundException(name);
            }

            return Task.FromResult(result);
        }

        public Task<IReadOnlyList<SettingsEntity>> List()
        {
            return Task.FromResult((IReadOnlyList<SettingsEntity>)_entities.AsReadOnly());
        }
    }
}
