using NeuroenaDeviceReader.Models;

namespace NeuroenaDeviceReader.Parser
{
    public interface INeuroParser
    {
        NeuroDto Parse(byte[] packet);
    }
}