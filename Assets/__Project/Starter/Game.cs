using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class Game
    {
        private GameStarter gameStarter;

        private InputController inputController;

        private IInputData inputData;
        private ITank playerTankModel;
        private IEnemyTank enemyTankModel;

        public void Start(GameStarter gameStarter)
        {
            this.gameStarter = gameStarter;

            InitInputController();

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
            BeginGameController beginGameController = new BeginGameController(inputData, BeginGame);

            IUpdateController updateController = new UpdateController();

            updateController.AddController(inputController);
            updateController.AddController(beginGameController);

            gameStarter.SetUpdateController(updateController);
        }

        private void BeginGame()
        {
            SpawnTanks();

            BulletsData bulletsData = new BulletsData();
            BulletController bulletController = new BulletController(bulletsData);
            BulletFactory bulletFactory = new BulletFactory(bulletController);
            PlayerTankController playerTankController = new PlayerTankController(inputData, playerTankModel, bulletFactory);
            EnemyTankController enemyTankController = new EnemyTankController(/*enemyTankModel, */bulletFactory);
            TurnBasedController turnBasedController = new TurnBasedController(playerTankController, enemyTankController, bulletsData);
            EndGameController endGameController = new EndGameController(playerTankModel, enemyTankModel);
            CameraController cameraController = new CameraController();
            UIController uIController = new UIController(playerTankModel, enemyTankModel);

            UpdateController updateController = new UpdateController();
            //updateController.AddController(inputController);
            //updateController.AddController(playerTankController);
            //updateController.AddController(enemyTankController);
            //updateController.AddController(bulletController);
            //updateController.AddController(turnBasedController);
            //updateController.AddController(endGameController);
            //updateController.AddController(cameraController);
            //updateController.AddController(uIController);
            gameStarter.SetUpdateController(updateController);
        }

        private void SpawnTanks()
        {
            TankFactory tankFactory = new TankFactory();
            playerTankModel = tankFactory.GetPlayerTankModel();
            enemyTankModel = tankFactory.GetEnemyTankModel();

            SpawnPosition spawnPosition = new SpawnPosition();
            TankSpawner tankSpawner = new TankSpawner();
            tankSpawner.Spawn(spawnPosition.playerSpawnPoint.position, spawnPosition.EnemySpawnPoint.position);
            new TankAutoRotator(tankSpawner.playerTank, tankSpawner.ememyTank);

            playerTankModel.transform = tankSpawner.playerTank;
            enemyTankModel.transform = tankSpawner.ememyTank;
        }
    }
}
