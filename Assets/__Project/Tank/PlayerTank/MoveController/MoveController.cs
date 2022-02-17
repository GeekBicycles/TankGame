using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class MoveController : IMoveController
    {
        private IInputData inputData;
        private IPlayerTank playerTank;

        public MoveController(IInputData inputData, IPlayerTank playerTank)
        {
            this.inputData = inputData;
            this.playerTank = playerTank;
        }

        public void Move(float deltaTime)
        {
            float z = (inputData.up ? 1 : 0) - (inputData.down ? 1 : 0);
            Vector3 movement = new Vector3(0, 0, z);
            movement = movement * playerTank.model.speed * deltaTime;
            playerTank.view.transform.Translate(movement);
        }
    }
}
