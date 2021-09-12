using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroenaDeviceReader.Models
{
    public class NeuroDto
    {
        public float TimeStamp { get; set; }
        public float Acc1X { get; set; }
        public float Acc1Y { get; set; }
        public float Acc1Z { get; set; }
        public float Acc2X { get; set; }
        public float Acc2Y { get; set; }
        public float Acc2Z { get; set; }
        public float Gyro1X { get; set; }
        public float Gyro1Y { get; set; }
        public float Gyro1Z { get; set; }
        public float Gyro2X { get; set; }
        public float Gyro2Y { get; set; }
        public float Gyro2Z { get; set; }
        public float Emg1 { get; set; }
        public float Emg2 { get; set; }
    }
}
