using UnityEngine;

namespace Tank_Game
{
    public interface IBulletFactory
    {
        public IBullet GetBullet(Vector3 position, Quaternion rotation);

        public void Destroy(IBullet bullet);
    }
}