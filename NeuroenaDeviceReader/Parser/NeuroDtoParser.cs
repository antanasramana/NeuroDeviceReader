using NeuroenaDeviceReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NeuroenaDeviceReader.Parser
{
    public class NeuroDtoParser : INeuroParser
    {
        public IEnumerable<NeuroDto> Parse(IEnumerable<byte[]> packets)
        {
            var neuroDtos = new List<NeuroDto>();
            foreach(var packet in packets)
            {
                neuroDtos.Add(new NeuroDto()
                {
                    TimeStamp = BitConverter.ToSingle(packet, 0),
                    Acc1X = BitConverter.ToSingle(packet, 4),
                    Acc2X = BitConverter.ToSingle(packet, 8),
                    Acc1Y = BitConverter.ToSingle(packet, 12),
                    Acc2Y = BitConverter.ToSingle(packet, 16),
                    Acc1Z = BitConverter.ToSingle(packet, 20),
                    Acc2Z = BitConverter.ToSingle(packet, 24),
                    Gyro1X = BitConverter.ToSingle(packet, 28),
                    Gyro2X = BitConverter.ToSingle(packet, 32),
                    Gyro1Y = BitConverter.ToSingle(packet, 36),
                    Gyro2Y = BitConverter.ToSingle(packet, 40),
                    Gyro1Z = BitConverter.ToSingle(packet, 44),
                    Gyro2Z = BitConverter.ToSingle(packet, 48),
                    Emg1 = BitConverter.ToSingle(packet, 52),
                    Emg2 = BitConverter.ToSingle(packet, 56)
                });
            }
            return neuroDtos;
        }
    }
}
