using MicroGarden.Settings.Core.Data.Services.Storage;
using MicroGarden.Settings.Core.Schemas.Services.Provider;
using MicroGarden.Settings.Core.Schemas.Services.Storage;
using MicroGarden.Settings.Npgsql.Implementations.SchemaProvider;
using MicroGarden.Settings.Npgsql.Implementations.SettingsDataStorage;
using MicroGarden.Settings.Stores.Npgsql.Implementations.SchemaStorage;

namespace Microsoft.Extensions.DependencyInjection
{
    public class NpgsqlMgsServicesBuilder : 
        NpgsqlMgsServicesBuilder.IAccessor
    {
        private readonly IServiceCollection _services;

        public NpgsqlMgsServicesBuilder(IServiceCollection services)
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

        public NpgsqlMgsServicesBuilder AddDataStorage()
        {
            _services.AddTransient<NpgsqlSettingsDataStorage>();
            _services.AddTransient<ISettingsDataStorage, NpgsqlSettingsDataStorage>();
            return this;
        }

        public NpgsqlMgsServicesBuilder AddSchemaStorage()
        {
            _services.AddTransient<NpgsqlSettingsSchemaStorage>();
            _services.AddTransient<ISettingsSchemaProvider, NpgsqlSettingsSchemaProvider>();
            _services.AddTransient<ISettingsSchemaStorage, NpgsqlSettingsSchemaStorage>();
            return this;
        }

    }
}
