using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class ChoosePlayerTank: IUpdate, IChooseTank
    {
        private IPlayerTankList _playerTankList;
        public KeyCode playerSwitch = KeyCode.C;
        public event Action<IPlayerTank> actionChoosePlayer;
        public ChoosePlayerTank(IPlayerTankList playerTankListData)
        {
            _playerTankList = playerTankListData;
        }
        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(playerSwitch))
            {
                if (_playerTankList.current == null)
                {
                    return;
                }
                int currentIndex = _playerTankList.playerTanks.IndexOf(_playerTankList.current);
                currentIndex++;
                if (currentIndex > _playerTankList.playerTanks.Count - 1)
                {
                    currentIndex = 0;
                }
                IPlayerTank newPlayerTank = _playerTankList.playerTanks[currentIndex];

                actionChoosePlayer?.Invoke(newPlayerTank);
            }
        }
    }
}
