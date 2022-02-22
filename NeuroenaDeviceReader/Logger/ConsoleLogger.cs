using NeuroenaDeviceReader.Extensions;
using NeuroenaDeviceReader.Models;
using System;
using System.Collections.Generic;
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
        public Task Log<T>(IEnumerable<T> objects, DateTime startDate) where T : class
        {
            var stringBuilder = new StringBuilder();
            foreach (var obj in objects)
            {
                stringBuilder.Append(CreateString(obj, startDate));
            }
            return Task.Run(() => Console.WriteLine(stringBuilder.ToString()));
        }
        private string CreateString<T>(T obj, DateTime startDate)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (_isFirstTimeLogging) 
            {
                _isFirstTimeLogging = false;
                stringBuilder.AppendLine(startDate.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
                stringBuilder.AppendLine(obj.GetPropertiesNames(" "));
            }

            stringBuilder.AppendLine(obj.GetPropertiesValues(" "));

            return stringBuilder.ToString();
        }
    }
}
