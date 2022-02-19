using UnityEngine;

namespace Tank_Game
{
    public sealed class RotateController : IRotateController
    {
        private IPlayerTank _playerTank;
        private IInputData _inputData;
        public RotateController(IPlayerTank playerTank, IInputData inputData)
        {
            _playerTank = playerTank;
            _inputData = inputData;
        }

        public void Rotate(float deltaTime)
        {
            float rotatedirection = (_inputData.right ? 1 : 0) - (_inputData.left ? 1 : 0);
            Vector3 rotation = new Vector3(0, rotatedirection * _playerTank.model.rotateSpeed * deltaTime, 0);
            _playerTank.view.transform.Rotate(rotation);
        }
    }
}
