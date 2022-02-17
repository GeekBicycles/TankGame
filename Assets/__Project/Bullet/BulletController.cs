using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletController : IFixedUpdate, IBulletController
    {
        private IBulletList bulletList;
        private IBulletFactory bulletFactory;

        public BulletController()
        {
            bulletFactory = new BulletFactory();
            bulletList = new BulletList();
        }

        public void Fire(Vector3 position, Quaternion rotation, float force)
        {
            NewBullet(position, rotation, force);
        }

        private void NewBullet(Vector3 position, Quaternion rotation, float force)
        {
            IBullet bullet = bulletFactory.GetBullet(position, rotation);
            bullet.view.bulletBehaviour.actionOnColliderEnter += OnCollisionEnter;
            bullet.view.rigidbody.isKinematic = false;
            bullet.view.rigidbody.AddForce(bullet.view.transform.forward.normalized * force);
            bulletList.bullets.Add(bullet);
        }

        private void RemoveBullet(IBullet bullet)
        {
            bulletList.bullets.Remove(bullet);
            bullet.view.bulletBehaviour.actionOnColliderEnter -= OnCollisionEnter;
            bullet.view.rigidbody.isKinematic = true;
            bulletFactory.Destroy(bullet);
        }

        private void OnCollisionEnter(IBullet bullet, Collision collision)
        {
            if (!collision.collider.CompareTag(GameTags.bullet))
            {
                RemoveBullet(bullet);
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            //_bulletView.Fire(_bulletModel.bullets[0].Speed * fixedDeltaTime);
        }
    }
}
