using UnityEngine;

namespace Tank_Game
{
    public class EnemyTankFactory : IEnemyTankFactory
    {
        public IEnemyTank GetEnemyTank(Vector3 position, Quaternion rotation)
        {
            EnemyTankModel enemyTankModel = Resources.Load<EnemyTankModel>(ResourcesPathes.enemyTankModel);

            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.enemyTankPrefab);
            GameObject gameObject = GameObject.Instantiate(prefab, position, rotation);
            gameObject.name = PrefabsNames.enemyTankName;
            EnemyTankView enemyTankView = new EnemyTankView(gameObject.transform);

            EnemyTank enemyTank = new EnemyTank(enemyTankModel, enemyTankView);
            enemyTank.timeToFire = enemyTankModel.maxTimeToFire;

            return enemyTank;
        }
    }
}