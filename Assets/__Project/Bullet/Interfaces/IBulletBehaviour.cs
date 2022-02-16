using System;
using UnityEngine;

namespace Tank_Game
{
    public interface IBulletBehaviour
    {
        public event Action<IBullet, Collision> actionOnColliderEnter;
        public IBullet bullet { get; set; }
    }
}