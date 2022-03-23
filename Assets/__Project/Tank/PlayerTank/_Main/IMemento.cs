namespace Tank_Game
{
    public interface IMemento
    {
        void LoadMemento(int index);
        void LoadPrev();
        void SaveMemento();
    }
}