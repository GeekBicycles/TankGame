using UnityEngine;

namespace Tank_Game
{
    public interface IBulletController
    {
        public void Fire(Vector3 position, Quaternion rotation, float force);
    }
}