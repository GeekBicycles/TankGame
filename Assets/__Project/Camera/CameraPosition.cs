using UnityEngine;

namespace Tank_Game
{
    public sealed class CameraPosition : ICameraPosition
    {

        private IPlayerTankList _playerTankList;
        private ICameraSettings _cameraSettings;

        public CameraPosition(IPlayerTankList playerTankList)
        {
            _playerTankList = playerTankList;
            _cameraSettings = new CameraSettings();
        }

        public Vector3 GetNormalCameraPosition()
        {
            Vector3 cameraGlobalOffSet = Vector3.zero;
            Transform _playerTankTransform = _playerTankList.current.view.transform;
            cameraGlobalOffSet += _playerTankTransform.forward * _cameraSettings.offSet.z;
            cameraGlobalOffSet += _playerTankTransform.up * _cameraSettings.offSet.y;
            cameraGlobalOffSet += _playerTankTransform.right * _cameraSettings.offSet.x;

            return _playerTankTransform.position + cameraGlobalOffSet;
        }
    }
}
