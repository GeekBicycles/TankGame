namespace Tank_Game
{
    public interface IMementoController
    {
        void AddMemento(IMemento memento);
        void Save();
        void Load(int index);
    }
}