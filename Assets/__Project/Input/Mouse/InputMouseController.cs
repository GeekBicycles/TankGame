using UnityEngine;

namespace Tank_Game
{
    public class InputMouseController : IUpdate
    {
        private IInputMouseData _inputMouseData;
        private IMouseSetControl _mouseSetControl;

        public InputMouseController(IInputMouseData inputMouseData, IMouseSetControl mouseDetControl)
        {
            _inputMouseData = inputMouseData;
            _mouseSetControl = mouseDetControl;
        }

        public void Update(float deltaTime)
        {
            _inputMouseData.mouse0 = Input.GetKey(_mouseSetControl.mouse0);
            _inputMouseData.mouse1 = Input.GetKey(_mouseSetControl.mouse1);
            _inputMouseData.mousePosition = Input.mousePosition;
        }
    }
}
