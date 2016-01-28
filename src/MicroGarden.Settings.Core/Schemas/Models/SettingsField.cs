using System.Collections.Generic;

namespace MicroGarden.Settings.Core.Schemas.Models
{
    public class SettingsField
    {
        public string Name { get; set; }
        public string DysplayName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public string Title { get; set; }
        public string Placeholder { get; set; }

        public string Pattern { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public bool Required { get; set; }
        public string Step { get; set; }
        public string MaxLength { get; set; }

        public IDictionary<string, string> Properties { get; set; }
    }
}
