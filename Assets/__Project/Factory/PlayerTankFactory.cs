using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class TankFactory
    {
        public ITank GetPlayerTankModel()
        {
            return Resources.Load<PlayerTankModel>(ResourcesPathes.playerTankModel);
        }

        public IEnemyTank GetEnemyTankModel()
        {
            return Resources.Load<EnemyTankModel>(ResourcesPathes.enemyTankModel);
        }
    }
}
