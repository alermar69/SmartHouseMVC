using System;

namespace SmartHouseDll
{
    [Serializable]
    public class OffCommand : ICommand
    {
        public OffCommand()
        {
            Name = "off";
            Inform = "Выключить устройство";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            IOnOff onOff = dataCommand.GetDevice() as IOnOff;
            if (onOff != null)
            {
                onOff.Off();
            }
        }

        public void Undo(IDataCommand dataCommand)
        {
            IOnOff onOff = dataCommand.GetDevice() as IOnOff;
            if (onOff != null)
            {
                onOff.On();
            }
        }
    }
}