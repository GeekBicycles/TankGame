using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class AttermptsController : IAttemptsController
    {
        #region interface
        public IPlayerTankList playerTankList { get; set; }
        public IAttermptsBehavior attermptsBehavior { get; set; }
        public Transform canvasTransform { get; set; }
        #endregion
        private float _attemptsCount = 3;

        public AttermptsController(IPlayerTankList playerTankList)
        {
            this.playerTankList = playerTankList;

        }

        public IPlayerTank GetPlayerTank()
        {
            return playerTankList.current;
        }
        public void counter()
        {
            if (playerTankList.playerTanks.Count == 0)
            {
                _attemptsCount -= Time.deltaTime;
                GetPlayerTank();

            }
            else //Победа
            {}
        }
    }
}
