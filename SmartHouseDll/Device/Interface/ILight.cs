using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseDll
{
    public interface ILight 
    {
        LightsState Brightness { get; set; }
        void IncrementLight();
        void DecrementLight();
    }
}
