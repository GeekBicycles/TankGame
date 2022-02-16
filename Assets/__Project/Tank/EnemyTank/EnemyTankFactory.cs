using UnityEngine;

namespace Tank_Game
{
    public class EnemyTankFactory : IEnemyTankFactory
    {
        private IPoolGameObject poolGameObject;
        public EnemyTankFactory()
        {
            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.enemyTankPrefab);
            poolGameObject = new PoolGameObject(prefab, PrefabsNames.enemyTankName, PrefabsNames.enemyTankPoolName);
        }

        public IEnemyTank GetEnemyTank(Vector3 position, Quaternion rotation)
        {
            EnemyTankModel enemyTankModel = Resources.Load<EnemyTankModel>(ResourcesPathes.enemyTankModel);

            GameObject gameObject = poolGameObject.Pop();
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            EnemyTankView enemyTankView = new EnemyTankView(gameObject.transform);

            EnemyTank enemyTank = new EnemyTank(enemyTankModel, enemyTankView);
            enemyTank.timeToFire = enemyTankModel.maxTimeToFire;

            return enemyTank;
        }
    }
}