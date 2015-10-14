namespace SmartHouseDll
{
    public class AddHouseCinemaCommand : ICommand
    {
        public AddHouseCinemaCommand()
        {
            Name = "addCinema";
            Inform = "Добавить домашний кинотеатр";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            Room room = dataCommand.GetRoom();
            if (room != null)
            {
                room.AddDevice(new HouseCinema(dataCommand.DeviceData));
            }

        }
        public void Undo(IDataCommand dataCommand)
        {
            dataCommand.Home.DeleteDevice(dataCommand.RoomData, dataCommand.DeviceData);
        }
    }
}