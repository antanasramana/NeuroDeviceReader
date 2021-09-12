using NeuroenaDeviceReader.Models;
using System.Threading.Tasks;

namespace NeuroenaDeviceReader.Logger
{
    public interface ILogger
    {
        Task Log<T>(T obj) where T : class;
    }
}