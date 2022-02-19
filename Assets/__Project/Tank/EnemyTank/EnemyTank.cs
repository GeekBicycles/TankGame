namespace Tank_Game
{
    public sealed class EnemyTank : IEnemyTank
    {
        public IEnemyTankModel model { get; }
        public IEnemyTankView view { get; }
        public float timeToFire { get; set; }

        public EnemyTank(IEnemyTankModel model, IEnemyTankView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
