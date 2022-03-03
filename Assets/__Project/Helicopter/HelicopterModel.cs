using UnityEngine;

namespace Tank_Game
{
    [CreateAssetMenu(fileName = "EnemyHelicopterModel", menuName = "Models/EnemyHelicopter", order = 1)]
    public class HelicopterModel : ScriptableObject, IHelicopterModel
    {
        [SerializeField, Range(0, 100)] private float _health;
        [SerializeField, Range(0, 10)] private float _moveSpeed;
        [SerializeField, Range(0, 180)] private float _rotateSpeed;
        [SerializeField, Range(0, 5)] private float _maxFlyHeight;
        [SerializeField, Range(0, 10000)] private float _maxTwinSpeed;
        [SerializeField, Range(0, 10000)] private float _changeTwinSpeed;
        public float health { get => _health; }
        public float moveSpeed { get => _moveSpeed; }
        public float rotateSpeed { get => _rotateSpeed; }
        public float maxFlyHeight { get => _maxFlyHeight; }
        public float maxTwinSpeed { get => _maxTwinSpeed; }
        public float changeTwinSpeed { get => _changeTwinSpeed; }
    }
}
