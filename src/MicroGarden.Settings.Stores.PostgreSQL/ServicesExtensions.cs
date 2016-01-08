using MicroGarden.Settings.Stores.PostgreSQL.Implementations.SchemaStorage;
using MicroGarden.Settings.Stores.PostgreSQL.Services;
using MicroGarden.Settings.Core.Manage.Schemas.Services.Storage;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static void AddMicroGardenSettingsPostgreSQLStore(this IServiceCollection services)
        {
            services.AddInstance(new NpgsqlConnectionService());
            services.AddTransient<NpgsqlStorageInitializationService>();            
            services.AddTransient<ISchemaStorage, NpgsqlSchemaStorage>();
        }
    }
}
