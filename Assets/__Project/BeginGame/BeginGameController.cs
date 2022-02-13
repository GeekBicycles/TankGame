using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class BeginGameController : IUpdate
    {
        private IInputData inputData;
        private Action actionBeginGame = delegate { };

        public BeginGameController(IInputData inputData, Action action)
        {
            this.inputData = inputData;
            this.actionBeginGame = action;
        }

        public void Update(float deltaTime)
        {
            if (inputData.fire) BeginGame();
        }

        private void BeginGame()
        {
            GameObject canvas = GameObject.Find("MessageCanvas");
            canvas?.SetActive(false);
            actionBeginGame?.Invoke();
        }
    }
}
