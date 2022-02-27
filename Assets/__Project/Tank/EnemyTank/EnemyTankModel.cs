using UnityEngine;

namespace Tank_Game
{
    [CreateAssetMenu(fileName = "EnemyTankModel", menuName = "Models/EnemyTank", order = 1)]
    public sealed class EnemyTankModel : ScriptableObject, IEnemyTankModel
    {
        [SerializeField, Range(0, 100)] private float _health;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 10)] private float _maxBulletSpeed;
        [SerializeField, Range(0, 20)] private float _maxAccuracy;
        [SerializeField, Range(0, 20)] private float _currentAccuracy;
        [SerializeField, Range(0, 10)] private float _changeAccuracy;
        [SerializeField, Range(0, 10)] private float _maxTimeToFire;
        [SerializeField, Range(40, 50)] private float _bulletforce;
        [SerializeField, Range(0, 360)] private float _rotateSpeed;

        public float health { get => _health; }
        public float speed { get => _speed; }
        public float maxBulletSpeed { get => _maxBulletSpeed; }
        public float maxAccuracy { get => _maxAccuracy; }
        public float currentAccuracy { get => _currentAccuracy; }
        public float changeAccuracy { get => _changeAccuracy; }
        public float maxTimeToFire { get => _maxTimeToFire; }
        public float bulletforce { get => _bulletforce; }
        public float rotateSpeed { get => _rotateSpeed; }

        public object Clone()
        {
            return ScriptableObject.Instantiate(this);
        }
    }
}
