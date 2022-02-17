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
            IBullet bullet = bulletFactory.GetBullet(position, rotation);
            bullet.view.bulletBehaviour.actionOnColliderEnter += OnCollisionEnter;
            bullet.view.rigidbody.AddForce(bullet.view.transform.forward.normalized * force);
            bulletList.bullets.Add(bullet);
            bullet.view.audioSource.Play();
        }

        private void OnCollisionEnter(IBullet bullet, Collision collision)
        {
            bullet.view.particleSystem.Play();
            bulletList.bullets.Remove(bullet);
            bulletFactory.Destroy(bullet);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            //_bulletView.Fire(_bulletModel.bullets[0].Speed * fixedDeltaTime);
        }
    }
}
