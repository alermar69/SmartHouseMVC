using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouseDll
{
    [Serializable]
    public class HouseCinema : Device, IVolume, ILight
    {
        public Dictionary<string, IHouseCinema> Devices { get; private set; }

        public HouseCinema(string name) : base(name)
        {
            Devices = new Dictionary<string, IHouseCinema>();
        }
        
        public void AddDevice(IHouseCinema devHouseCinema)
        {
            Device device = devHouseCinema as Device;

            if (device != null)
            {
                Devices.Add(device.Name, devHouseCinema);
            }
        }

        public void OnOffDvd()
        {
            if (State == StateOnOff.On)
            {
                IOnOff onOff = GetDvd();
                if (onOff != null)
                {
                    if (onOff.State == StateOnOff.On)
                    {
                        onOff.Off();
                    }
                    else
                    {
                        onOff.On();
                    }
                }
            }
            else
            {
                throw new Exception("Нужно сначала включить домашний кинотеатр");
            }
        }

        public override void On()
        {
            base.On();
            Tv tv = GetTv();
            if (tv != null)
            {
                tv.On();
            }
        }
        public override void Off()
        {
            base.Off();
            foreach (IHouseCinema dev in Devices.Values)
            {
                if (dev is IOnOff)
                {
                    ((IOnOff)dev).Off();
                } 
            }
        }


        public int Volume { get; private set; }

        public void IncrementVolume()
        {
            IVolume tv = GetTv();
            if (tv != null)
            {
                tv.IncrementVolume();
            }
        }

        public void DecrementVolume()
        {
            IVolume tv = GetTv();
            if (tv != null)
            {
                tv.DecrementVolume();
            }
        }

        private Tv GetTv()
        {
            var tv = from c in Devices.Values where c is Tv select c as Tv;
            if (tv.Any())
            {
                return tv.First();
            }
            return null;
        }
        private DVDPlayer GetDvd()
        {
            var dvd = from c in Devices.Values where c is DVDPlayer select c as DVDPlayer;
            if (dvd.Any())
            {
                return dvd.First();
            }
            return null;
        }

        public LightsState Brightness { get; set; }
        public void IncrementLight()
        {
            ILight tv = GetTv();
            if (tv != null)
            {
                tv.IncrementLight();
            }
        }

        public void DecrementLight()
        {
            ILight tv = GetTv();
            if (tv != null)
            {
                tv.DecrementLight();
            }
        }
    }
}
