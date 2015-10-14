namespace SmartHouseDll
{
    public class AddHumidifierCommand : ICommand
    {
        public AddHumidifierCommand()
        {
            Name = "addHumid";
            Inform = "Добавить увлажнитель";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            Room room = dataCommand.GetRoom();
            if (room != null)
            {
                room.AddDevice(new Humidifier(dataCommand.DeviceData));
            }

        }
        public void Undo(IDataCommand dataCommand)
        {
            dataCommand.Home.DeleteDevice(dataCommand.RoomData, dataCommand.DeviceData);
        }
    }
}