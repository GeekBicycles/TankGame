using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class GameInitialiazation
    {
        private IUpdateController mainUpdateController;
        public void Start(GameStarter gameStarter)
        {
            mainUpdateController = new UpdateController();
            gameStarter.SetUpdateController(mainUpdateController);

            SpawnPosition spawnPosition = new SpawnPosition();
            TankSpawner tankSpawner = new TankSpawner();
            tankSpawner.Spawn(spawnPosition.playerSpawnPoint, spawnPosition.EnemySpawnPoint);
        }
    }
}
