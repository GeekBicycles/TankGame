using UnityEngine;
using System;

namespace Tank_Game
{
    public class ChooseEnemy : IUpdate, IChooseEnemy
    {
        private Camera _camera;
        private IInputMouseData _mouseData;
        public event Action<Transform> actionChooseEnemy;

        public ChooseEnemy(IInputMouseData mouseData)
        {
            _mouseData = mouseData;
            _camera = Camera.main;
        }
        public void Update(float deltaTime)
        {
            if (_mouseData.mouse0)
            {
                IRunRay runRay = new RunRay(_camera, _mouseData);
                if (runRay.StartRay().transform.TryGetComponent(out IEnemyTankBehaviour enemyBehaviour))
                {
                    actionChooseEnemy?.Invoke(enemyBehaviour.enemyTank.view.transform);
                }
            }
        }
    }
}