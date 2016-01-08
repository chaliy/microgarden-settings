using System.ComponentModel.DataAnnotations;

namespace MicroGarden.Settings.Core.Manage.Schemas.Models
{
    public class SettingsEntity
    {
        [Required]        
        public string Name { get; set; }
        
        [Required]
        public string Key { get; set; }

        [Required]
        public SettingsSchema Schema { get; set; }
    }   
}
