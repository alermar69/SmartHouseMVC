namespace SmartHouseDll
{
    public class IncremenTemperCommand : ICommand
    {
        public IncremenTemperCommand()
        {
            Name = "t+";
            Inform = "Увеличить температуру";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            ITemperature control = dataCommand.GetDevice() as ITemperature;
            if (control != null)
            {
                control.IncrementTemperature();
            }
        }

        public void Undo(IDataCommand dataCommand)
        {
            ITemperature control = dataCommand.GetDevice() as ITemperature;
            if (control != null)
            {
                control.DecrementTemperature();
            }
        }
    }
}