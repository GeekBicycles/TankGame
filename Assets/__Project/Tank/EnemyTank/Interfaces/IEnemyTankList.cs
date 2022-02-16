using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTankList
    {
        public List<IEnemyTank> enemyTanks { get; set; }
    }
}
