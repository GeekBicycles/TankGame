using System;
using UnityEngine;

namespace Tank_Game
{
    public class BulletBehaviour : MonoBehaviour, IBulletBehaviour
    {
        public event Action<IBullet, Collision> actionOnColliderEnter;

        public IBullet bullet { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            actionOnColliderEnter?.Invoke(bullet, collision);
        }
    }
}
