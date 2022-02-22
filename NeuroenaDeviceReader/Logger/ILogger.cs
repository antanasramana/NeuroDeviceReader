using NeuroenaDeviceReader.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeuroenaDeviceReader.Logger
{
    public interface ILogger
    {
        Task Log<T>(IEnumerable<T> objects, DateTime startDate) where T : class;
    }
}