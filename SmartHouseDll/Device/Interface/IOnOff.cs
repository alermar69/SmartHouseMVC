namespace SmartHouseDll
{
    public interface IOnOff 
    {
        StateOnOff State { get; set; }
        void On();
        void Off();
    }
}