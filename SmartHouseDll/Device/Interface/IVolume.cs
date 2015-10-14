using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseDll
{
    public interface IVolume 
    {
        int Volume { get;}
        void IncrementVolume();
        void DecrementVolume();
    }
}
