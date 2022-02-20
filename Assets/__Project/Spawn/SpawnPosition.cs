using UnityEngine;

namespace Tank_Game
{
    public sealed class SpawnPosition : ISpawnPosition
    {
        private ISpawnPositionSettings _spawnPositionSettings;

        public SpawnPosition()
        {
            _spawnPositionSettings = new SpawnPositionSettings();
        }

        public Vector3 GetSpawnPosition()
        {
            Vector3 randomPosition = GetRandomPosition();
            bool free = CheckFreePosition(randomPosition);
            if (free)
            {
                return randomPosition;
            }
            else
            {
                return Vector3.zero;
            }
        }

        private bool CheckFreePosition(Vector3 randomPosition)
        {
            Collider[] colliders = Physics.OverlapSphere(randomPosition, _spawnPositionSettings.radiusOverlapSphere);
            foreach (Collider collider in colliders)
            {
                if (!collider.name.Equals(_spawnPositionSettings.groundNameGameObject)) return false;
            }

            return true;
        }

        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(_spawnPositionSettings.fieldMinX, _spawnPositionSettings.fieldMaxX);
            float y = Random.Range(_spawnPositionSettings.fieldMinY, _spawnPositionSettings.fieldMaxY);
            return new Vector3(x, 0, y);
        }
    }
}
