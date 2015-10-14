namespace SmartHouseDll
{
    public interface IClimatControl : ITemperature
    {
        bool Auto { get; set; }
    }
}