using System;
using UnityEngine;

namespace Tank_Game
{
    public sealed class BeginGameController : IUpdate
    {
        private IInputData inputData;
        private Action actionBeginGame = delegate { };
        private GameObject beginCanvas;

        public BeginGameController(IInputData inputData, Action action)
        {
            this.inputData = inputData;
            this.actionBeginGame = action;
            beginCanvas = GameObject.Find(SceneObjectNames.BEGIN_CANVAS);
        }

        public void Update(float deltaTime)
        {
            if (inputData.FireUp) BeginGame();
        }

        private void BeginGame()
        {
            beginCanvas?.SetActive(false);
            actionBeginGame?.Invoke();
        }
    }
}
