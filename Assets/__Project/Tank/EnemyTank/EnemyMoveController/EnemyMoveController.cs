using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class EnemyMoveController : IEnemyMoveController
    {

        private ISpawnPosition spawnPosition;

        public EnemyMoveController()
        {
            spawnPosition = new SpawnPosition();
        }

        public void Move(IEnemyTank enemyTank)
        {
            if (enemyTank.view.navMeshAgent.remainingDistance <= enemyTank.view.navMeshAgent.stoppingDistance)
            {
                Vector3 nextPosition = spawnPosition.GetSpawnPosition();
                if (nextPosition == Vector3.zero) return;
                enemyTank.view.navMeshAgent.SetDestination(nextPosition);
            }
        }
    }
}
