namespace SmartHouseDll
{
    public class IncrementVolumeCommand : ICommand
    {
        public IncrementVolumeCommand()
        {
            Name = "vol+";
            Inform = "Увеличить громкость";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            IVolume volume = dataCommand.GetDevice() as IVolume;
            if (volume != null)
            {
                volume.IncrementVolume();
            }
        }

        public void Undo(IDataCommand dataCommand)
        {
            IVolume volume = dataCommand.GetDevice() as IVolume;
            if (volume != null)
            {
                volume.DecrementVolume();
            } 
        }
    }
}