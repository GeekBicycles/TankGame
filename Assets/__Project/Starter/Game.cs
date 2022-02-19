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

        public void Start(GameStarter gameStarter)
        {
            _gameStarter = gameStarter;

            InitInputController();

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
            IPlayerTankList playerTankList = new PlayerTankList();
            IEnemyTankList enemyTankList = new EnemyTankList();

            new TankSpawner(playerTankList, enemyTankList).Spawn();
            new StartTankPosition().SetStartupPosition(playerTankList, enemyTankList);

            BulletController bulletController = new BulletController();

            PlayerTankController playerTankController = new PlayerTankController(_inputData, _inputMouseData, playerTankList, bulletController);
            IPlayerTank playerTank = playerTankController.GetPlayerTank();

            EnemyTankController enemyTankController = new EnemyTankController(enemyTankList);
            CameraController cameraController = new CameraController(playerTank.view.transform);

            UpdateController updateController = new UpdateController();
            updateController.AddController(_inputController);
            updateController.AddController(_inputMouseController);
            updateController.AddController(playerTankController);
            updateController.AddController(enemyTankController);
            updateController.AddController(cameraController);

            _gameStarter.SetUpdateController(updateController);
        }
    }
}
