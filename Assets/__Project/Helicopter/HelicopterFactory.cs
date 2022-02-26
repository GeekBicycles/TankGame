using UnityEngine;

namespace Tank_Game
{
    public class HelicopterFactory : IHelicopterFactory
    {
        private IPoolGameObject _poolGameObject;

        public HelicopterFactory()
        {
            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.ENEMY_HELICOPTER_PREFAB);
            _poolGameObject = new PoolGameObject(prefab, PrefabsNames.ENEMY_HELICOPTER, PrefabsNames.ENEMY_HELICOPTER_POOL);
        }

        public IHelicopter GetHelicopter(Vector3 position, Quaternion rotation)
        {
            HelicopterModel helicopterModel = Resources.Load<HelicopterModel>(ResourcesPathes.ENEMY_HELICOPTER_MODEL);
            GameObject gameObject = _poolGameObject.Pop();
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            HelicopterView helicopterView = new HelicopterView(gameObject.transform);
            Helicopter helicopter = new Helicopter(helicopterModel, helicopterView);
            helicopterView.helicopterBehaviour.helicopter = helicopter;

            return helicopter;
        }

        public void Destroy(IHelicopter helicopter)
        {
            _poolGameObject.Push(helicopter.view.transform.gameObject);
            helicopter = null;
        }
    }
}
