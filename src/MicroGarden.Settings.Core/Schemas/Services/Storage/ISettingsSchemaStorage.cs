using MicroGarden.Settings.Core.Schemas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroGarden.Settings.Core.Schemas.Services.Storage
{
    public interface ISettingsSchemaStorage
    {
        Task<IReadOnlyList<SettingsEntity>> List();

        /// <exception cref="SchemaNotFoundException">Thrown when exception was not found</exception>
        Task<SettingsEntity> Get(string id);

        Task Create(SettingsEntity entity);

        Task Update(string id, SettingsEntity entity);

        Task Remove(string id);
    }
}
