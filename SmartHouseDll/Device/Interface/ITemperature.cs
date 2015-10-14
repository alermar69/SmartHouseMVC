using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseDll
{
    public interface ITemperature
    {
        int Temperature { get;}
        void SetTemperature(int temperat);
        void IncrementTemperature();
        void DecrementTemperature();

        void SetInitialTemperature();
    }
}
