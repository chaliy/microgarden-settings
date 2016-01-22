using System.Collections.Generic;
﻿using MicroGarden.Settings.Core.Schemas.Models;

namespace MicroGarden.Settings.Api.Settings.Models
{
    public class SettingsInstance
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public IDictionary<string, object> Data {get; set; }

        public SettingsSchema Schema { get; set; }
    }
}
