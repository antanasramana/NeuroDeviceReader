using System;
using System.Collections.Generic;
using NeuroenaDeviceReader.Parser;
using NeuroenaDeviceReader.Logger;
using NeuroenaDeviceReader.Input;
using System.Linq;
using System.Threading.Tasks;

namespace NeuroenaDeviceReader.Services
{
    public class NeuroDeviceService : INeuroDeviceService
    {
        const int _packetSize = 64;
        const uint _packetDelimeter = 0xEFBEADDE;

        private readonly IPortReader _portReader;
        private readonly INeuroParser _parser;
        private readonly IEnumerable<ILogger> _loggers;

        private readonly Queue<byte> _byteQueue;

        private bool _isFirstTimeReceivedPacket;
        public NeuroDeviceService(IPortReader portReader, INeuroParser parser, IEnumerable<ILogger> loggers)
        {
            _portReader = portReader;
            _parser = parser;
            _loggers = loggers;
            _byteQueue = new Queue<byte>();
            _isFirstTimeReceivedPacket = true;
        }

        public void Start()
        {
            _portReader.OnPacketReceived += PortReader_OnPacketReceived;
            _portReader.StartRead();
        }

        private async void PortReader_OnPacketReceived(object sender, byte[] buffer)
        {
            EnqueueBuffer(buffer);
            if (_isFirstTimeReceivedPacket) TrimQueue();

            byte[] packet = DequeuePacket();
            var neuroDto = _parser.Parse(packet);

            await Task.WhenAll(
                _loggers.Select(logger => logger
                    .Log(neuroDto)));
        }

        private void EnqueueBuffer(byte[] buffer)
        {
            foreach (var @byte in buffer)
            {
                _byteQueue.Enqueue(@byte);
            }
        }

        private void TrimQueue()
        {
            _isFirstTimeReceivedPacket = false;

            byte[] sequenceToFind = BitConverter.GetBytes(_packetDelimeter);
            int sequenceIndexer = 0;
            for (int i = 0; i < _packetSize; i++)
            {
                byte result = _byteQueue.Dequeue();
                sequenceIndexer = (result == sequenceToFind[sequenceIndexer]) ? sequenceIndexer += 1 : 0;

                if (sequenceIndexer == sequenceToFind.Length) break;
            }
        }

        private byte[] DequeuePacket()
        {
            byte[] packet = new byte[_packetSize];
            for (int i = 0; i < _packetSize; i++)
            {
                packet[i] = _byteQueue.Dequeue();
            }
            return packet;
        }
    }
}
