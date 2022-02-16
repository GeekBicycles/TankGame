using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class TankSpawner : ITankSpawner
    {
        private IEnemyTankFactory enemyTankFactory;
        private ISpawnPosition spawnPosition;

        public TankSpawner(IEnemyTankFactory enemyTankFactory)
        {
            this.enemyTankFactory = enemyTankFactory;
            this.spawnPosition = new SpawnPosition();
        }

        public IEnemyTank Spawn()
        {
            Vector3 position = spawnPosition.GetSpawnPosition();
            if (position == Vector3.zero) return null;

            IEnemyTank enemyTank = enemyTankFactory.GetEnemyTank(position, Quaternion.identity);
            enemyTank.view.transform.position = position;

            return enemyTank;
        }

    }
}
