using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class InputController: IUpdate
    {
        private IInputData inputData;
        private IKeySetControl keySetControl;
        public InputController(IInputData inputData, IKeySetControl keySetControl)
        {
            this.inputData = inputData;
            this.keySetControl = keySetControl;
        }

        public void Update(float deltaTime)
        {
            //Debug.Log("InputController.Update");
            inputData.up = Input.GetKey(keySetControl.up);
            inputData.down = Input.GetKey(keySetControl.down);
            inputData.left = Input.GetKey(keySetControl.left);
            inputData.right = Input.GetKey(keySetControl.right);
            inputData.fire = Input.GetKey(keySetControl.fire);
        }
    }
}
