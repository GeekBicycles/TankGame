using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tank_Game
{
    public class EnemyTankView : IEnemyTankView
    {
        public Transform transform { get; set; }

        public Transform bulletSpawnTransform { get; set; }

        public Collider collider { get; set; }

        public NavMeshAgent navMeshAgent { get; set; }

        public Transform _pursuitPoint { get; set; }


        public EnemyTankView(Transform transform)
        {
            this.transform = transform;
            bulletSpawnTransform = transform.GetComponentInChildren<IBulletSpawnTransform>().bulletSpawnTransform;
            navMeshAgent = transform.GetComponentInChildren<EnemyTankBehaviour>().navMeshAgent;
        }
    }
}
