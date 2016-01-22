using MicroGarden.Settings.Core.Schemas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroGarden.Settings.Core.Schemas.Services.Provider
{
    public interface ISettingsSchemaProvider
    {
        Task<IReadOnlyList<SettingsEntity>> List();
        
        /// <exception cref="SchemaNotFoundException">Thrown when exception was not found</exception>        
        Task<SettingsEntity> Get(string name);
    }
}
