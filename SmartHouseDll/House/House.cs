using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHouseDll
{
    [Serializable]
    public class House : Authentication
    {
        [NonSerialized]
        private RemoteControl _remote;

        public House(string name)
            : base(name)
        {
            Rooms = new Dictionary<string, Room>();
        }

        public IDictionary<string, Room> Rooms { get; private set; }


        public RemoteControl Remote
        {
            get { return _remote; }
            set { _remote = value; }
        }

        public void AddRoom(Room room)
        {
            if (!Rooms.ContainsKey(room.NameId))
            {
                 Rooms.Add(room.NameId, room);
            }          
        }
        public void DeleteRoom(string room)
        {
            if (Rooms.ContainsKey(room.ToLower()))
            {
                Rooms.Remove(room.ToLower());
            }
        }

        public void AddDevice(string room, Device device)
        {
            if(Rooms.ContainsKey(room.ToLower()))
                Rooms[room.ToLower()].AddDevice(device);
        }
        public void DeleteDevice(string room, string device)
        {
            if (Rooms.ContainsKey(room.ToLower()))
                Rooms[room.ToLower()].DeleteDevice(device);
        }

        public Room GetRoom(string room)
        {
            if (Rooms.ContainsKey(room.ToLower()))
            {
                return Rooms[room.ToLower()];
            }
            throw new Exception("Такой комнаты не существует!");
        }
        public Device GetDevice(string room, string device)
        {
            if (GetRoom(room).Devices.ContainsKey(device.ToLower()))
            {
                return GetRoom(room).GetDevice(device);
            }
            throw new Exception("Такого устройства не существует!");
        }

        public void ChangeNameRoom(string oldRoom, string newRoom)
        {
            Room room = GetRoom(oldRoom);
            room.Name = newRoom;
            DeleteRoom(oldRoom);
            AddRoom(room);
        }
        public void ChangeNameDevice(string room, string oldDevice, string newDevice)
        {
            Device device = GetDevice(room, oldDevice);
            device.Name = newDevice;
            DeleteDevice(room, oldDevice);
            AddDevice(room, device);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}