using UnityEngine;

namespace Tank_Game
{
    public class HelicopterView : IHelicopterView
    {
        public Transform transform { get; set; }
        public Transform bulletSpawnTransform { get; }
        public IHelicopterBehaviour helicopterBehaviour { get; }
        public Collider collider { get; }

        public HelicopterView(Transform transform)
        {
            this.transform = transform;
            bulletSpawnTransform = transform.GetComponentInChildren<IBulletSpawnTransform>().bulletSpawnTransform;
            helicopterBehaviour = transform.gameObject.AddComponent<HelicopterBehaviour>();
        }
    }
}
