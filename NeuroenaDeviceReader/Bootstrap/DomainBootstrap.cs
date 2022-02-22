using Microsoft.Extensions.DependencyInjection;
using NeuroenaDeviceReader.Input;
using NeuroenaDeviceReader.Logger;
using NeuroenaDeviceReader.Parser;
using NeuroenaDeviceReader.Services;
using Microsoft.Extensions.Configuration;

namespace NeuroenaDeviceReader.Bootstrap
{
    public static class DomainBootstrap
    {
        public static void AddComponents(this IServiceCollection services)
        {
            var config = GetAppConfiguration();
            var comPort = config.GetRequiredSection("ComPort").Get<string>();

            services.AddSingleton<INeuroDeviceService, NeuroDeviceService>();
            services.AddSingleton<IPortReader>(new PortReader(comPort));
            services.AddSingleton<INeuroParser, NeuroDtoParser>();
            services.AddSingleton<ILogger>(new CsvLogger("data.csv"));
            services.AddSingleton<ILogger, ConsoleLogger>();
        }

        public static IConfiguration GetAppConfiguration()
        {
            return new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables()
                        .Build();
        }
    }
}
