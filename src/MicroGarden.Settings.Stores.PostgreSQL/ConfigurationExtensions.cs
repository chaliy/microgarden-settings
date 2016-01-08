using MicroGarden.Settings.Stores.PostgreSQL.Services;
using Microsoft.AspNet.Builder;
using System;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void UseMicroGardenSettingsPostgreSQLStore(this IApplicationBuilder app, string connectionString)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            var connectionService = (NpgsqlConnectionService)app.ApplicationServices.GetService(typeof(NpgsqlConnectionService));
            
            if (connectionService == null)
            {
                throw new InvalidOperationException("PostgreSQL MicroGarden Settings services are not configured yet. Consider using AddMicroGardenSettingsPostgreSQLStore in ConfigureServices");
            }

            connectionService.SetConnectionString(connectionString);
        }
        
        public static void InitMicroGardenSettingsPostgreSQLStore(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            
            var initializationService = (NpgsqlStorageInitializationService)app.ApplicationServices.GetService(typeof(NpgsqlStorageInitializationService));
            
            if (initializationService == null)
            {
                throw new InvalidOperationException("PostgreSQL MicroGarden Settings services are not configured yet. Consider using AddMicroGardenSettingsPostgreSQLStore in ConfigureServices");
            }

            initializationService.Init();
        }
    }
}
