using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Tank_Game
{
    public class BulletPowerFire : IUpdate, IBulletPowerFire
    {
        private IInputData _inputData;
        private float _powerPressFire = 0f;
        private float _currentFirePower = 0f;
        private bool _startPressFireButton = false;
        private bool _stopPressFireButton = true;
        private float _maxPower = 2f;

        public bool isBulletReady { get; set; } = false;

        public BulletPowerFire(IInputData inputData)
        {
            _inputData = inputData;
        }
        public void Update(float deltaTime)
        {
            if (_inputData.fire && _stopPressFireButton)
            {
                _stopPressFireButton = false;
                _startPressFireButton = true;
            }
            else if (_startPressFireButton && !_inputData.fire)
            {
                _currentFirePower = _powerPressFire;
                isBulletReady = true;
                Reset();
            }

            if (_startPressFireButton)
            {
                if (_powerPressFire < _maxPower)
                {
                    _powerPressFire += deltaTime;
                }
                else
                {
                    _powerPressFire = _maxPower;
                }
            }
        }

        public float GetFirePower()
        {
            return _currentFirePower;
        }

        private void Reset()
        {
            _powerPressFire = 0f;
            _startPressFireButton = false;
            _stopPressFireButton = true;
        }

    }
}
