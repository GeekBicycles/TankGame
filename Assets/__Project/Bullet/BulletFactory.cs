using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletFactory : IBulletFactory
    {
        private IPoolGameObject _poolGameObject;

        public BulletFactory()
        {
            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.BULLET_PREFAB);
            _poolGameObject = new PoolGameObject(prefab, PrefabsNames.BULLET, PrefabsNames.BULLET_POOL);
        }

        public IBullet GetBullet(Vector3 position, Quaternion rotation)
        {
            BulletModel bulletModel = Resources.Load<BulletModel>(ResourcesPathes.BULLET_MODEL);

            GameObject gameObject = _poolGameObject.Pop();
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            BulletView bulletView = new BulletView(gameObject.transform);

            Bullet bullet = new Bullet(bulletModel, bulletView);

            bulletView.bulletBehaviour.bullet = bullet;

            return bullet;
        }

        public void Destroy(IBullet bullet)
        {
            _poolGameObject.Push(bullet.view.transform.gameObject);
            bullet = null;
        }

    }
}
