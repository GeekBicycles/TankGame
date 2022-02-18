using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletFactory : IBulletFactory
    {
        private IPoolGameObject _poolGameObject;

        public BulletFactory()
        {
            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.bulletPrefab);
            _poolGameObject = new PoolGameObject(prefab, PrefabsNames.bulletName, PrefabsNames.bulletPoolName);
        }

        public IBullet GetBullet(Vector3 position, Quaternion rotation)
        {
            BulletModel bulletModel = Resources.Load<BulletModel>(ResourcesPathes.bulletModel);

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
