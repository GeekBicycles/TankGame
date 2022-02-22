using UnityEngine;

namespace Tank_Game
{
    public sealed class TankCountController : IUpdate, ITankCountController
    {
        public IPlayerTankList PlayerTankList { get; set; }
        public ITankUIBehevior TankUIBehevior { get; set; }
        public IEnemyTankList EnemyTankList { get; set; }
        public Transform CanvasTransform { get; set; }

        public TankCountController(IPlayerTankList playerTankList, IEnemyTankList enemyTankList)
        {
            this.PlayerTankList = playerTankList;
            this.EnemyTankList = enemyTankList;
            GameObject prefab = Resources.Load<GameObject>(ResourcesPathes.TANK_COUNT_SPAWN);
            CanvasTransform = GameObject.Instantiate(prefab).transform;
            TankUIBehevior = CanvasTransform.GetComponent<ITankUIBehevior>();
        }
        public void Update(float deltaTime)
        {
            TankUIBehevior.PlayerCount.text = PlayerTankList.playerTanks.Count.ToString();
            TankUIBehevior.EnemyCaount.text = EnemyTankList.enemyTanks.Count.ToString();
        }

    }
}
