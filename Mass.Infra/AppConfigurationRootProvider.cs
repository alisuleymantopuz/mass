using Microsoft.Extensions.Configuration;
using System.IO;

namespace Mass.Infra
{
    public class AppConfigurationRootProvider
    {
        public IConfigurationRoot Get()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
