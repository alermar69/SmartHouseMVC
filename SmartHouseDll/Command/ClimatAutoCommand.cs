namespace SmartHouseDll
{
    public class ClimatAutoCommand : ICommand
    {
        public ClimatAutoCommand()
        {
            Name = "cl-Auto";
            Inform = "Вкл/Выкл автоматический режим климат-контроля";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            IClimatControl control = dataCommand.GetDevice() as IClimatControl;
            if (control != null)
            {
                control.Auto = !control.Auto;
            }
        }
        public void Undo(IDataCommand device)
        {
            Execute(device);
        }
    }
}