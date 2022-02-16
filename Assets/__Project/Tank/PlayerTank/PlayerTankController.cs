using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankController : IUpdate, IPlayerTankController
    {
        private IInputData inputData;
        private IBulletController bulletController;
        private IPlayerTank playerTank;
        private IPlayerTankFactory playerTankFactory;
        private IMoveController moveController;
        private IFireController fireController;

        public PlayerTankController(IInputData inputData, IBulletController bulletController)
        {
            this.inputData = inputData;
            this.bulletController = bulletController;
            playerTankFactory = new PlayerTankFactory();
            playerTank = playerTankFactory.GetPlayerTank(Vector3.zero, Quaternion.identity);
            moveController = new MoveController(inputData, this.playerTank);
            fireController = new FireController(playerTank, inputData, bulletController);
        }

        public IPlayerTank GetPlayerTank()
        {
            return playerTank;
        }

        public void Update(float deltaTime)
        {
            moveController.Move(deltaTime);

            fireController.FireControl(deltaTime);
        }

    }
}
