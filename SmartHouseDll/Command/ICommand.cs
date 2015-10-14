namespace SmartHouseDll
{
    public interface ICommand
    {
        string Name { get; }
        string Inform { get; }
        void Execute(IDataCommand dataCommand);
        void Undo(IDataCommand dataCommand);
    }
}