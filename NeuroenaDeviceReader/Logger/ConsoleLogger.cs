using NeuroenaDeviceReader.Extensions;
using NeuroenaDeviceReader.Models;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NeuroenaDeviceReader.Logger
{
    public class ConsoleLogger : ILogger
    {
        private bool _isFirstTimeLogging;
        public ConsoleLogger()
        {
            _isFirstTimeLogging = true;
        }
        public Task Log<T>(T obj) where T : class
        {
            return Task.Run(() => Console.WriteLine(CreateString(obj)));
        }
        private string CreateString<T>(T obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (_isFirstTimeLogging) 
            {
                _isFirstTimeLogging = false;
                stringBuilder.AppendLine(obj.GetPropertiesNames(" "));
            }

            stringBuilder.AppendLine(obj.GetPropertiesValues(" "));

            return stringBuilder.ToString();
        }
    }
}
