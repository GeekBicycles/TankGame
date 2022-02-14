using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class BulletModel : IBullet
    {
        private float _speed;
        private int _damage;

        public BulletModel(float speed, int damage)
        {
            _speed = speed;
            _damage = damage;
        }

        public float Speed
        {
            get { return _speed; }
        }

        public int Damage
        {
            get { return _damage; }
        }
    }
}
