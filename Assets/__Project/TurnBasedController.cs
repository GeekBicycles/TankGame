using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class TurnBasedController : IUpdate
    {
        public TurnBasedController(PlayerTankController playerTankController, EnemyTankController enemyTankController, BulletsData bulletsData)
        {

        }

        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}

