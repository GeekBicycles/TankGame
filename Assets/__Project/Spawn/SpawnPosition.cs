using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class SpawnPosition
    {
        public Transform playerSpawnPoint;
        public Transform EnemySpawnPoint;

        public SpawnPosition()
        {
            playerSpawnPoint = GameObject.Find("SpawnPoint1").transform;
            EnemySpawnPoint = GameObject.Find("SpawnPoint2").transform;
        }
    }
}
