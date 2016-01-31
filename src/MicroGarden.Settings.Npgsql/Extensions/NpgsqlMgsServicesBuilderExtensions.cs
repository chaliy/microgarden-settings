using MicroGarden.Settings.Npgsql.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NpgsqlMgsServicesBuilderExtensions
    {
        public static MicroGardenSettingsServicesBuilder AddNpgsql(this MicroGardenSettingsServicesBuilder builder,
            Action<NpgsqlMgsServicesBuilder> configure)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            var accessor = (MicroGardenSettingsServicesBuilder.IAccessor)builder;
            accessor.Services.AddInstance(new NpgsqlConnectionService());

            configure(new NpgsqlMgsServicesBuilder(accessor.Services));

            return builder;
        }
    }
}
