using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IPlayerTankModel
    {
        public float health { get; set; }
        public float speed { get; set; }
        public float maxBulletSpeed { get; set; }
        public float gravity { get; set; }

        public float timeToFire { get; set; }
        public float maxTimeToFire { get; set; }
    }
}