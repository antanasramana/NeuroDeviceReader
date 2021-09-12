using NeuroenaDeviceReader.Extensions;
using NeuroenaDeviceReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NeuroenaDeviceReader.Logger
{
    public class CsvLogger : ILogger
    {
        private readonly string _filePath;
        private bool _isFirstTimeLogging;
        public CsvLogger(string filePath)
        {
            _filePath = filePath;
            _isFirstTimeLogging = true;
        }
        public Task Log<T>(IEnumerable<T> objects) where T : class
        {
            var stringBuilder = new StringBuilder();
            foreach(var obj in objects)
            {
                stringBuilder.Append(CreateString(obj));
            }
            return File.AppendAllTextAsync(_filePath, stringBuilder.ToString());
        }

        private string CreateString<T>(T obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (_isFirstTimeLogging)
            {
                _isFirstTimeLogging = false;
                stringBuilder.AppendLine(obj.GetPropertiesNames(","));
            }

            stringBuilder.AppendLine(obj.GetPropertiesValues(","));

            return stringBuilder.ToString();
        }
    }
}
