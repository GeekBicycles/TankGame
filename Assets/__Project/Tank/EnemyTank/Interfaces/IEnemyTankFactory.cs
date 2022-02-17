﻿using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTankFactory
    {
        public IEnemyTank GetEnemyTank(Vector3 position, Quaternion rotation);
        void Destroy(IEnemyTank enemyTank);
    }
}