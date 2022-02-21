using UnityEngine;

namespace Tank_Game
{
    public class TankCountController : IUpdate
    {
        private IPlayerTankList playerTankList;
        private IEnemyTankList enemyTankList;
        private Transform canvas;
        private TankUIBehevior tankUIBehevior;
        public TankCountController(IPlayerTankList playerTankList, IEnemyTankList enemyTankList)
        {
            this.playerTankList = playerTankList;
            this.enemyTankList = enemyTankList;
            GameObject prefab = Resources.Load<GameObject>("UI/TankCount");
            canvas = GameObject.Instantiate(prefab).transform;
            tankUIBehevior = canvas.GetComponent<TankUIBehevior>();
        }
        public void Update(float deltaTime)
        {

            tankUIBehevior.playerCount.text = playerTankList.playerTanks.Count.ToString();
            tankUIBehevior.enemyCaount.text = enemyTankList.enemyTanks.Count.ToString();

            //tankCount.view.EnemyTankCount = enemyTankList.enemyTanks.Count;
            //tankCount.view.PlayerCountText.text = tankCount.view.PlayerTankCount.ToString();
            //tankCount.view.EnemyCountText.text = tankCount.view.EnemyTankCount.ToString();
        }

    }
}
