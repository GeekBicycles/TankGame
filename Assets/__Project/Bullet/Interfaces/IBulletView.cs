using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IBulletView
    {
        public Transform transform { get; set; }
        public Rigidbody rigidbody { get; set; }
        public ParticleSystem particleSystem { get; }
        public AudioSource audioSource { get; }
        public IBulletBehaviour bulletBehaviour { get; set; }

    }
}
