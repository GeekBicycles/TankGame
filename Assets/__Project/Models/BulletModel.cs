using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class BulletModel : IBullet
    {
        public float Speed { get; }
        public int Damage { get; }

        public BulletModel(float speed, int damage)
        {
            Speed = speed;
            Damage = damage;
        }
    }
}
