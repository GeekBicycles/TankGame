using UnityEngine;

namespace Tank_Game
{
    public sealed class TankCountController : IUpdate, ITankCountController
    {
        public IPlayerTankList playerTankList { get; set; }
        public ITankUIBehaviour tankUIBehaviour { get; set; }
        public IEnemyTankList enemyTankList { get; set; }
        public Transform canvasTransform { get; set; }
        private int _playerTanksCount;
        private int _enemyTanksCount;

        public TankCountController(IPlayerTankList playerTankList, IEnemyTankList enemyTankList)
        {
            this.playerTankList = playerTankList;
            this.enemyTankList = enemyTankList;
            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.TANK_COUNT_SPAWN);
            canvasTransform = GameObject.Instantiate(prefab).transform;
            tankUIBehaviour = canvasTransform.GetComponent<ITankUIBehaviour>();
            _playerTanksCount = playerTankList.playerTanks.Count;
            _enemyTanksCount = enemyTankList.enemyTanks.Count;
            UpdatePlayerCount();
            UpdateEnemyCount();
        }

        private void UpdatePlayerCount()
        {
            tankUIBehaviour.playerCount.text = _playerTanksCount.ToString();
        }

        private void UpdateEnemyCount()
        {
            tankUIBehaviour.enemyCount.text = _enemyTanksCount.ToString();
        }

        public void Update(float deltaTime)
        {
            if (playerTankList.playerTanks.Count != _playerTanksCount)
            {
                _playerTanksCount = playerTankList.playerTanks.Count;
                UpdatePlayerCount();
            }
            if (enemyTankList.enemyTanks.Count != _enemyTanksCount)
            {
                _enemyTanksCount = enemyTankList.enemyTanks.Count;
                UpdateEnemyCount();
            }

        }

    }
}
