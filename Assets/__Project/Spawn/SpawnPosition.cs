using UnityEngine;

namespace Tank_Game
{
    public sealed class SpawnPosition : ISpawnPosition
    {
        private ISpawnPositionSettings spawnPositionSettings;

        public SpawnPosition()
        {
            spawnPositionSettings = new SpawnPositionSettings();
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
            Collider[] colliders = Physics.OverlapSphere(randomPosition, spawnPositionSettings.radiusOverlapSphere);
            foreach (Collider collider in colliders)
            {
                if (!collider.name.Equals(spawnPositionSettings.groundNameGameObject)) return false;
            }

            return true;
        }

        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(spawnPositionSettings.fieldMinX, spawnPositionSettings.fieldMaxX);
            float y = Random.Range(spawnPositionSettings.fieldMinY, spawnPositionSettings.fieldMaxY);
            return new Vector3(x, 0, y);
        }
    }
}
