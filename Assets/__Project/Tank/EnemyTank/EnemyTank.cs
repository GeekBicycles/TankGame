namespace Tank_Game
{
    public sealed class EnemyTank : IEnemyTank
    {
        public IEnemyTankModel model { get; }
        public IEnemyTankView view { get; }
        public float timeToFire { get; set; }
        public float health { get; set; }

        public EnemyTank(IEnemyTankModel model, IEnemyTankView view)
        {
            this.model = model;
            this.view = view;
            health = model.health;
            timeToFire = model.maxTimeToFire;
        }

        public object Clone()
        {
            IEnemyTankModel newModel = model;
            IEnemyTankView newView = (IEnemyTankView)view.Clone();
            return new EnemyTank(newModel, newView);
        }
    }
}
