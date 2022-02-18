namespace Tank_Game
{
    public interface ILateUpdate : IUpdatable
    {
        public void LateUpdate(float deltaTime);
    }
}
