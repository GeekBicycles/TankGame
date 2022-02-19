namespace Tank_Game
{
    public interface IFireController
    {
        public void Fire(float deltaTime, IPlayerTank playerTank, float bulletForce);
    }
}