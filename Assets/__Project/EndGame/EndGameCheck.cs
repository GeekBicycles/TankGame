using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class EndGameCheck : IUpdate
    {
        private IPlayerTankList _currentPlayerTankCount;
        private IEnemyTankList _currentEnemyTankCount;
        private bool _isUpdateble;

        public EndGameCheck(IPlayerTankList playerList, IEnemyTankList enemyList)
        {
            _currentPlayerTankCount = playerList;
            _currentEnemyTankCount = enemyList;
            _isUpdateble = true;
        }
        public void Update(float deltaTime)
        {
            if (_isUpdateble)
            {
                if (_currentPlayerTankCount.playerTanks.Count <= 0)
                {
                    _isUpdateble = false;
                    new EndGameController(false);
                }

                else if (_currentEnemyTankCount.enemyTanks.Count <= 0)
                {
                    _isUpdateble = false;
                    new EndGameController(true);
                }
            }
        }
    }
}
