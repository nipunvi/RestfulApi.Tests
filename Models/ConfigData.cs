using System;
using System.Collections.Generic;
using System.Text;

// Represents the data structure for the Config Data.
namespace RestfulApi.Tests.Models
{
    public class ConfigData
    {
        public AppSettingSection AppSetting { get; set; } = new AppSettingSection();
        public TestDataSection PostTestData {  get; set; } = new TestDataSection();

        public TestDataSection PutTestData { get; set; } = new TestDataSection();

    }

    public class AppSettingSection
    {
        public string? BaseURL { get; set; }
    }

    public class TestDataSection 
    { 
        public string? Price { get; set; }
        public string? Name { get; set; }
    }
}
