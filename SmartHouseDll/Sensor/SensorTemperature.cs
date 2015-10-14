using System;

namespace SmartHouseDll
{
    [Serializable]
    public class SensorTemperature : Sensor
    {
        public SensorTemperature(string name)
            : base(name)
        {
        }

        public event SensorDelegate ChangeTemperature;

        private int _currentTemperature;
        public int CurrentTemperature
        {
            get { return _currentTemperature; }
            set
            {
                _currentTemperature = value;
                if (ChangeTemperature != null)
                {
                    ChangeTemperature.Invoke(_currentTemperature);
                }
            }
        }

    }
}