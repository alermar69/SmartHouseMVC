using System;

namespace SmartHouseDll
{
    public delegate void SensorDelegate(int value);

    [Serializable]
    public abstract class  Sensor : Authentication
    {
        public Sensor(string name) : base(name)
        {
        }
    }
}