namespace SmartHouseDll
{
    public class IncrementLightCommand : ICommand
    {
        public IncrementLightCommand()
        {
            Name = "bright+";
            Inform = "”величить €ркость";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            ILight light = dataCommand.GetDevice() as ILight;
            if (light != null)
            {
                light.IncrementLight();
            }
        }

        public void Undo(IDataCommand dataCommand)
        {
            ILight light = dataCommand.GetDevice() as ILight;
            if (light != null)
            {
                light.DecrementLight();
            }
        }
    }
}