using UnityEngine;

namespace Tank_Game
{
    internal class BulletView : IBulletView
    {
        public Transform transform { get; }
        public Rigidbody rigidbody { get; }
        public ParticleSystem particleSystem { get; }
        public AudioSource audioSource { get; }
        public IBulletBehaviour bulletBehaviour { get; }

        public BulletView(Transform transform)
        {
            this.transform = transform;
            
            rigidbody = transform.GetComponent<Rigidbody>();
            bulletBehaviour = transform.GetComponent<IBulletBehaviour>();
            particleSystem = transform.GetComponentInChildren<ParticleSystem>();
            audioSource = transform.GetComponentInChildren<AudioSource>();
        }
    }
}