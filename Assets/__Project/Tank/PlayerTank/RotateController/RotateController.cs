using UnityEngine;

namespace Tank_Game
{
    public sealed class RotateController : IRotateController
    {
        private IInputData _inputData;
        public RotateController(IInputData inputData)
        {
            _inputData = inputData;
        }

        public void Rotate(float deltaTime, IPlayerTank playerTank)
        {
            if (playerTank == null) return;
            float rotatedirection = (_inputData.right ? 1 : 0) - (_inputData.left ? 1 : 0);
            Vector3 rotation = new Vector3(0, rotatedirection * playerTank.model.rotateSpeed * deltaTime, 0);
            playerTank.view.transform.Rotate(rotation);
        }
    }
}
