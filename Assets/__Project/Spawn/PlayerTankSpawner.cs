using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankSpawner : IPlayerTankSpawner
    {
        private IPlayerTankFactory _playerTankFactory;
        private ISpawnPosition _spawnPosition;

        public PlayerTankSpawner(IPlayerTankFactory playerTankFactory)
        {
            _playerTankFactory = playerTankFactory;
            _spawnPosition = new SpawnPosition();
        }

        public IPlayerTank Spawn()
        {
            Vector3 position = _spawnPosition.GetSpawnPosition();
            if (position == Vector3.zero) return null;

            IPlayerTank playerTank = _playerTankFactory.GetPlayerTank(position, Quaternion.identity);
            playerTank.view.transform.position = position;

            return playerTank;
        }

    }
}
