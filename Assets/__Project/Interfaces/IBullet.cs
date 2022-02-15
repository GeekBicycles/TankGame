using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IBullet
    {
        public float Speed { get; set;  }
        public int Damage { get; set; }

        public Transform transform { get; set; }
    }
}
