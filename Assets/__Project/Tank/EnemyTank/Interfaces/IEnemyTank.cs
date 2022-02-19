namespace Tank_Game
{
    public interface IEnemyTank
    {
        public IEnemyTankModel model { get; }
        public IEnemyTankView view { get; }
        public float timeToFire { get; set; }
    }
}
