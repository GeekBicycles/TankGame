using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private Transform _enemyStartPoint;
        [SerializeField] private ParticleSystem _particleSystem;
        private bool _isVisible;
        private Rigidbody _rigidbody;

        private void Start()
        {
            transform.position = _playerStartPoint.position;
            transform.rotation = _playerStartPoint.rotation;
            gameObject.SetActive(_isVisible);
            _rigidbody = GetComponent<Rigidbody>();
        }
        
    }
}
