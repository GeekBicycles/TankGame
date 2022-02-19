using UnityEngine;

namespace Tank_Game
{
    public sealed class EnemyTankSpawner : IEnemyTankSpawner
    {
        private IEnemyTankFactory _enemyTankFactory;
        private ISpawnPosition _spawnPosition;

        public EnemyTankSpawner(IEnemyTankFactory enemyTankFactory)
        {
            _enemyTankFactory = enemyTankFactory;
            _spawnPosition = new SpawnPosition();
        }

        public IEnemyTank Spawn()
        {
            Vector3 position = _spawnPosition.GetSpawnPosition();
            if (position == Vector3.zero) return null;

            IEnemyTank enemyTank = _enemyTankFactory.GetEnemyTank(position, Quaternion.identity);
            enemyTank.view.transform.position = position;

            return enemyTank;
        }

    }
}
