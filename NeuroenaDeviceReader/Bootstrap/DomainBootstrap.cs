using Microsoft.Extensions.DependencyInjection;
using NeuroenaDeviceReader.Input;
using NeuroenaDeviceReader.Logger;
using NeuroenaDeviceReader.Parser;
using NeuroenaDeviceReader.Services;

namespace NeuroenaDeviceReader.Bootstrap
{
    public static class DomainBootstrap
    {
        public static void AddComponents(this IServiceCollection services)
        {
            services.AddSingleton<INeuroDeviceService, NeuroDeviceService>();
            services.AddSingleton<IPortReader>(new PortReader("COM3"));
            services.AddSingleton<INeuroParser, NeuroDtoParser>();
            services.AddSingleton<ILogger>(new CsvLogger("data.csv"));
            services.AddSingleton<ILogger, ConsoleLogger>();

        }
    }
}
