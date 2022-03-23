using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class TwinController : ITwinController
    {
        private IHelicopter _helicopter;
        private Transform _twin;
        private float targetTwinSpeed;
        private bool _rightRotate;

        public TwinController(IHelicopter helicopter, Transform twin, bool rightRotate)
        {
            _helicopter = helicopter;
            _twin = twin;
            targetTwinSpeed = 0;
            _rightRotate = rightRotate;
        }

        public void SetTwinSpeed(float speed)
        {
            targetTwinSpeed = Mathf.Clamp(speed, 0f, _helicopter.model.maxTwinSpeed);
        }

        public bool SpeedReached()
        {
            return Mathf.Approximately(_helicopter.currentTwinSpeed, targetTwinSpeed);
        }

        public void Update(float deltaTime)
        {
            _helicopter.currentTwinSpeed = Mathf.MoveTowards(_helicopter.currentTwinSpeed, targetTwinSpeed, _helicopter.model.changeTwinSpeed * deltaTime);
            if (_rightRotate)
            {
                _twin.transform.Rotate(0, _helicopter.currentTwinSpeed * deltaTime, 0);
            }
            else
            {
                _twin.transform.Rotate(0, -_helicopter.currentTwinSpeed * deltaTime, 0);
            }

        }
    }
}
