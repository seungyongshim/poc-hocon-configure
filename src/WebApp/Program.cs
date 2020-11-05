using Hocon.Extensions.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()
                   .ConfigureAppConfiguration((hbc, cb) =>
                   {
                       var env = hbc.HostingEnvironment;
                       cb.AddHoconFile("appsettings.conf",
                           optional: false,
                           reloadOnChange: true);
                   })
                   .ConfigureServices(services =>
                   {
                       services.Configure<PositionOptions>(Configuration.GetSection(PositionOptions.Position));
                   })

                        
            ;
                   
    }
}
