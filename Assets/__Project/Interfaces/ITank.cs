using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface ITank
    {
        public float health { get; set; }
        public float speed { get; set; }
        public float maxBulletSpeed { get; set; }
        public Transform transform { get; set; }
    }
}