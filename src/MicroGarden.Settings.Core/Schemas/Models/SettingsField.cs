using System.Collections.Generic;

namespace MicroGarden.Settings.Core.Schemas.Models
{
    public class SettingsField
    {
        public string Name { get; set; }
        public string DysplayName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public IDictionary<string, string> Data { get; set; }
    }
}
