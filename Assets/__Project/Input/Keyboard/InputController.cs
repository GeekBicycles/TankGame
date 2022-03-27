using UnityEngine;

namespace Tank_Game
{
    public sealed class InputController : IUpdate
    {
        private IInputData _inputData;
        private IKeySetControl _keySetControl;

        public InputController(IInputData inputData, IKeySetControl keySetControl)
        {
            _inputData = inputData;
            _keySetControl = keySetControl;
        }

        public void Update(float deltaTime)
        {
            _inputData.up = Input.GetKey(_keySetControl.up);
            _inputData.down = Input.GetKey(_keySetControl.down);
            _inputData.left = Input.GetKey(_keySetControl.left);
            _inputData.right = Input.GetKey(_keySetControl.right);
            _inputData.fire = Input.GetKey(_keySetControl.fire);
            _inputData.fireUp = Input.GetKeyUp(_keySetControl.fireUp);

        }
    }
}
