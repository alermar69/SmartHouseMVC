namespace SmartHouseDll
{
    public class DecrementVolumeCommand : ICommand
    {
        public DecrementVolumeCommand()
        {
            Name = "vol-";
            Inform = "Уменьшить громкость";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            IVolume volume = dataCommand.GetDevice() as IVolume;
            if (volume != null)
            {
                volume.DecrementVolume();
            }
        }

        public void Undo(IDataCommand dataCommand)
        {
            IVolume volume = dataCommand.GetDevice() as IVolume;
            if (volume != null)
            {
                volume.IncrementVolume();
            }
        }
    }
}