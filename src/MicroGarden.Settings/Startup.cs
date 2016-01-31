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
                    //.AddInMemory(new[]
                    //{
                    //    new SettingsEntity
                    //    {
                    //        Id = "first",
                    //        DisplayName = "First Settings",
                    //        Schema = new SettingsSchema
                    //        {
                    //            Sections = new []
                    //            {
                    //                new SettingsSection
                    //                {
                    //                    Name = "test",
                    //                    DisplayName = "Test",
                    //                    Description = "Test Description",
                    //                    Fields = new []
                    //                    {
                    //                        new SettingsField
                    //                        {
                    //                            Name = "field1",
                    //                            Type = "text",
                    //                            DysplayName = "Field #1",
                    //                            Required = true
                    //                        },
                    //                        new SettingsField
                    //                        {
                    //                            Name = "field2",
                    //                            Type = "text",
                    //                            DysplayName = "Field #2"
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    },
                    //    new SettingsEntity
                    //    {
                    //        Id = "test",
                    //        DisplayName = "Test Settings",
                    //        Schema = new SettingsSchema
                    //        {
                    //            Sections = new []
                    //            {
                    //                new SettingsSection
                    //                {
                    //                    Name = "test",
                    //                    DisplayName = "Test",
                    //                    Description = "Test Descriptio",
                    //                    Fields = new []
                    //                    {
                    //                        new SettingsField
                    //                        {
                    //                            Name = "field1",
                    //                            Type = "text",
                    //                            DysplayName = "Field #1"
                    //                        },
                    //                        new SettingsField
                    //                        {
                    //                            Name = "field2",
                    //                            Type = "text",
                    //                            DysplayName = "Field #2"
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //})
                    .AddNpgsql(npsql =>
                    {
                        npsql.AddDataStorage();
                        npsql.AddSchemaStorage();
                    });
            });

            services.AddMvc(options =>
            {
                var outputSerializerSettings = options.OutputFormatters
                    .OfType<JsonOutputFormatter>()
                    .First()
                    .SerializerSettings;

                outputSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                var inputSerializerSettings = options.InputFormatters
                    .OfType<JsonInputFormatter>()
                    .First()
                    .SerializerSettings;

                inputSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            app.UseMicroGardenSettingsNpgsql(Configuration["ConnectionString"]);
            app.SetupMicroGardenSettingsNpgsqlDataStorage();
            app.SetupMicroGardenSettingsNpgsqlSchemaStorage();

            app.UseIISPlatformHandler();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
