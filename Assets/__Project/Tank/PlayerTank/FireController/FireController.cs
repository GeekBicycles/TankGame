namespace Tank_Game
{
    public sealed class FireController : IFireController
    {
        private IPlayerTank _playerTank;
        private IInputData _inputData;
        private IBulletController _bulletController;

        public FireController(IPlayerTank playerTank, IInputData inputData, IBulletController bulletController)
        {
            _playerTank = playerTank;
            _inputData = inputData;
            _bulletController = bulletController;
        }

        public void FireControl(float deltaTime)
        {
            _playerTank.timeToFire += deltaTime;
            if (_playerTank.timeToFire >= _playerTank.model.maxTimeToFire)
            {
                if (_inputData.fire)
                {
                    _playerTank.timeToFire = 0;
                    _bulletController.Fire(_playerTank.view.bulletSpawnTransform.position, _playerTank.view.bulletSpawnTransform.rotation, _playerTank.model.maxBulletSpeed);
                }
            }
        }
    }
}
