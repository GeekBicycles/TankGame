using System.Collections.Generic;

namespace Tank_Game
{
    public sealed class EnemyTankList : IEnemyTankList
    {
        public List<IEnemyTank> enemyTanks { get; }

        public EnemyTankList()
        {
            enemyTanks = new List<IEnemyTank>();
        }
    }
}