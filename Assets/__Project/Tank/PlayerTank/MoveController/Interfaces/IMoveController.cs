namespace Tank_Game
{
    public interface IMoveController
    {
        public void Move(float deltaTime, IPlayerTank playerTank);
    }
}