using System;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankController : IUpdate, IPlayerTankController, ITurnBased
    {

        public event Action endTurn;

        private IBulletController _bulletController;
        private IBulletPowerFire _bulletPowerFire;
        private IChooseEnemy _chooseEnemy;
        private IMoveController _moveController;
        private IRotateController _rotateController;
        private IFireController _fireController;
        private IPlayerTankList _playerTankList;
        private IPlayerTankFactory _playerTankFactory;
        private bool _onTurn;
        private bool _isFired;

        public PlayerTankController(IInputData inputData, IInputMouseData inputMouseData, IPlayerTankList playerTankList, IBulletController bulletController)
        {
            _playerTankList = playerTankList;
            if (_playerTankList.playerTanks.Count > 0)
            {
                _playerTankList.current = _playerTankList.playerTanks[0];
            }

            _bulletController = bulletController;
            _bulletPowerFire = new BulletPowerFire(inputData);
            _chooseEnemy = new ChooseEnemy(inputMouseData);
            _chooseEnemy.actionChooseEnemy += RotatePlayerToEnemy;
            _moveController = new MoveController(inputData);
            _rotateController = new RotateController(inputData);
            _fireController = new FireController(_bulletController, _bulletPowerFire);
            _playerTankFactory = new PlayerTankFactory();
            _onTurn = false;
            _isFired = false;
            
            AddReactionOnBullet();
        }

        private void AddReactionOnBullet()
        {
            foreach (IPlayerTank playerTank in _playerTankList.playerTanks)
            {
                playerTank.view.playerTankBehavior.actionOnColliderEnter += OnCollisionEnter;
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

        public IPlayerTank GetPlayerTank()
        {
            return _playerTankList.current;
        }

        private bool CheckCurrentTank()
        {
            if (_playerTankList.playerTanks.Count == 0) return false;
            if (_playerTankList.current == null) _playerTankList.current = _playerTankList.playerTanks[0];
            return true;
        }

        public void Update(float deltaTime)
        {
            if (!CheckCurrentTank()) return;

            if (_onTurn)
            {
                _chooseEnemy.Update(deltaTime);
                _bulletPowerFire.Update(deltaTime);
                _moveController.Move(deltaTime, _playerTankList.current);
                _rotateController.Rotate(deltaTime, _playerTankList.current);
                if (!_isFired)
                {
                    _isFired = _fireController.Fire(deltaTime, _playerTankList.current, _bulletPowerFire.GetFirePower() * _playerTankList.current.model.maxBulletSpeed);
                }
                else
                {
                    if (_bulletController.GetCurrentBulletCount() == 0)
                    {
                        EndTurn();
                    }
                }
                
            }
            else
            {
                _rotateController.Rotate(deltaTime, _playerTankList.current);
            }

            _playerTankList.current.view.fireSlider.Value = _bulletPowerFire.GetPressFire();
        }
        
        private void OnCollisionEnter(IPlayerTank playerTank, Collision collision)
        {
            if (collision.collider.CompareTag(GameTags.BULLET))
            {
                playerTank.health -= collision.gameObject.GetComponent<BulletBehaviour>().bullet.model.damage;
                playerTank.view.healthSlider.Value = playerTank.health;
                if (playerTank.health <= 0)
                {
                    playerTank.view.playerTankBehavior.actionOnColliderEnter -= OnCollisionEnter;
                    _playerTankList.Remove(playerTank);
                    _playerTankFactory.Destroy(playerTank);
                }
            }
        }

        private void RotatePlayerToEnemy(Transform enemyTransform)
        {
            _playerTankList.current?.view.transform.LookAt(enemyTransform);
        }
    }
}
