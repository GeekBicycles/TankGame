using System;

namespace Tank_Game
{
    public interface IEnemyTank : ICloneable
    {
        public IEnemyTankModel model { get; }
        public IEnemyTankView view { get; }
        public float timeToFire { get; set; }
        public float health { get; set; }
    }
}
