using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortal.Utilities
{
    /** Utility class to read configuration values from appsettings.json.
     */
    public class ConfigReader
    {
        private static IConfiguration config;

        /** Static constructor to initialize configuration on first access.
         */
        static ConfigReader()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        }

        /** Method to get a configuration value from the AppSettings section.
         * @param key : the key of the setting to retrieve
         * @ return : associated value
         */
        public static string GetValue(string key)
        {
            return config[$"AppSettings:{key}"];
        }
    }
}

