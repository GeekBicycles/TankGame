using UnityEngine;

namespace Tank_Game
{
    public class EnemyTankFactory : IEnemyTankFactory
    {
        private IPoolGameObject _poolGameObject;
        private IEnemyTank enemyTankPrototype;
        public EnemyTankFactory()
        {
            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.ENEMY_TANK_PREFAB);
            _poolGameObject = new PoolGameObject(prefab, PrefabsNames.ENEMY_TANK, PrefabsNames.ENEMY_TANK_POOL);
            enemyTankPrototype = null;
        }

        private IEnemyTank GetNewEnemyTank(Vector3 position, Quaternion rotation)
        {
            EnemyTankModel enemyTankModel = Resources.Load<EnemyTankModel>(ResourcesPathes.ENEMY_TANK_MODEL);

            GameObject gameObject = _poolGameObject.Pop();
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            EnemyTankView enemyTankView = new EnemyTankView(gameObject.transform);

            EnemyTank enemyTank = new EnemyTank(enemyTankModel, enemyTankView);
            enemyTankView.enemyTankBehaviour.enemyTank = enemyTank;

            return enemyTank;
        }

        public IEnemyTank GetEnemyTank(Vector3 position, Quaternion rotation)
        {
            IEnemyTank enemyTank;

            if (enemyTankPrototype == null)
            {
                enemyTank = GetNewEnemyTank(position, rotation);
                enemyTankPrototype = (IEnemyTank)enemyTank.Clone();
            }
            else
            {
                enemyTank = (IEnemyTank)enemyTankPrototype.Clone();
                GameObject gameObject = _poolGameObject.Pop();
                gameObject.transform.position = position;
                gameObject.transform.rotation = rotation;
                enemyTank.view.AttachTransform(gameObject.transform, enemyTank);
            }

            return enemyTank;
        }
        public void Destroy(IEnemyTank enemyTank)
        {
            _poolGameObject.Push(enemyTank.view.transform.gameObject);
            enemyTank = null;
        }
    }
}