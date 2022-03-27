using UnityEngine;

namespace Tank_Game
{
    public sealed class Game
    {
        private GameStarter _gameStarter;

        private InputController _inputController;
        private InputMouseController _inputMouseController;
        private IInputData _inputData;
        private IInputMouseData _inputMouseData;
        private TurnBasedController _turnBasedController;
        private ILevelDataController levelDataController;

        public void Start(GameStarter gameStarter)
        {
            _gameStarter = gameStarter;

            InitInputController();

            levelDataController = new LevelDataController();

            WaitForStart();

        }

        private void InitInputController()
        {
            IKeySetControl keySetControl = Resources.Load<KeySetControl>(ResourcesPathes.KEY_SET_CONTROL);
            _inputData = new InputData();
            _inputController = new InputController(_inputData, keySetControl);

            IMouseSetControl mouseSetControl = Resources.Load<MouseSetControl>(ResourcesPathes.MOUSE_SET_CONTROL);
            _inputMouseData = new InputMouseData();
            _inputMouseController = new InputMouseController(_inputMouseData, mouseSetControl);
        }

        private void WaitForStart()
        {
            BeginGameController beginGameController = new BeginGameController(_inputData, BeginGame);

            IUpdateController updateController = new UpdateController();

            updateController.AddController(_inputController);
            updateController.AddController(beginGameController);

            _gameStarter.SetUpdateController(updateController);
        }

        private void BeginGame()
        {

            MementoController mementoController = new MementoController();

            IPlayerTankList playerTankList = new PlayerTankList();
            IEnemyTankList enemyTankList = new EnemyTankList();
            IHelicopterList helicopterList = new HelicopterList();

            new TankSpawner(playerTankList, enemyTankList).Spawn();
            new StartTankPosition().SetStartupPosition(playerTankList, enemyTankList);
            
            new HelicopterSpawner(helicopterList).SpawnHelicopter();
            new StartHelicopterPosition().SetStartupPosition(helicopterList);

            BulletController bulletController = new BulletController();
            

            TankCountController tankCountController = new TankCountController(playerTankList, enemyTankList);
            AttermptsController attermptsController = new AttermptsController(playerTankList);

            PlayerTankController playerTankController = new PlayerTankController(_inputData, _inputMouseData, playerTankList, bulletController);
            IPlayerTank playerTank = playerTankController.GetPlayerTank();
            mementoController.AddMemento(playerTankController);

            EnemyTankController enemyTankController = new EnemyTankController(enemyTankList, playerTankList, bulletController);
            mementoController.AddMemento(enemyTankController);

            HelicopterController helicopterController = new HelicopterController(helicopterList);
            helicopterController.SetTargets(playerTankList);
            mementoController.AddMemento(helicopterController);

            CameraController cameraController = new CameraController(playerTankList);

            _turnBasedController = new TurnBasedController(playerTankController, enemyTankController, helicopterController, enemyTankList, mementoController);
            EndGameController endGameController = new EndGameController(playerTankList, enemyTankList);
            endGameController.actionPlayerWin += levelDataController.IncrementLevel;
            endGameController.actionEnemyWin += levelDataController.ResetLevel;
            endGameController.actionEnemyWin += attermptsController.EndEnemyWIN;

            UpdateController updateController = new UpdateController();
            updateController.AddController(_inputController);
            updateController.AddController(_inputMouseController);
            updateController.AddController(playerTankController);
            updateController.AddController(enemyTankController);
            updateController.AddController(helicopterController);
            updateController.AddController(cameraController);
            updateController.AddController(endGameController);
            updateController.AddController(tankCountController);
            updateController.AddController(mementoController);

            _gameStarter.SetUpdateController(updateController);
        }
    }
}
