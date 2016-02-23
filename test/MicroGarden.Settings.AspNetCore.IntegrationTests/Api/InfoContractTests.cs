using Microsoft.AspNet.Builder;
using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MicroGarden.Settings.AspNetCore.IntegrationTests.Api
{
    public class InfoContractTests
    {
        [Fact]
        public async Task Should_return_info()
        {
            await Server(async client =>
            {
                var response = await client.GetAsync("/settings/api/info");
                var result = await response.Content.ReadAs<dynamic>();

                Assert.Equal("1.0.0", (string)result.Version);
            });
        }

        private static async Task Server(Func<HttpClient, Task> exe)
        {
            var server = TestServer.Create(app =>
            {
                app.UseMvc(routes =>
                {
                    routes.MapMicroGardenSettings();
                });
            }, services =>
            {
                services.AddMvc();
            });

            using (server)
            {
                var client = server.CreateClient();

                await exe(client);
            }
        }
    }
}
