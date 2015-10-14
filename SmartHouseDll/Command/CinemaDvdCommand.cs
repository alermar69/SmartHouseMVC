namespace SmartHouseDll
{
    public class CinemaDvdCommand : ICommand
    {
        public CinemaDvdCommand()
        {
            Name = "cin-dvd";
            Inform = "Вкл/Выкл DVD";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            HouseCinema control = dataCommand.GetDevice() as HouseCinema;
            if (control != null)
            {
                control.OnOffDvd();
            }
        }
        public void Undo(IDataCommand device)
        {
            Execute(device);
        }
    }
}