namespace MicroGarden.Settings.Core.Schemas.Models
{
    public class SettingsSection
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public SettingsField[] Fields { get; set; }
    }
}
