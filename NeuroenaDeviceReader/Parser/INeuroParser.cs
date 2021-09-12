using NeuroenaDeviceReader.Models;
using System.Collections.Generic;

namespace NeuroenaDeviceReader.Parser
{
    public interface INeuroParser
    {
        public IEnumerable<NeuroDto> Parse(IEnumerable<byte[]> packets);
    }
}