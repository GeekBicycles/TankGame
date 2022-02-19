using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletSpawnTransform : MonoBehaviour, IBulletSpawnTransform
    {
        [SerializeField] private Transform _bulletSpawnTransform;
        public Transform bulletSpawnTransform { get { return _bulletSpawnTransform; } }
    }
}
