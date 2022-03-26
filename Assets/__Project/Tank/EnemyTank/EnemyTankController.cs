using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

namespace Tank_Game
{
    public sealed class EnemyTankController : IUpdate, IEnemyTankController, ITurnBased, IMemento
    {
        public event Action endTurn;

        private IEnemyTankList _enemyTankList;
        private IEnemyTankFactory _enemyTankFactory;
        private IPlayerTankList _playerTankList;
        private ITankAutoRotator _tankAutoRotator;
        private IBulletController _bulletController;
        private bool _onTurn;
        private bool _isFired;

        private List<EnemyTankMementoList> _enemyTankMementos;

        public EnemyTankController(IEnemyTankList enemyTankList, IPlayerTankList playerTankList, IBulletController bulletController)
        {
            _enemyTankMementos = new List<EnemyTankMementoList>();
            _enemyTankList = enemyTankList;
            _playerTankList = playerTankList;
            _enemyTankFactory = new EnemyTankFactory();
            _tankAutoRotator = new TankAutoRotator();
            _bulletController = bulletController;
            _onTurn = false;
            _isFired = false;

            AddReactionOnBullet();
        }
        public void SaveMemento()
        {
            EnemyTankMementoList enemyTankMementoList = new EnemyTankMementoList();
            foreach (IEnemyTank enemyTank in _enemyTankList.enemyTanks)
            {
                EnemyTankMemento enemyTankMemento = new EnemyTankMemento();
                enemyTankMemento.health = enemyTank.health;
                enemyTankMemento.position = enemyTank.view.transform.position;
                enemyTankMemento.rotation = enemyTank.view.transform.rotation;
                enemyTankMementoList.enemyTankMementos.Add(enemyTankMemento);
                if(enemyTank == _enemyTankList.current)
                {
                    enemyTankMementoList.current = enemyTankMemento;
                }
            }
            _enemyTankMementos.Add(enemyTankMementoList);

        }
        public void LoadPrev()
        {
            int last = _enemyTankMementos.Count - 1;
            LoadMemento(last - 1);
        }
        public void LoadMemento(int index)
        {
            if ((index > _enemyTankMementos.Count - 1) || (index < 0))
            {
                return;
            }

            foreach (IEnemyTank enemyTank in _enemyTankList.enemyTanks)
            {
                enemyTank.view.enemyTankBehaviour.actionOnColliderEnter -= OnCollisionEnter;
                _enemyTankFactory.Destroy(enemyTank);
            }
            _enemyTankList.enemyTanks.Clear();
            _enemyTankList.current = null;

            EnemyTankMementoList enemyTankMementoList = _enemyTankMementos[index];
             foreach (EnemyTankMemento enemyTankMemento in enemyTankMementoList.enemyTankMementos)
            {
                IEnemyTank enemyTank = _enemyTankFactory.GetEnemyTank(enemyTankMemento.position, enemyTankMemento.rotation);
                enemyTank.view.enemyTankBehaviour.actionOnColliderEnter += OnCollisionEnter;
                enemyTank.health = enemyTankMemento.health;
                _enemyTankList.enemyTanks.Add(enemyTank);
                if(enemyTankMemento == enemyTankMementoList.current)
                {
                    _enemyTankList.current = enemyTank;
                }
            }
            _enemyTankMementos.RemoveAt(_enemyTankMementos.Count - 1);
        }
        private void AddReactionOnBullet()
        {
            foreach(IEnemyTank enemyTank in _enemyTankList.enemyTanks)
            {
                enemyTank.view.enemyTankBehaviour.actionOnColliderEnter += OnCollisionEnter;
            }
        }

        public void StartTurn()
        {
            _onTurn = true;
            _isFired = false;
        }

        private void EndTurn()
        {
            _onTurn = false;
            _isFired = false;
            endTurn?.Invoke();
        }

        public IEnemyTankList GetEnemyTankList()
        {
            return _enemyTankList;
        }

        private void OnCollisionEnter(IEnemyTank enemyTank, Collision collision)
        {
            if (collision.collider.CompareTag(GameTags.BULLET))
            {
                enemyTank.health -= collision.gameObject.GetComponent<BulletBehaviour>().bullet.model.damage;
                enemyTank.view.healthSlider.Value = enemyTank.health;
                if (enemyTank.health <= 0)
                {
                    enemyTank.view.enemyTankBehaviour.actionOnColliderEnter -= OnCollisionEnter;
                    _enemyTankList.Remove(enemyTank);
                    _enemyTankFactory.Destroy(enemyTank);
                }
            }
        }

        private bool CheckCurrentTank()
        {
            if (_enemyTankList.enemyTanks.Count == 0) return false;
            if (_enemyTankList.current == null) _enemyTankList.current = _enemyTankList.enemyTanks[0];
            return true;
        }

        private IPlayerTank ChooseTarget(IPlayerTankList playerTankList)
        {
            return playerTankList.playerTanks[UnityEngine.Random.Range(0, playerTankList.playerTanks.Count)];
        }

        public void Update(float deltaTime)
        {
            if (!CheckCurrentTank()) return;
            if (_playerTankList.playerTanks.Count == 0) return;

            if (_onTurn)
            {
                if (!_isFired)
                {
                    IPlayerTank playerTank = ChooseTarget(_playerTankList);
                    _tankAutoRotator.RotateToTarget(_enemyTankList.current.view.transform, playerTank.view.transform);
                    Transform newBulletTransform = _enemyTankList.current.view.bulletSpawnTransform;
                    float bulletForce = CalculateBulletForce(playerTank);
                    _bulletController.Fire(newBulletTransform.position, newBulletTransform.rotation, bulletForce);
                    _isFired = true;
                }
                else 
                {
                    if (_bulletController.GetCurrentBulletCount() == 0) EndTurn();
                }
            }
        }

        private float CalculateBulletForce(IPlayerTank player)
        {
            var currentEnemy = _enemyTankList.current;
            var heading = currentEnemy.view.transform.position - player.view.transform.position;
            var distance = heading.magnitude;
            var force = distance * currentEnemy.model.bulletforce * Random.Range(0.8f, 1.2f);
            return force;
        }
    }
}
