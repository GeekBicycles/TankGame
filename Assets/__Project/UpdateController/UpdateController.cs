using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class UpdateController : IUpdateController
    {
        private List<IUpdate> updateList;
        private List<IFixedUpdate> fixedUpdateList;
        private List<ILateUpdate> lateUpdateList;
        private List<IUnscaledUpdate> unscaledUpdateList;

        public UpdateController()
        {
            updateList = new List<IUpdate>();
            fixedUpdateList = new List<IFixedUpdate>();
            lateUpdateList = new List<ILateUpdate>();
            unscaledUpdateList = new List<IUnscaledUpdate>();
        }

        public void Update(float deltaTime)
        {
            foreach (IUpdate controller in updateList)
            {
                controller.Update(deltaTime);
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            foreach (IFixedUpdate controller in fixedUpdateList)
            {
                controller.FixedUpdate(fixedDeltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            foreach (ILateUpdate controller in lateUpdateList)
            {
                controller.LateUpdate(deltaTime);
            }
        }

        public void UnscaledUpdate(float unscaledDeltaTime)
        {
            foreach (IUnscaledUpdate controller in unscaledUpdateList)
            {
                controller.UnscaledUpdate(unscaledDeltaTime);
            }
        }

        public void AddController(IUpdatable updatable)
        {
            if (updatable is IUpdate updateController) updateList.Add(updateController);
            if (updatable is IFixedUpdate fixedUpdateController) fixedUpdateList.Add(fixedUpdateController);
            if (updatable is ILateUpdate lateUpdateController) lateUpdateList.Add(lateUpdateController);
            if (updatable is IUnscaledUpdate unscaledUpdateController) unscaledUpdateList.Add(unscaledUpdateController);
        }

        public void RemoveController(IUpdatable updatable)
        {
            if (updatable is IUpdate updateController) updateList.Remove(updateController);
            if (updatable is IFixedUpdate fixedUpdateController) fixedUpdateList.Remove(fixedUpdateController);
            if (updatable is ILateUpdate lateUpdateController) lateUpdateList.Remove(lateUpdateController);
            if (updatable is IUnscaledUpdate unscaledUpdateController) unscaledUpdateList.Remove(unscaledUpdateController);
        }

    }
}
