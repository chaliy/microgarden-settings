using MicroGarden.Settings.Core.Schemas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroGarden.Settings.Core.Schemas.Services.Storage
{
    public interface ISchemaStorage
    {
        Task<IList<SettingsEntity>> List();

        Task<SettingsEntity> Get(string name);

        Task Create(SettingsEntity entity);

        Task Update(string key, SettingsEntity entity);

        Task Remove(string key);
    }
}
