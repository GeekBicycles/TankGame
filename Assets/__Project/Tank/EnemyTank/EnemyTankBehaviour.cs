using System;
using UnityEngine;

namespace Tank_Game
{
    public class EnemyTankBehaviour : MonoBehaviour, IEnemyTankBehaviour
    {
        public event Action<IEnemyTank, Collision> actionOnColliderEnter;
        public IEnemyTank enemyTank { get; set; }

        public void OnCollisionEnter(Collision collision)
        {
            actionOnColliderEnter?.Invoke(enemyTank, collision);
        }
    }
}
