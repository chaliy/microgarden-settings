using MicroGarden.Settings.Core.Schemas.Models;
using MicroGarden.Settings.Core.Schemas.Services.Provider;
using MicroGarden.Settings.InMemory.Implementations.SchemaProvider;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InMemoryMicroGardenSettingsServicesBuilderExtensions
    {
        public static MicroGardenSettingsServicesBuilder AddInMemory(this MicroGardenSettingsServicesBuilder builder,
            IEnumerable<SettingsEntity> entities)
        {
            var accessor = (MicroGardenSettingsServicesBuilder.IAccessor)builder;
            accessor.Services.AddInstance<ISettingsSchemaProvider>(new InMemorySettingsSchemaProvider(entities));

            return builder;
        }
    }
}
