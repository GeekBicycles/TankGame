using UnityEngine;

namespace Tank_Game
{
    public class CameraController :  ILateUpdate
    {
        private Transform _target;
        private ICameraPosition _cameraPosition;
        private Camera _mainCamera;

        public CameraController(Transform target)
        {
            _target = target;
            _mainCamera = Camera.main;
            _cameraPosition = new CameraPosition(target);
        }

        public void LateUpdate(float deltaTime)
        {
            _mainCamera.transform.position = _cameraPosition.GetNormalCameraPosition();
            _mainCamera.transform.LookAt(_target);
        }
    }
}
