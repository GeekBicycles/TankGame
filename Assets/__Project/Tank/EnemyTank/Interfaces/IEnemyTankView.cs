using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTankView
    {
        public Transform transform { get; set; }
        public Transform bulletSpawnTransform { get; set; }
    }
}