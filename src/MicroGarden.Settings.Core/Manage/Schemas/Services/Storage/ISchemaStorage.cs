using MicroGarden.Settings.Core.Manage.Schemas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroGarden.Settings.Core.Manage.Schemas.Services.Storage
{
    public interface ISchemaStorage
    {
        Task<IList<SettingsEntity>> List();
        
        Task Create(SettingsEntity entity);
        
        Task Update(string key, SettingsEntity entity);
        
        Task Remove(string key);
    }
}
