using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class ChooseEnemy : IUpdate
    {
        private Collider _enemyCollider;
        private Camera _camera;
        private IPlayerTank _player;
        private IInputMouseData _mouseData;

        public ChooseEnemy(IInputMouseData mouseData, IPlayerTank player, Camera camera)
        {
            _mouseData = mouseData;
            _player = player;
            _camera = camera;
        }
        public void Update(float deltaTime)
        {
            if (_mouseData.mouse0)
            {
                IRunRay _runRay = new RunRay(_camera, _mouseData);
                if (_runRay.StartRay().transform.TryGetComponent(out EnemyTankBehaviour enemy))
                {
                    _player.view.transform.LookAt(enemy.transform);
                }
            }
        }

    }
}
