using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tank_Game
{
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyTankBehaviour : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public Transform[] waypoints;
        int m_CurrentWaypointIndex;

        public class PlayerTankBehavior : MonoBehaviour
        {
            public EnemyTankController EnemyTankController;

            public void OnTriggerEnter(Collider other)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
