using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class BulletModel : IBullet
    {
        public float Speed { get; set; }
        public int Damage { get; set; }
        public Transform transform { get; set; }

        public BulletModel(float speed, int damage)
        {
            Speed = speed;
            Damage = damage;
        }
    }
}
