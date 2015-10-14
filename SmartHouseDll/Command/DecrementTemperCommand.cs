namespace SmartHouseDll
{
    public class DecrementTemperCommand : ICommand
    {
        public DecrementTemperCommand()
        {
            Name = "t-";
            Inform = "Уменьшить температуру";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            ITemperature control = dataCommand.GetDevice() as ITemperature;
            if (control != null)
            {
                control.DecrementTemperature();
            }
        }

        public void Undo(IDataCommand dataCommand)
        {
            ITemperature control = dataCommand.GetDevice() as ITemperature;
            if (control != null)
            {
                control.IncrementTemperature();
            }
        }
    }
}