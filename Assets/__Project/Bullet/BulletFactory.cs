using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletFactory : IBulletFactory
    {

        public BulletFactory()
        {
        }

        public IBullet GetBullet(Vector3 position, Quaternion rotation)
        {
            BulletModel bulletModel = new BulletModel(10, 5); //TODO �������� �����

            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.bulletPrefab);
            GameObject gameObject = GameObject.Instantiate(prefab, position, rotation);
            gameObject.name = PrefabsNames.bulletName;
            BulletView bulletView = new BulletView(gameObject.transform);

            Bullet bullet = new Bullet(bulletModel, bulletView);

            bulletView.bulletBehaviour.bullet = bullet;


            return bullet;
        }

        public void Destroy(IBullet bullet)
        {
            GameObject.Destroy(bullet.view.transform.gameObject, 0.2f);
            bullet = null;
        }

    }
}
