using MicroGarden.Settings.AspNetCore.IntegrationTests.Fakes;
using MicroGarden.Settings.Core.Schemas.Models;
using MicroGarden.Settings.Core.Schemas.Services.Storage;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MicroGarden.Settings.AspNetCore.IntegrationTests.Api
{
    public class SchemasContractTests
    {
        [Fact]
        public async Task Should_return_list()
        {
            await Server(async client =>
            {
                var response = await client.GetAsync("/settings/api/schemas");
                var result = await response.Content.ReadAs<dynamic[]>();
                
                Assert.NotEmpty(result);                
            });
        }

        [Fact]
        public async Task Should_return_item()
        {
            await Server(async client =>
            {
                var response = await client.GetAsync("/settings/api/schemas/first");
                var result = await response.Content.ReadAs<dynamic>();
                
                Assert.Equal("first", (string)result.Id);
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
                services.AddSingleton<ISettingsSchemaStorage>(
                    s => new FakeSettingsSchemaStorage(FortyTwo.SomeSchemas()));
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
