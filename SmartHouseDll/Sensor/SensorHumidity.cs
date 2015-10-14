using System;

namespace SmartHouseDll
{
    [Serializable]
    public class SensorHumidity : Sensor
    {
        private int _currentHumidity;

        public SensorHumidity(string name)
            : base(name)
        {
        }

        public event SensorDelegate ChangeHumidity;

        public int CurrentHumidity
        {
            get { return _currentHumidity; }
            set
            {
                _currentHumidity = value;
                if (ChangeHumidity != null)
                {
                    ChangeHumidity.Invoke(_currentHumidity);
                }
            }
        }
    }
}