using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    [CreateAssetMenu(fileName = "PlayerTankModel", menuName = "Models/PlayerTank", order = 1)]
    public sealed class PlayerTankModel : ScriptableObject, ITank
    {
        [SerializeField, Range(0, 5)] private float _health;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 10)] private float _maxBulletSpeed;
        public float health { get => _health; set => _health = value; }
        public float speed { get => _speed; set => _speed = value; }
        public float maxBulletSpeed { get => _maxBulletSpeed; set => _maxBulletSpeed = value; }
        public Transform transform { get; set; }
    }
}
