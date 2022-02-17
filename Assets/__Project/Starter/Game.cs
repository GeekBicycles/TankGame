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
        private IPlayerTank playerTank;
        private IEnemyTankList enemyTankList;

        public void Start(GameStarter gameStarter)
        {
            this.gameStarter = gameStarter;

            InitInputController();

            //WaitForStart(); //TODO �������� �����, �������� �� ������������
            BeginGame();
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
            BulletController bulletController = new BulletController();
            PlayerTankController playerTankController = new PlayerTankController(inputData, bulletController);
            playerTank = playerTankController.GetPlayerTank();
            EnemyTankController enemyTankController = new EnemyTankController(bulletController);

            EndGameController endGameController = new EndGameController(playerTank, enemyTankController.GetEnemyTankList());
            
            CameraController cameraController = new CameraController(playerTank);
            
            UIController uIController = new UIController(playerTank);

            UpdateController updateController = new UpdateController();
            updateController.AddController(inputController);
            updateController.AddController(bulletController);
            updateController.AddController(playerTankController);
            updateController.AddController(enemyTankController);
            //updateController.AddController(endGameController);
            updateController.AddController(cameraController);
            //updateController.AddController(uIController);
            gameStarter.SetUpdateController(updateController);
        }

        private void SpawnTanks()
        {
            //TankFactory tankFactory = new TankFactory();
            //playerTankModel = tankFactory.GetPlayerTankModel();
            //enemyTankModel = tankFactory.GetEnemyTankModel();

            //SpawnPosition spawnPosition = new SpawnPosition();
            //TankSpawner tankSpawner = new TankSpawner();
            //tankSpawner.Spawn(spawnPosition.playerSpawnPoint.position, spawnPosition.EnemySpawnPoint.position);
            //new TankAutoRotator(tankSpawner.playerTank, tankSpawner.ememyTank);

            //playerTankModel.transform = tankSpawner.playerTank;
            //enemyTankModel.transform = tankSpawner.ememyTank;
        }
    }
}
