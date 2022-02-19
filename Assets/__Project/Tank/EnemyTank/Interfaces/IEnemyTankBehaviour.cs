using System;
using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTankBehaviour
    {
        public event Action<IEnemyTank, Collision> actionOnColliderEnter;

        IEnemyTank enemyTank { get; set; }

        public void OnCollisionEnter(Collision collision);
    }
}