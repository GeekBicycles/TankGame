using UnityEngine;

namespace Tank_Game
{
    internal class BulletView : IBulletView
    {
        public Transform transform { get; set; }
        public Rigidbody rigidbody { get; set; }

        public IBulletBehaviour bulletBehaviour { get; set; }

        public BulletView(Transform transform)
        {
            this.transform = transform;
            this.rigidbody = transform.GetComponent<Rigidbody>();
            this.bulletBehaviour = transform.GetComponent<IBulletBehaviour>();
        }
    }
}