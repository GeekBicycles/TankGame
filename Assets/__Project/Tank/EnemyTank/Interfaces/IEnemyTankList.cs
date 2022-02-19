using System.Collections.Generic;

namespace Tank_Game
{
    public interface IEnemyTankList
    {
        public List<IEnemyTank> enemyTanks { get; }
        public IEnemyTank current { get; set; }
        public void Remove(IEnemyTank enemyTank);
    }
}
