using System;

namespace SmartHouseDll
{
    [Serializable]
    public class Conditioner : Device, ITemperature
    {
        private int _temperature;

        public Conditioner(string name) : base(name)
        {
            SetInitialTemperature();
        }

        public override string ToString()
        {
            return string.Format("{0}; Температура охлаждения - {1}", base.ToString(), Temperature);
        }

        #region Члены ITemperature

        public int Temperature
        {
            get { return _temperature; }
            protected set
            {

                if (value >= 18 && value <= 30)
                {
                    _temperature = value;
                }
            }
        }

        public void SetTemperature(int temperature)
        {
            Temperature = temperature;
        }

        public void IncrementTemperature()
        {
            Temperature++;
        }

        public void DecrementTemperature()
        {
            Temperature--;
        }

        public void SetInitialTemperature()
        {
            Temperature = 18;
        }

        #endregion
    }
}