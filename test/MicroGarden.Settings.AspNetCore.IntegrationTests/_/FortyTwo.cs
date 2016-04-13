using MicroGarden.Settings.Core.Schemas.Models;

namespace MicroGarden.Settings.AspNetCore.IntegrationTests
{
    internal class FortyTwo
    {
        public static SettingsEntity[] SomeSchemas()
        {
            return new[]
            {
                new SettingsEntity
                {
                    Id = "first",
                    DisplayName = "First Settings",
                    Schema = new SettingsSchema
                    {
                        Sections = new []
                        {
                            new SettingsSection
                            {
                                Id = "test",
                                DisplayName = "Test",
                                Description = "Test Description",
                                Fields = new []
                                {
                                    new SettingsField
                                    {
                                        Name = "field1",
                                        Type = "text",
                                        DisplayName = "Field #1",
                                        Required = true
                                    },
                                    new SettingsField
                                    {
                                        Name = "field2",
                                        Type = "text",
                                        DisplayName = "Field #2"
                                    }
                                }
                            }
                        }
                    }
                },
                new SettingsEntity
                {
                    Id = "test",
                    DisplayName = "Test Settings",
                    Schema = new SettingsSchema
                    {
                        Sections = new []
                        {
                            new SettingsSection
                            {
                                Id = "test",
                                DisplayName = "Test",
                                Description = "Test Descriptio",
                                Fields = new []
                                {
                                    new SettingsField
                                    {
                                        Name = "field1",
                                        Type = "text",
                                        DisplayName = "Field #1"
                                    },
                                    new SettingsField
                                    {
                                        Name = "field2",
                                        Type = "text",
                                        DisplayName = "Field #2"
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }    
    }
}
