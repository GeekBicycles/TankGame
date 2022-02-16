using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTankModel
    {
        public float health { get; set; }
        public float speed { get; set; }
        public float maxBulletSpeed { get; set; }

        public float maxAccuracy { get; set; }
        public float currentAccuracy { get; set; }
        public float changeAccuracy { get; set; }

        public float timeToFire { get; set; }
        public float maxTimeToFire { get; set; }

        public float bulletforce { get; set; }
    }
}
