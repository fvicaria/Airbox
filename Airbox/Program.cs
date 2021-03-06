using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Airbox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    var x = webBuilder.UseStartup<Startup>();

                    //if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
                    //    x.ConfigureKestrel(
                    //        (context, options) =>
                    //        {
                    //            options.Listen(
                    //            IPAddress.Any,
                    //            443,
                    //            listenOptions =>
                    //            {
                                    
                    //                    listenOptions.UseHttps("/root/.aspnet/https/Airbox.pfx");
                    //            }

                    //            );


                    //        });
                }
                )
                .ConfigureLogging((hostingContext, logging) =>
                {
                        logging.ClearProviders();
                        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                        logging.AddConsole();
                        logging.AddDebug();
                        logging.AddEventSourceLogger();
                });
    }
}
