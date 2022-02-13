using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class GameInitialiazation
    {
        private GameStarter gameStarter;

        private IInputData inputData;
        private InputController inputController;
        public void Start(GameStarter gameStarter)
        {
            this.gameStarter = gameStarter;

            WaitForStart();
        }

        private void InitInputController()
        {
            IKeySetControl keySetControl = Resources.Load<KeySetControl>(ResourcesPathes.keySetControl);
            inputData = new InputData();
            inputController = new InputController(inputData, keySetControl);
        }

        private void WaitForStart()
        {
            InitInputController();

            BeginGameController beginGameController = new BeginGameController(inputData, BeginGame);

            IUpdateController updateController = new UpdateController();

            updateController.AddController(inputController);
            updateController.AddController(beginGameController);

            gameStarter.SetUpdateController(updateController);
        }

        private void BeginGame()
        {
            //Debug.ClearDeveloperConsole();
            //Debug.Log("Begin game");
            InitInputController();
            SpawnTanks();
            TurnBasedInit();
        }

        private void TurnBasedInit()
        {
            UpdateController firstTurn = new UpdateController();
            firstTurn.AddController(inputController);

            TurnBasedController turnBasedController = new TurnBasedController();
            turnBasedController.AddController(firstTurn);
            turnBasedController.Start();

            gameStarter.SetUpdateController(turnBasedController);
        }

        private void SpawnTanks()
        {
            TankFactory tankFactory = new TankFactory();
            ITank playerTankModel = tankFactory.GetPlayerTankModel();
            IEnemyTank enemyTankModel = tankFactory.GetEnemyTankModel();

            SpawnPosition spawnPosition = new SpawnPosition();
            TankSpawner tankSpawner = new TankSpawner();
            tankSpawner.Spawn(spawnPosition.playerSpawnPoint.position, spawnPosition.EnemySpawnPoint.position);
            new TankAutoRotator(tankSpawner.playerTank, tankSpawner.ememyTank);

            playerTankModel.transform = tankSpawner.playerTank;
            enemyTankModel.transform = tankSpawner.ememyTank;
        }
    }
}
