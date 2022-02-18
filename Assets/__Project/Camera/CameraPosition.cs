using UnityEngine;

namespace Tank_Game
{
    public sealed class CameraPosition : ICameraPosition
    {
        private Transform _playerTankTransform;
        private ICameraSettings _cameraSettings;

        public CameraPosition(Transform target)
        {
            _playerTankTransform = target;
            _cameraSettings = new CameraSettings();
        }

        public Vector3 GetNormalCameraPosition()
        {
            Vector3 cameraGlobalOffSet = Vector3.zero;
            cameraGlobalOffSet += _playerTankTransform.forward * _cameraSettings.offSet.z;
            cameraGlobalOffSet += _playerTankTransform.up * _cameraSettings.offSet.y;
            cameraGlobalOffSet += _playerTankTransform.right * _cameraSettings.offSet.x;

            return _playerTankTransform.position + cameraGlobalOffSet;
        }
    }
}
