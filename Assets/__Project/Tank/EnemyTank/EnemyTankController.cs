using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tank_Game
{
    public sealed class EnemyTankController : IUpdate, IEnemyTankController, ITurnBased
    {
        public event Action endTurn;

        private IEnemyTankList _enemyTankList;
        private IEnemyTankFactory _enemyTankFactory;
        private IPlayerTankList _playerTankList;
        private ITankAutoRotator _tankAutoRotator;
        private IBulletController _bulletController;
        private bool _onTurn;
        private bool _isFired;

        public EnemyTankController(IEnemyTankList enemyTankList, IPlayerTankList playerTankList, IBulletController bulletController)
        {
            _enemyTankList = enemyTankList;
            _playerTankList = playerTankList;
            _enemyTankFactory = new EnemyTankFactory();
            _tankAutoRotator = new TankAutoRotator();
            _bulletController = bulletController;
            _onTurn = false;
            _isFired = false;

            AddReactionOnBullet();
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
                enemyTank.view.enemyTankBehaviour.actionOnColliderEnter -= OnCollisionEnter;
                _enemyTankList.Remove(enemyTank);
                _enemyTankFactory.Destroy(enemyTank);
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
