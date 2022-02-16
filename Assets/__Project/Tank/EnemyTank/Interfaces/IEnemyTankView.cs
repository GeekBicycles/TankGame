using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tank_Game
{
    public interface IEnemyTankView
    {
        public Transform transform { get; set; }
        public Transform bulletSpawnTransform { get; set; }
        public NavMeshAgent navMeshAgent { get; set; }
    }
}
