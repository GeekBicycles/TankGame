using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    [CreateAssetMenu(fileName = "EnemyTankModel", menuName = "Models/EnemyTank", order = 1)]
    public sealed class EnemyTankModel : ScriptableObject, IEnemyTank
    {
        [SerializeField, Range(0, 5)] private float _health;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 10)] private float _maxBulletSpeed;
        [SerializeField, Range(0, 20)] private float _maxAccuracy;
        [SerializeField, Range(0, 20)] private float _currentAccuracy;
        [SerializeField, Range(0, 10)] private float _changeAccuracy;
        public float health { get => _health; set => _health = value; }
        public float speed { get => _speed; set => _speed = value; }
        public float maxBulletSpeed { get => _maxBulletSpeed; set => _maxBulletSpeed = value; }
        public float maxAccuracy { get => _maxAccuracy; set => _maxAccuracy = value; }
        public float currentAccuracy { get => _currentAccuracy; set => _currentAccuracy = value; }
        public float changeAccuracy { get => _changeAccuracy; set => _changeAccuracy = value; }
        public Transform transform { get; set; }
    }
}
