using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MicroGardenSettingsServicesExtensions
    {
        public static IServiceCollection AddMicroGardenSettings(this IServiceCollection services,
            Action<MicroGardenSettingsServicesBuilder> configure)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            configure(new MicroGardenSettingsServicesBuilder(services));

            return services;
        }
    }
}
