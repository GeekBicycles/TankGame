using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletFactory : IBulletFactory
    {
        private IPoolGameObject poolGameObject;
        public BulletFactory()
        {
            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.bulletPrefab);
            poolGameObject = new PoolGameObject(prefab, PrefabsNames.bulletName);
        }

        public IBullet GetBullet(Vector3 position, Quaternion rotation)
        {
            BulletModel bulletModel = new BulletModel(10, 5); //TODO заменить числа

            GameObject gameObject = poolGameObject.Pop();
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            BulletView bulletView = new BulletView(gameObject.transform);

            Bullet bullet = new Bullet(bulletModel, bulletView);

            bulletView.bulletBehaviour.bullet = bullet;

            return bullet;
        }

        public void Destroy(IBullet bullet)
        {
            poolGameObject.Push(bullet.view.transform.gameObject);
            bullet = null;
        }

    }
}
