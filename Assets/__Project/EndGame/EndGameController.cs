using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tank_Game
{
    public class EndGameController : IUpdate
    {
        private IPlayerTankList _currentPlayerTankCount;
        private IEnemyTankList _currentEnemyTankCount;
        private bool _isUpdateble;
        public event Action actionPlayerWin;
        public event Action actionEnemyWin;

        public EndGameController(IPlayerTankList playerList, IEnemyTankList enemyList)
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
                    actionEnemyWin?.Invoke();
                    new EndGame(false);
                }

                else if (_currentEnemyTankCount.enemyTanks.Count <= 0)
                {
                    _isUpdateble = false;
                    actionPlayerWin?.Invoke();
                    new EndGame(true);
                }
            }
        }
    }
}
