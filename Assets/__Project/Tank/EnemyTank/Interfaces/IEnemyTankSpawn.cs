using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTankSpawn
    {
        void SpawnPoint(IEnemyTank enemyTank);
    }
}
