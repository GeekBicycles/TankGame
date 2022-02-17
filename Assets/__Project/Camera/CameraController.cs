using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class CameraController :  ICameraSettings,  ILateUpdate

    {
        private Camera _mainCamera;
        public Camera mainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
        private Transform _mainCameraPosition;
        public Transform mainCameraPosition { get { return _mainCameraPosition; } set { _mainCameraPosition = value; } }

        private Transform _target;
        public Transform target { get { return _target; } set { _target = value; } }

        private Vector3 _camOffset;
        public Vector3 camOffset { get { return _camOffset; } set { _camOffset = new Vector3(-15f, 20f, -25f); } }

        //Sergey - compatibility
        public Vector3 offSet { get; set; }

        public CameraController(Transform target)
        {
            _target = target;
            _mainCamera = mainCamera;
            _mainCameraPosition = mainCamera.transform;
            _mainCameraPosition.LookAt(_target);
            _camOffset = _mainCameraPosition.position - _target.position;
        }

        public void LateUpdate(float deltaTime)
        {
            _mainCameraPosition.position = _target.position + _camOffset;
        }
    }
}
