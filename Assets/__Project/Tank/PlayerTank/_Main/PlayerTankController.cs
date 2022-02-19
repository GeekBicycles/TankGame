using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankController : IUpdate, IPlayerTankController
    {
        private IInputData _inputData;
        private IBulletController _bulletController;
        private IPlayerTank _playerTank;
        private IPlayerTankFactory _playerTankFactory;
        private IBulletPowerFire _bulletPowerFire;
        private IChooseEnemy _enemy;

        public PlayerTankController(IInputData inputData, IBulletController bulletController, IChooseEnemy enemy)
        {
            _inputData = inputData;
            _bulletController = bulletController;
            _playerTankFactory = new PlayerTankFactory();
            _playerTank = _playerTankFactory.GetPlayerTank(Vector3.zero, Quaternion.identity);
            _bulletPowerFire = new BulletPowerFire(inputData);
            _enemy = enemy;
            _enemy.actionChooseEnemy += RotatePlayerToEnemy;
        }

        public IPlayerTank GetPlayerTank()
        {
            return _playerTank;
        }

        public void Update(float deltaTime)
        {

            _bulletPowerFire.Update(deltaTime);

            float z = (_inputData.up ? 1 : 0) - (_inputData.down ? 1 : 0);
            Vector3 movement = new Vector3(0, 0, z);
            movement.y = _playerTank.model.gravity;
            movement *= Time.deltaTime * _playerTank.model.speed;
            _playerTank.view.transform.Translate(movement);

            float y = (_inputData.left ? 1 : 0) - (_inputData.right ? 1 : 0);
            _playerTank.view.transform.Rotate(0,y,0);

            _playerTank.timeToFire += deltaTime;
            if (_playerTank.timeToFire >= _playerTank.model.maxTimeToFire)
            {
                if (_bulletPowerFire.isBulletReady)
                {
                    _bulletPowerFire.isBulletReady = false;
                    _playerTank.timeToFire = 0;
                    _bulletController.Fire(_playerTank.view.bulletSpawnTransform.position, _playerTank.view.bulletSpawnTransform.rotation, _bulletPowerFire.GetFirePower()*1500f);
                }
            }
        }

        private void RotatePlayerToEnemy(Transform enemyTransform)
        {
            _playerTank.view.transform.LookAt(enemyTransform);
        }
    }
}
