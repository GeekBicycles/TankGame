using System;
using UnityEngine;
namespace Tank_Game
{
    public class PlayerTankBehavior : MonoBehaviour, IDamagable
    {
        public event Action<IPlayerTank, Collision> actionOnColliderEnter;
        public event Action<IPlayerTank, float> actionOnSetDamage;

        public IPlayerTank playerTank { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            actionOnColliderEnter?.Invoke(playerTank, collision);
        }

        public void SetDamage(float damage)
        {
            actionOnSetDamage?.Invoke(playerTank, damage);
        }
    }
}
