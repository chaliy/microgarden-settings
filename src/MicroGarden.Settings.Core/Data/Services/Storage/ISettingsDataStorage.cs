using System.Threading.Tasks;

namespace MicroGarden.Settings.Core.Data.Services.Storage
{
    public interface ISettingsDataStorage
    {
        Task<dynamic> Get(string name);
        Task Update(string name, dynamic target);
    }
}
