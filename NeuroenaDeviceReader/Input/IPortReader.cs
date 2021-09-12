using System;

namespace NeuroenaDeviceReader.Input
{
    public interface IPortReader
    {
        event EventHandler<byte[]> OnPacketReceived;

        void StartRead();
    }
}