using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IBullet
    {
        public float Speed { get; }
        public int Damage { get; }
    }
}
