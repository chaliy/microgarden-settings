using MicroGarden.Settings.Core.Schemas.Models;

namespace MicroGarden.Settings.Api.Settings.Models
{
    public class SettingsInstance
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public dynamic Data {get; set; }

        public SettingsSchema Schema { get; set; }
    }
}
