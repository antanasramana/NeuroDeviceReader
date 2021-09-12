using Microsoft.Extensions.DependencyInjection;
using NeuroenaDeviceReader.Bootstrap;
using NeuroenaDeviceReader.Services;
using System;

namespace NeuroenaDeviceReader
{
    class Program
    {
        static void Main()
        {
            IServiceProvider serviceProvider = Startup();
            var neuroDeviceService = serviceProvider.GetRequiredService<INeuroDeviceService>();
            neuroDeviceService.Start();
        }
        static IServiceProvider Startup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddComponents();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
