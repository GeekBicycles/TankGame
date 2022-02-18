using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tank_Game
{
    public class ChooseEnemy : IUpdate
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
                IRunRay _runRay = new RunRay(_camera, _mouseData);
                if (_runRay.StartRay().transform.TryGetComponent(out EnemyTankBehaviour enemy))
                {
                    actionChooseEnemy?.Invoke(enemy.transform);
                }
            }
        }
    }
}
