using UnityEngine;

namespace Tank_Game
{
    [CreateAssetMenu(fileName = "PlayerTankModel", menuName = "Models/PlayerTank", order = 1)]
    public sealed class PlayerTankModel : ScriptableObject, IPlayerTankModel
    {
        [SerializeField, Range(0, 5)] private float _health;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 10)] private float _gravity;
        [SerializeField, Range(0, 1000)] private float _maxBulletSpeed;
        [SerializeField, Range(0, 5)] private float _maxTimeToFire;
        [SerializeField, Range(0, 360)] private float _rotateSpeed;

        public float health { get => _health; }
        public float speed { get => _speed; }
        public float gravity { get => _gravity; }
        public float maxBulletSpeed { get => _maxBulletSpeed; }
        public float maxTimeToFire  {get => _maxTimeToFire; }
        public float rotateSpeed { get => _rotateSpeed; }
    }
}
