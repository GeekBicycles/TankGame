namespace Tank_Game
{
    public interface IRotateController
    {
        public void Rotate(float deltaTime, IPlayerTank playerTank);
    }
}