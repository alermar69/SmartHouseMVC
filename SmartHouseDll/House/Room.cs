using System;
using System.Collections.Generic;

namespace SmartHouseDll
{
    [Serializable]
    public class Room : Authentication
    {
        public Room(string name)
            : base(name)
        {
            Devices = new Dictionary<string, Device>();
        }

        public IDictionary<string, Device> Devices { get; private set; }


        public void AddDevice(Device device)
        {
            if (!Devices.ContainsKey(device.Name.ToLower()))
            {
                Devices.Add(device.Name.ToLower(), device);
            }
        }
        public void DeleteDevice(string device)
        {
            if (Devices.ContainsKey(device.ToLower()))
            {
                Devices.Remove(device.ToLower());
            }
        }

        public Device GetDevice(string device)
        {
            if (Devices.ContainsKey(device.ToLower()))
                return Devices[device.ToLower()];
            throw new Exception("Такого устройства не существует!");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}