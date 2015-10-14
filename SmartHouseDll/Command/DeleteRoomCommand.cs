namespace SmartHouseDll
{
    public class DeleteRoomCommand : ICommand
    {
        public DeleteRoomCommand()
        {
            Name = "delRom";
            Inform = "Удалить комнату";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            dataCommand.Home.DeleteRoom(dataCommand.RoomData);         
        }
        public void Undo(IDataCommand dataCommand)
        {
            dataCommand.Home.AddRoom(new Room(dataCommand.RoomData));
        }
    }
}