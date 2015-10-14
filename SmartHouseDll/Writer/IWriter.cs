namespace SmartHouseDll
{
    public interface IWriter // интерфейс за записи данных
    {
        void Write(IDataCommand dataCommand); // метод записи данных
    }
}