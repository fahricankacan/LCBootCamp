using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Week2.Persistence
{
    public static class Configuration
    {
        static public string ConnectionString 
        { get 
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Week2.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("MicrosoftSqlServer");
            } }
    }
}
