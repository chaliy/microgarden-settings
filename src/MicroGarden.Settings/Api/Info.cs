using Microsoft.AspNet.Mvc;

namespace MicroGarden.Settings.Api
{
    [Route("api/[controller]")]
    public class Info : Controller
    {
        [HttpGet]
        public object Get()
        {
            return new
            {
                 Version = "1.0.0"
            };
        }

    }
}