using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class EnemyTankView : IEnemyTankView
    {
        public Transform transform { get; set; }

        public Transform bulletSpawnTransform { get; set; }

        public EnemyTankView(Transform transform)
        {
            this.transform = transform;
            bulletSpawnTransform = transform.GetComponentInChildren<IBulletSpawnTransform>().bulletSpawnTransform;
        }
    }
}
