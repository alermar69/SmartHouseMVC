using System;
using System.Collections.Generic;

namespace SmartHouseDll
{
    [Serializable]
    public class OnCommand : ICommand
    {
        public OnCommand()
        {
            Name = "on";
            Inform = "Включить устройство";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            IOnOff onOff = dataCommand.GetDevice();
            if (onOff != null)
            {
                onOff.On();
            }
        }
        public void Undo(IDataCommand dataCommand)
        {
            IOnOff onOff = dataCommand.GetDevice();
            if (onOff != null)
            {
                onOff.Off();
            } 
        }
    }
}