namespace Tank_Game
{
    public sealed class TankSpawner : ITankSpawner
    {
        private IPlayerTankList _playerTankList;
        private IEnemyTankList _enemyTankList;
        public TankSpawner(IPlayerTankList playerTankList, IEnemyTankList enemyTankList)
        {
            _playerTankList = playerTankList;
            _enemyTankList = enemyTankList;
        }

        public void Spawn()
        {
            SpawnEnemyTanks();
            SpawnPlayerTanks();
        }

        public void SpawnEnemyTanks()
        {
            IEnemyTankFactory enemyTankFactory = new EnemyTankFactory();
            IEnemyTankSpawner enemyTankSpawner = new EnemyTankSpawner(enemyTankFactory);

            while (_enemyTankList.enemyTanks.Count < GameSettings.ENEMY_TANKS_COUNT)
            {
                IEnemyTank enemyTank = enemyTankSpawner.Spawn();
                if (enemyTank != null)
                {
                    _enemyTankList.enemyTanks.Add(enemyTank);
                }
            }
        }

        public void SpawnPlayerTanks()
        {
            IPlayerTankFactory playerTankFactory = new PlayerTankFactory();
            IPlayerTankSpawner playerTankSpawner = new PlayerTankSpawner(playerTankFactory);

            while (_playerTankList.playerTanks.Count < GameSettings.PLAYER_TANKS_COUNT)
            {
                IPlayerTank playerTank = playerTankSpawner.Spawn();
                if (playerTank != null)
                {
                    _playerTankList.playerTanks.Add(playerTank);
                }
            }
        }
    }
}
