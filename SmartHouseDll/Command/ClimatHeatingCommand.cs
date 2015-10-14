namespace SmartHouseDll
{
    public class ClimatHeatingCommand : ICommand
    {
        public ClimatHeatingCommand()
        {
            Name = "cl-heat";
            Inform = "Вкл/Выкл отопление климат-контроля в ручном режиме";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            ClimatControl control = dataCommand.GetDevice() as ClimatControl;
            if (control != null)
            {
                control.OnOffHeat();
            }
        }
        public void Undo(IDataCommand device)
        {
            Execute(device);
        }
    }
}