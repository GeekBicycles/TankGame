using UnityEngine;

namespace Tank_Game
{
    public sealed class MoveController : IMoveController
    {
        private IInputData _inputData;
        private IPlayerTank _playerTank;

        public MoveController(IInputData inputData, IPlayerTank playerTank)
        {
            _inputData = inputData;
            _playerTank = playerTank;
        }

        public void Move(float deltaTime)
        {
            float z = (_inputData.up ? 1 : 0) - (_inputData.down ? 1 : 0);
            Vector3 movement = new Vector3(0, 0, z);
            movement = movement * _playerTank.model.speed * deltaTime;
            _playerTank.view.transform.Translate(movement);
        }
    }
}
