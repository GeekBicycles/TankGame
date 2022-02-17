using System;
using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTankBehaviour
    {
        IEnemyTank enemyTank { get; set; }

        event Action<IEnemyTank, Collision> actionOnColliderEnter;

        void OnCollisionEnter(Collision collision);
    }
}