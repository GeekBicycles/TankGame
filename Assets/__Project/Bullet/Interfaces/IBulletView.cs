using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IBulletView
    {
        public Transform transform { get; }
        public Rigidbody rigidbody { get; }
        public ParticleSystem particleSystem { get; }
        public AudioSource audioSource { get; }
        public IBulletBehaviour bulletBehaviour { get; }

    }
}
