using System;
using UnityEngine;

namespace Tank_Game
{
    public interface IHelicopterBehaviour
    {
        public event Action<IHelicopter, Collision> actionOnColliderEnter;
        
        IHelicopter helicopter { get; set; }
        public void OnCollisionEnter(Collision collision);
    }
}
