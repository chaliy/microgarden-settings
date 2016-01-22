using System.Collections.Generic;

namespace MicroGarden.Settings.Core.Schemas.Models
{
    public class SettingsSection
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public List<SettingsField> Fields { get; set; }
    }
}
