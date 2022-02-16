using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class RotateController : IRotateController
    {
        private IPlayerTank playerTank;
        private IInputData inputData;
        public RotateController(IPlayerTank playerTank, IInputData inputData)
        {
            this.playerTank = playerTank;
            this.inputData = inputData;
        }

        public void Rotate(float deltaTime)
        {
            float rotatedirection = (inputData.right ? 1 : 0) - (inputData.left ? 1 : 0);
            Vector3 rotation = new Vector3(0, rotatedirection * playerTank.model.rotateSpeed * deltaTime, 0);
            playerTank.view.transform.Rotate(rotation);
        }
    }
}
