using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroGarden.Settings.AspNetCore.IntegrationTests
{
    internal static class HttpClientExtensions
    {
        public static async Task<T> ReadAs<T>(this HttpContent @this)
        {
            using (var stream = await @this.ReadAsStreamAsync())
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        return new JsonSerializer().Deserialize<T>(jsonReader);
                    }
                }
            }

        }
    }
}
