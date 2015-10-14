namespace SmartHouseDll
{
    public class AddConditionerCommand : ICommand
    {
        public AddConditionerCommand()
        {
            Name = "addCond";
            Inform = "Добавить кондиционер";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            Room room = dataCommand.GetRoom();
            if (room != null)
            {
                room.AddDevice(new Conditioner(dataCommand.DeviceData));
            }

        }
        public void Undo(IDataCommand dataCommand)
        {
            dataCommand.Home.DeleteDevice(dataCommand.RoomData, dataCommand.DeviceData);
        }
    }
}