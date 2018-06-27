using System.Configuration;
using System.Collections.Specialized;

namespace FishAutomatedTests.Framework
{
    public static class Config
    {
        /// <summary>
        /// Main URL of the Web and API
        /// </summary>
        public static string QaAppHost
        {
            get
            {
                var env = (NameValueCollection)ConfigurationManager.GetSection("environmentSetup");
                return env["QaAppHost"];
            }
        }
        public static string QaAuthHost
        {
            get
            {
                var env = (NameValueCollection)ConfigurationManager.GetSection("environmentSetup");
                return env["QaAuthHost"];
            }
        }
    }
}
