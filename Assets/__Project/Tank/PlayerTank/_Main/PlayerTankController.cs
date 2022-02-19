using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankController : IUpdate, IPlayerTankController
    {
        private IBulletController _bulletController;
        private IBulletPowerFire _bulletPowerFire;
        private IChooseEnemy _chooseEnemy;
        private IMoveController _moveController;
        private IRotateController _rotateController;
        private IFireController _fireController;
        private IPlayerTankList _playerTankList;

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
        }

        public IPlayerTank GetPlayerTank()
        {
            return _playerTankList.current;
        }

        public void Update(float deltaTime)
        {
            _chooseEnemy.Update(deltaTime);
            _bulletPowerFire.Update(deltaTime);

            _moveController.Move(deltaTime, _playerTankList.current);
            _rotateController.Rotate(deltaTime, _playerTankList.current);
            _fireController.Fire(deltaTime, _playerTankList.current, _bulletPowerFire.GetFirePower() * _playerTankList.current.model.maxBulletSpeed);
        }

        private void RotatePlayerToEnemy(Transform enemyTransform)
        {
            _playerTankList.current?.view.transform.LookAt(enemyTransform);
        }
    }
}
