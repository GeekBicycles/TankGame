using System;
using UnityEngine;
namespace Tank_Game
{
    public class PlayerTankBehavior : MonoBehaviour
    {
        public event Action<IPlayerTank, Collision> actionOnColliderEnter;

        public IPlayerTank playerTank { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            actionOnColliderEnter?.Invoke(playerTank, collision);
        }
    }
}
