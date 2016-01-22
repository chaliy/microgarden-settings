using MicroGarden.Settings.Core.Data.Services.Storage;
using MicroGarden.Settings.Npgsql.Implementations.SettingsDataStorage;

namespace Microsoft.Extensions.DependencyInjection
{
    public class NpgsqlMicroGardenSettingsServicesBuilder : 
        NpgsqlMicroGardenSettingsServicesBuilder.IAccessor
    {
        private readonly IServiceCollection _services;

        public NpgsqlMicroGardenSettingsServicesBuilder(IServiceCollection services)
        {
            _services = services;
        }

        IServiceCollection IAccessor.Services
        {
            get
            {
                return _services;
            }
        }

        public interface IAccessor
        {
            IServiceCollection Services { get; }
        }

        public NpgsqlMicroGardenSettingsServicesBuilder AddDataStorage()
        {
            _services.AddTransient<NpgsqlSettingsDataStorage>();
            _services.AddTransient<ISettingsDataStorage, NpgsqlSettingsDataStorage>();
            return this;
        }

    }
}
