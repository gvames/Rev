using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alone_Revisal.Utils
{
    public class Helper
    {
        public static string GetRevisalConfigurationConnectionString(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            string path = hostingEnvironment.WebRootPath;

            string configurationString = configuration.GetConnectionString("DefaultConnection");
            configurationString = configurationString.Replace("%REVISALDB%", path);

            return configurationString;
        }

        public static string GetLocalConfigurationConnectionString(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            string path = hostingEnvironment.WebRootPath;

            string configurationString = configuration.GetConnectionString("LocalDatabaseConnection");
            configurationString = configurationString.Replace("%LOCALDB%", path);

            return configurationString;
        }
    }
}
