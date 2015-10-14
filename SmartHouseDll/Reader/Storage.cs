namespace SmartHouseDll
{
    abstract public class Storage : IDataCommand
    {
        protected Storage(House home)
        {
            Home = home;
        }

        public House Home { get; protected set; }
        public string CommandData { get; set; }
        public string RoomData { get; set; }
        public string DeviceData { get; set; }
        public string Value { get; set; }

        public Device GetDevice()
        {
            return Home.GetDevice(RoomData, DeviceData);
        }
        public Room GetRoom()
        {
            return Home.GetRoom(RoomData);
        }
        public void Clear()
        {
            CommandData = RoomData = DeviceData = null;
        }
    }
}