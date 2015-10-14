namespace SmartHouseDll
{
    public interface IDataCommand 
    {
        House Home { get; }
        string CommandData {get; set; }
        string RoomData { get; set; }
        string DeviceData { get; set; }
        string Value { get; set; }

        Device GetDevice();
        Room GetRoom();
        void Clear();
    }
}