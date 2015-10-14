namespace SmartHouseDll
{
    public class AddTvCommand : ICommand
    {
        public AddTvCommand()
        {
            Name = "addTV";
            Inform = "Добавить телевизор";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
                Room room = dataCommand.GetRoom();
                if (room != null)
                {
                    room.AddDevice(new Tv(dataCommand.DeviceData));
                }
            
        }
        public void Undo(IDataCommand dataCommand)
        {
            dataCommand.Home.DeleteDevice(dataCommand.RoomData, dataCommand.DeviceData);
        }
    }
}