namespace Tank_Game
{
    public interface IFireController
    {
        public bool Fire(float deltaTime, IPlayerTank playerTank, float bulletForce);
    }
}