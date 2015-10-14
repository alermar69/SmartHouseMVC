using System;

namespace SmartHouseDll
{
    [Serializable]
    public class Lamp : Device, ILight
    {

        #region „лены ILight

        public Lamp(string name) : base(name)
        {
        }

        public LightsState Brightness { get; set; }

        public void IncrementLight()
        {
            Brightness++;
        }

        public void DecrementLight()
        {
            Brightness = (LightsState)((byte) Brightness - 1);
        }

        #endregion

        public override string ToString()
        {
            string mode;
            if (Brightness == LightsState.Low)
            {
                mode = "слаба€";
            }
            else if (Brightness == LightsState.Medium)
            {
                mode = "средн€€";
            }
            else
            {
                mode = "высока€";
            }
            return string.Format("{0}; яркость - {1}", base.ToString(), mode);
        }
    }
}