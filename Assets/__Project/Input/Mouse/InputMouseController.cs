using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class InputMouseController : IUpdate
    {
        private IInputMouseData inputMouseData { get; set; }
        private IMouseSetControl mouseSetControl { get; set; }

        public InputMouseController(IInputMouseData inputMouseData, IMouseSetControl mouseDetControl)
        {
            this.inputMouseData = inputMouseData;
            this.mouseSetControl = mouseDetControl;
        }

        public void Update(float deltaTime)
        {
            inputMouseData.mouse0 = Input.GetKey(mouseSetControl.mouse0);
            inputMouseData.mouse1 = Input.GetKey(mouseSetControl.mouse1);
        }
    }
}
