namespace Microsoft.Extensions.DependencyInjection
{
    public class MicroGardenSettingsServicesBuilder : MicroGardenSettingsServicesBuilder.IAccessor
    {
        private readonly IServiceCollection _services;

        public MicroGardenSettingsServicesBuilder(IServiceCollection services)
        {
            _services = services;
        }

        IServiceCollection IAccessor.Services
        {
            get
            {
                return _services;
            }
        }

        public interface IAccessor
        {
            IServiceCollection Services { get; }
        }
    }
}
