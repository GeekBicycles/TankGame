using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class SpawnPosition
    {
        public GameObject playerSpawnPoint;
        public GameObject EnemySpawnPoint;

        public SpawnPosition()
        {
            playerSpawnPoint = GameObject.Find("SpawnPoint1");
            EnemySpawnPoint = GameObject.Find("SpawnPoint2");
        }
    }
}
