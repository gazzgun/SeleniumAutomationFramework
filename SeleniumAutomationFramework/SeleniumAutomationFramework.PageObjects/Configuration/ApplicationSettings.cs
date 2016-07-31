using System.Collections.Specialized;
using System.Configuration;

namespace SeleniumAutomationFramework.PageObjects.Configuration
{
    public static class ApplicationSettings
    {
        public static string GetLocalBrowser
        {
            get
            {
                var section = ConfigurationManager.GetSection("localBrowser") as NameValueCollection;
                return section != null ? section["localBrowser"] : null;
            }
        }
private static string GetSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static string GetEnvironmentBaseUrl()
        {
            return GetSettingValue("EnvironmentBaseUrl");
        }
    }
}
