using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class EndGameController : IUpdate
    {
        private IPlayerTank playerTank;
        private IEnemyTankList enemyTankList;

        public EndGameController(IPlayerTank playerTank, IEnemyTankList enemyTankList)
        {
            this.playerTank = playerTank;
            this.enemyTankList = enemyTankList;
        }

        public void Update(float deltaTime)
        {
            //Проверка нулегого здоровья или все танки уничтожены
            throw new System.NotImplementedException();
        }
    }
}
