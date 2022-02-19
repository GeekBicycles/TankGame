namespace Tank_Game
{
    public sealed class FireController : IFireController
    {
        private IBulletController _bulletController;
        private IBulletPowerFire _bulletPowerFire;

        public FireController(IBulletController bulletController, IBulletPowerFire bulletPowerFire)
        {
            _bulletController = bulletController;
            _bulletPowerFire = bulletPowerFire;
        }

        public void Fire(float deltaTime, IPlayerTank playerTank, float bulletForce)
        {
            playerTank.timeToFire += deltaTime;
            if (playerTank.timeToFire >= playerTank.model.maxTimeToFire)
            {
                if (_bulletPowerFire.isBulletReady)
                {
                    _bulletPowerFire.isBulletReady = false;
                    playerTank.timeToFire = 0;
                    _bulletController.Fire(playerTank.view.bulletSpawnTransform.position, playerTank.view.bulletSpawnTransform.rotation, bulletForce);
                }
            }
        }
    }
}
