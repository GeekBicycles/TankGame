using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class TurnBasedController : IUpdate, IFixedUpdate, ILateUpdate, IUnscaledUpdate
    {
        private List<IUpdateController> updateControllers;
        private int turnIndex;
        private IUpdateController currentController;
        private bool enable;

        public TurnBasedController()
        {
            updateControllers = new List<IUpdateController>();
            turnIndex = 0;
            currentController = null;
            enable = false;
        }

        public void AddController(IUpdateController updateController)
        {
            updateControllers.Add(updateController);
        }

        public void RemoveController(IUpdateController updateController)
        {
            int removeIndex = updateControllers.IndexOf(updateController);

            RemoveController(removeIndex);
        }

        private void RemoveController(int removeIndex)
        {
            if (turnIndex > removeIndex) turnIndex--;
            updateControllers.RemoveAt(removeIndex);
            if (updateControllers.Count == 0) enable = false;
            if (turnIndex > updateControllers.Count - 1) turnIndex = 0;
            SetCurrentController();
        }

        private void SetCurrentController()
        {
            if (!enable)
            {
                currentController = null;
                return;
            }

            if (updateControllers[turnIndex] == null)
            {
                RemoveController(turnIndex);
            }
            else
            {
                currentController = updateControllers[turnIndex];
            }
        }

        public void Start()
        {
            enable = true;
            turnIndex = 0;
            SetCurrentController();
        }

        public bool SetEnable(bool value)
        {
            if (value == false)
            {
                enable = false;
                currentController = null;
                return true;
            }

            if (updateControllers.Count == 0)
            {
                enable = false;
                currentController = null;
                return false;
            }

            if (turnIndex > updateControllers.Count - 1) turnIndex = 0;
            enable = true;
            SetCurrentController();

            return enable;

        }

        public void NextTurn()
        {
            turnIndex = (turnIndex + 1) % updateControllers.Count;
            SetCurrentController();
        }

        public void Stop()
        {
            SetEnable(false);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            if (enable) currentController.FixedUpdate(fixedDeltaTime);
        }

        public void LateUpdate(float deltaTime)
        {
            if (enable) currentController.LateUpdate(deltaTime);
        }

        public void UnscaledUpdate(float unscaledDeltaTime)
        {
            if (enable) currentController.UnscaledUpdate(unscaledDeltaTime);
        }

        public void Update(float deltaTime)
        {
            if (enable) currentController.Update(deltaTime);
        }
    }
}

