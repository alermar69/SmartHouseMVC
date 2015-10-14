namespace SmartHouseDll
{
    public class DecrementLightCommand : ICommand
    {
        public DecrementLightCommand()
        {
            Name = "bright-";
            Inform = "”меньшить €ркость";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            ILight light = dataCommand.GetDevice() as ILight;
            if (light != null)
            {
                light.DecrementLight();
            }
        }

        public void Undo(IDataCommand dataCommand)
        {
            ILight light = dataCommand.GetDevice() as ILight;
            if (light != null)
            {
                light.IncrementLight();
            }
        }
    }
}