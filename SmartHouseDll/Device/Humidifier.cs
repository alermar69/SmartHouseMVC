using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseDll
{
    [Serializable]
    public class Humidifier : Device
    {
        public Humidifier(string name)
            : base(name)
        {
        }
    }
}
