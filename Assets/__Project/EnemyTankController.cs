using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class EnemyTankController : IUpdate
    {
        public EnemyTankController(IEnemyTank enemyTank, BulletFactory bulletFactory)
        {

        }

        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
