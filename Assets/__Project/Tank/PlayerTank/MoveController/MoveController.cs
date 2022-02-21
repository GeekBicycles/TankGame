using UnityEngine;

namespace Tank_Game
{
    public sealed class MoveController : IMoveController
    {
        private IInputData _inputData;

        public MoveController(IInputData inputData)
        {
            _inputData = inputData;
        }

        public void Move(float deltaTime, IPlayerTank playerTank)
        {
            if (playerTank == null) return;
            float z = (_inputData.up ? 1 : 0) - (_inputData.down ? 1 : 0);
            Vector3 movement = new Vector3(0, 0, z);
            movement = movement * playerTank.model.speed * deltaTime;
            playerTank.view.transform.Translate(movement);
        }
    }
}
