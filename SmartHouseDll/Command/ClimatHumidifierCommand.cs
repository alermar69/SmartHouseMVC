namespace SmartHouseDll
{
    public class ClimatHumidifierCommand : ICommand
    {
        public ClimatHumidifierCommand()
        {
            Name = "cl-humid";
            Inform = "Вкл/Выкл увлажнитель климат-контроля в ручном режиме";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            ClimatControl control = dataCommand.GetDevice() as ClimatControl;
            if (control != null)
            {
                control.OnOffHumid();
            }
        }
        public void Undo(IDataCommand device)
        {
            Execute(device);
        }
    }
}