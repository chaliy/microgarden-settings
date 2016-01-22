namespace MicroGarden.Settings.Core.Schemas.Exceptions
{
    public class SchemaNotFoundException : EntityNotFoundException
    {
        public SchemaNotFoundException(string name)
            : base($"Settings entry '{name}' was not found")
        {
        }
    }
}
