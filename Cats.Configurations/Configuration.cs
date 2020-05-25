using Microsoft.Extensions.Configuration;
using System.IO;

namespace Cats.Configurations
{    
    internal class Configuration : Domain.Configurations.IConfiguration
    {
        private readonly IConfiguration _configuration = null;

        public Configuration()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }

        public string Get(string key) => _configuration[key];
            
    }
}