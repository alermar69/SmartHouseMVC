namespace SmartHouseDll
{
    public interface IReader : IDataCommand  // интерфейс для считывания данных
    {
        void Read(); // метод для считывания данных
        void Help(RemoteControl remote, string message);
    }
}