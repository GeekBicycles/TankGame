using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletController : IBulletController
    {
        private IBulletList _bulletList;
        private IBulletFactory _bulletFactory;

        public BulletController()
        {
            _bulletFactory = new BulletFactory();
            _bulletList = new BulletList();
        }

        public void Fire(Vector3 position, Quaternion rotation, float force)
        {
            NewBullet(position, rotation, force);
        }

        private void NewBullet(Vector3 position, Quaternion rotation, float force)
        {
            IBullet bullet = _bulletFactory.GetBullet(position, rotation);
            bullet.view.bulletBehaviour.actionOnColliderEnter += OnCollisionEnter;
            bullet.view.rigidbody.isKinematic = false;
            bullet.view.rigidbody.AddForce(bullet.view.transform.forward.normalized * force);
            _bulletList.bullets.Add(bullet);
            bullet.view.audioSource.Play();
        }

        private void RemoveBullet(IBullet bullet)
        {
            bullet.view.particleSystem.Play();
            _bulletList.bullets.Remove(bullet);
            bullet.view.bulletBehaviour.actionOnColliderEnter -= OnCollisionEnter;
            bullet.view.rigidbody.isKinematic = true;
            _bulletFactory.Destroy(bullet);
        }

        private void OnCollisionEnter(IBullet bullet, Collision collision)
        {
            if (!collision.collider.CompareTag(GameTags.bullet))
            {
                RemoveBullet(bullet);
            }
        }
    }
}
