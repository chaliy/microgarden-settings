using System.ComponentModel.DataAnnotations;

namespace MicroGarden.Settings.Core.Schemas.Models
{
    public class SettingsEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public SettingsSchema Schema { get; set; }
    }
}
