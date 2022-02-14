using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private ParticleSystem _particleSystem;
        private Rigidbody _rigidbody;
        private IBullet _bulletModel;

        private void Start()
        {
            transform.position = _playerStartPoint.position;
            transform.rotation = _playerStartPoint.rotation;
            _rigidbody = GetComponent<Rigidbody>();
            _bulletModel = new BulletModel(5, 5);
        }

        public void Fire(float speed)
        {
            gameObject.SetActive(true);
            _rigidbody.AddForce(transform.forward * speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _particleSystem.Play();
            transform.position = _playerStartPoint.position;
            transform.rotation = _playerStartPoint.rotation;
            gameObject.SetActive(false);
            
            if (collision.gameObject.TryGetComponent(Type EnemyTank, out IEnemyTank enemy))
            {
                enemy.health -= _bulletModel.Damage;
            }
        }
    }
}
