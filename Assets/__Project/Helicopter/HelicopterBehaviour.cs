using System;
using UnityEngine;

namespace Tank_Game
{
    public class HelicopterBehaviour : MonoBehaviour, IHelicopterBehaviour
    {
        public event Action<IHelicopter, Collision> actionOnColliderEnter;
        public IHelicopter helicopter { get; set; }
        public void OnCollisionEnter(Collision collision)
        {
            actionOnColliderEnter?.Invoke(helicopter, collision);
        }
    }
}
