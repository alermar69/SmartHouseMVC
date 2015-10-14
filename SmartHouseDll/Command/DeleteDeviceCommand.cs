namespace SmartHouseDll
{
    public class DeleteDeviceCommand : ICommand
    {
        public DeleteDeviceCommand()
        {
            Name = "delDev";
            Inform = "Удалить устройство";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            Device dev = dataCommand.GetDevice();
            if (dev != null)
            {
                Room room = dataCommand.GetRoom();
                if (room != null)
                {
                    room.DeleteDevice(dataCommand.DeviceData);
                }
            }

        }
        public void Undo(IDataCommand dataCommand)
        {
            Device dev = dataCommand.GetDevice();
            if (dev != null)
            {
                Room room = dataCommand.GetRoom();
                if (room != null)
                {
                    room.AddDevice(dev);
                }
            }
        }
    }
}