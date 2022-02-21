using UnityEngine;

namespace Tank_Game
{
    public class TankCountController : IUpdate
    {
        private IPlayerTankList playerTankList;
        private IEnemyTankList enemyTankList;
        public TankCountController(IPlayerTankList playerTankList, IEnemyTankList enemyTankList)
        {
            this.playerTankList = playerTankList;
            this.enemyTankList = enemyTankList;
        }
        public void Update(float deltaTime)
        {
            //tankCount.view.PlayerTankCount = playerTankList.playerTanks.Count;
            //tankCount.view.EnemyTankCount = enemyTankList.enemyTanks.Count;
            //tankCount.view.PlayerCountText.text = tankCount.view.PlayerTankCount.ToString();
            //tankCount.view.EnemyCountText.text = tankCount.view.EnemyTankCount.ToString();
        }

    }
}
