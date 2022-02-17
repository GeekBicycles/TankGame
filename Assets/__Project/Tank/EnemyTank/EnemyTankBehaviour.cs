using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tank_Game
{
    public class EnemyTankBehaviour : MonoBehaviour, IEnemyTankBehaviour
    {
        public event Action<IEnemyTank, Collision> actionOnColliderEnter;
        public IEnemyTank enemyTank { get; set; }
        public NavMeshAgent navMeshAgent;
        public Transform[] waypoints;
        int m_CurrentWaypointIndex;

        public void OnCollisionEnter(Collision collision)
        {
            actionOnColliderEnter?.Invoke(enemyTank, collision);
        }
    }
}
