using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IBulletModel
    {
        public float Speed { get; set; }
        public int Damage { get; set; }
    }
}
