using System;

namespace SmartHouseDll
{
    [Serializable]
    public abstract class Device : Authentication, IOnOff, IDevice
    {
        protected Device(string name)
            : base(name)
        {
            
        }

        #region Члены IOnOff

        public StateOnOff State { get; set; }

        public virtual void On()
        {
            State = StateOnOff.On;
        }

        public virtual void Off()
        {
            State = StateOnOff.Off;
        }
        #endregion        
      
        public override string ToString()
        {
            string state;
            if (State == StateOnOff.On)
            {
                state = "включен";
            }
            else
            {
                state = "выключен";
            }
            return String.Format("состояние - {0}", state);
        }
    }
}