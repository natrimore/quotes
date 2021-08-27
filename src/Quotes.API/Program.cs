using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.API
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var AppName = typeof(Program).Namespace.Split(".")[0];
            Console.Title = AppName;

            Log.Logger = CreateSerilogLogger();

            try
            {
                Log.Information("Configuring web host ({ApplicationContext})...", AppName);

                var host = CreateHostBuilder(args);

                Log.Information("Starting web host ({ApplicationContext})...", AppName);

                host.Run();

                return 0;
            }
            catch (Exception exc)
            {
                Log.Fatal(exc, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
           .AddEnvironmentVariables()
           .Build();

        public static IWebHost CreateHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .CaptureStartupErrors(false)
               .UseStartup<Startup>()
               .UseUrls("http://*:8020")
               .UseSerilog()
               .Build();

        private static Serilog.ILogger CreateSerilogLogger()
        {
            //var seqServerUrl = configuration["Serilog:SeqServerUrl"];

            return new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .Enrich.WithProperty("ApplicationContext", "iPay.Cards")
                                .Enrich.FromLogContext()
                                .WriteTo.Console()
                                .WriteTo.Seq("http://192.168.111.128:8091/")
                                //.ReadFrom.Configuration(Configuration)
                                .CreateLogger();
        }
    }
}
