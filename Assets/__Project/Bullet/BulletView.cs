using UnityEngine;

namespace Tank_Game
{
    internal class BulletView : IBulletView
    {
        public Transform transform { get; set; }
        public Rigidbody rigidbody { get; set; }
        public ParticleSystem particleSystem { get; set; }
        public AudioSource audioSource { get; }

        public IBulletBehaviour bulletBehaviour { get; set; }

        public BulletView(Transform transform)
        {
            this.transform = transform;
            this.rigidbody = transform.GetComponent<Rigidbody>();
            this.bulletBehaviour = transform.GetComponent<IBulletBehaviour>();
            this.particleSystem = transform.GetComponentInChildren<ParticleSystem>();
            this.audioSource = transform.GetComponentInChildren<AudioSource>();
        }
    }
}