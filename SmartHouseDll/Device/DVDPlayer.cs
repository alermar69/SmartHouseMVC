using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseDll
{
    [Serializable]
    public class DVDPlayer : Device, IHouseCinema
    {
        public DVDPlayer(string name) : base(name)
        {
        }

        #region Члены IHouseCinema

        public void Connection(HouseCinema houseCinema)
        {
            if (houseCinema != null)
                houseCinema.AddDevice(this);
        }

        #endregion


    }
}
