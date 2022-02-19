﻿using System.Collections.Generic;

namespace Tank_Game
{
    public sealed class EnemyTankList : IEnemyTankList
    {
        public List<IEnemyTank> enemyTanks { get; }
        public IEnemyTank current { get; set; }
        public EnemyTankList()
        {
            enemyTanks = new List<IEnemyTank>();
            current = null;
        }

        public void Remove(IEnemyTank enemyTank)
        {
            enemyTanks.Remove(enemyTank);
            if (current == enemyTank) current = null;
        }
    }
}