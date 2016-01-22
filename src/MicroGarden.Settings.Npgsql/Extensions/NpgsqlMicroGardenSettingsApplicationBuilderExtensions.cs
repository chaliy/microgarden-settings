using MicroGarden.Settings.Npgsql.Implementations.SettingsDataStorage;
using MicroGarden.Settings.Npgsql.Services;
using MicroGarden.Settings.Stores.Npgsql.Implementations.SchemaStorage;
using Microsoft.AspNet.Builder;
using System;

namespace Microsoft.Extensions.Configuration
{
    public static class NpgsqlMicroGardenSettingsApplicationBuilderExtensions
    {
        public static void UseMicroGardenSettingsNpgsql(this IApplicationBuilder app, string connectionString)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            var connectionService = (NpgsqlConnectionService)app.ApplicationServices.GetService(typeof(NpgsqlConnectionService));
            
            if (connectionService == null)
            {
                throw new InvalidOperationException("PostgreSQL (Npgsql) MicroGarden Settings services are not configured yet. Consider using AddMicroGardenSettings.AddNpgsql() in ConfigureServices");
            }

            connectionService.SetConnectionString(connectionString);
        }
        
        public static void SetupMicroGardenSettingsNpgsqlDataStorage(this IApplicationBuilder app)
        {
            app.ExecuteSetup<NpgsqlSettingsDataStorage>(s => s.Up());
        }

        public static void SetupMicroGardenSettingsNpgsqlSchemaStorage(this IApplicationBuilder app)
        {
            app.ExecuteSetup<NpgsqlSettingsSchemaStorage>(s => s.Up());
        }

        private static void ExecuteSetup<T>(this IApplicationBuilder app, Action<T> up)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            var initializationService = (T)app.ApplicationServices.GetService(typeof(T));

            if (initializationService == null)
            {
                throw new InvalidOperationException("PostgreSQL (Npgsql) MicroGarden Settings services are not configured yet. Consider using AddMicroGardenSettings.AddNpgsql() in ConfigureServices");
            }

            up(initializationService);
        }
    }
}
