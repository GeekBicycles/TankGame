using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class FireController : IFireController
    {
        private IPlayerTank playerTank;
        private IInputData inputData;
        private IBulletController bulletController;

        public FireController(IPlayerTank playerTank, IInputData inputData, IBulletController bulletController)
        {
            this.playerTank = playerTank;
            this.inputData = inputData;
            this.bulletController = bulletController;
        }

        public void FireControl(float deltaTime)
        {
            playerTank.timeToFire += deltaTime;
            if (playerTank.timeToFire >= playerTank.model.maxTimeToFire)
            {
                if (inputData.fire)
                {
                    playerTank.timeToFire = 0;
                    bulletController.Fire(playerTank.view.bulletSpawnTransform.position, playerTank.view.bulletSpawnTransform.rotation, playerTank.model.maxBulletSpeed);
                }
            }
        }
    }
}
