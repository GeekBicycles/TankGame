using UnityEngine;

namespace Tank_Game
{
    [CreateAssetMenu(fileName = "EnemyHelicopterModel", menuName = "Models/EnemyHelicopter", order = 1)]
    public class HelicopterModel : ScriptableObject, IHelicopterModel
    {
        [SerializeField, Range(0, 100)] private float _health;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 5)] private float _maxFlyHeight;
        public float health { get => _health; }
        public float speed { get => _speed; }
        public float maxFlyHeight { get => _maxFlyHeight; }
    }
}
