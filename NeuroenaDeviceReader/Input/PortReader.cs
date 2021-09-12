using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NeuroenaDeviceReader.Input
{
    public class PortReader : IPortReader
    {
        private readonly SerialPort _port;
        public event EventHandler<byte[]> OnPacketReceived;
        public PortReader(string readPortName)
        {
            _port = new SerialPort(readPortName, 1000, Parity.None, 8, StopBits.One);
            _port.DataReceived += Port_DataReceived;
        }

        public void StartRead()
        {
            _port.Open();
            Console.ReadLine();
        }
        void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[_port.BytesToRead];
            _port.Read(buffer, 0, buffer.Length);
            OnPacketReceived?.Invoke(this, buffer);
        }
    }
}
