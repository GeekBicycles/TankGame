using System.Collections;
using System.Collections.Generic;
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
        public float health { get => _health; set => _health = value; }
        public float speed { get => _speed; set => _speed = value; }
        public float gravity { get => _gravity; set => _gravity = value; }
        public float maxBulletSpeed { get => _maxBulletSpeed; set => _maxBulletSpeed = value; }
        public float maxTimeToFire  {get => _maxTimeToFire; set => _maxTimeToFire = value; }
        public float rotateSpeed { get => _rotateSpeed; set => _rotateSpeed = value; }
}
}
