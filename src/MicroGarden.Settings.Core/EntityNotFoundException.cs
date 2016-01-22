namespace MicroGarden.Settings.Core
{
    public class EntityNotFoundException : ReasonableException
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
