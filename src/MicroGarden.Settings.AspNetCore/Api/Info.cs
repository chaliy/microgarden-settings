using Microsoft.AspNet.Mvc;

namespace MicroGarden.Settings.AspNetCore.Api
{
    public class Info : Controller
    {
        public object Get()
        {
            return new
            {
                Version = "1.0.0"
            };
        }

    }
}
