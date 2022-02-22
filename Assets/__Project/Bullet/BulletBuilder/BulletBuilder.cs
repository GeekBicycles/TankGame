using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletBuilder
    {
        private GameObject _gameObject;

        public BulletBuilder()
        {
            _gameObject = new GameObject();
        }

        public BulletBuilder(GameObject prefab)
        {
            _gameObject = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }

        public static implicit operator GameObject(BulletBuilder builder)
        {
            return builder._gameObject;
        }


        public BulletBuilder CapsuleCollider(Vector3 center, float radius, float height)
        {
            CapsuleCollider capsuleCollider = GetOrAddComponent<CapsuleCollider>();
            capsuleCollider.center = center;
            capsuleCollider.radius = radius;
            capsuleCollider.height = height;
            return this;
        }

        public BulletBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        public BulletBuilder RigidBody(float mass, float drag, float angularDrag, bool useGravity, bool isKinematic)
        {
            Rigidbody rigidbody = GetOrAddComponent<Rigidbody>();
            rigidbody.mass = mass;
            rigidbody.drag = drag;
            rigidbody.angularDrag = angularDrag;
            rigidbody.useGravity = useGravity;
            rigidbody.isKinematic = isKinematic;
            return this;
        }

        public BulletBuilder Behaviour()
        {
            BulletBehaviour bulletBehaviour = GetOrAddComponent<BulletBehaviour>();
            return this;
        }

        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (!result)
            {
                result = _gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}
