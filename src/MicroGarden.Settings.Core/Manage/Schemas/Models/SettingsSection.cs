using System.Collections.Generic;

namespace MicroGarden.Settings.Core.Manage.Schemas.Models
{
    public class SettingsSection
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<SettingsField> Fields { get; set; }
    }
}
