using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using MicroGarden.Settings.Core.Schemas.Models;

namespace MicroGarden.Settings
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMicroGardenSettings(builder =>
            {
                builder
                    .AddInMemory(new[]
                    {
                        new SettingsEntity
                        {
                            Name = "first",
                            DisplayName = "First Settings",
                            Schema = new SettingsSchema
                            {
                                Sections = new []
                                {
                                    new SettingsSection
                                    {
                                        Name = "test",
                                        DisplayName = "Test",
                                        Description = "Test Description",
                                        Fields = new []
                                        {
                                            new SettingsField
                                            {
                                                Name = "field1",
                                                Type = "text",
                                                DysplayName = "Field #1",
                                                Required = true
                                            },
                                            new SettingsField
                                            {
                                                Name = "field2",
                                                Type = "text",
                                                DysplayName = "Field #2"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new SettingsEntity
                        {
                            Name = "test",
                            DisplayName = "Test Settings",
                            Schema = new SettingsSchema
                            {
                                Sections = new []
                                {
                                    new SettingsSection
                                    {
                                        Name = "test",
                                        DisplayName = "Test",
                                        Description = "Test Descriptio",
                                        Fields = new []
                                        {
                                            new SettingsField
                                            {
                                                Name = "field1",
                                                Type = "text",
                                                DysplayName = "Field #1"
                                            },
                                            new SettingsField
                                            {
                                                Name = "field2",
                                                Type = "text",
                                                DysplayName = "Field #2"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    })
                    .AddNpgsql(npsql =>
                    {
                        npsql.AddDataStorage();
                    });
            });

            services.AddMvc(options =>
            {
                var formatter = (JsonOutputFormatter)options.OutputFormatters.First(f => f is JsonOutputFormatter);

                formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                formatter.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                formatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            app.UseMicroGardenSettingsNpgsql(Configuration["ConnectionString"]);
            app.SetupMicroGardenSettingsNpgsqlDataStorage();

            app.UseIISPlatformHandler();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
