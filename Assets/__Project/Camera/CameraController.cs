using UnityEngine;

namespace Tank_Game
{
    public class CameraController :  ILateUpdate
    {
        private IPlayerTankList _playerTankList;
        private ICameraPosition _cameraPosition;
        private Camera _mainCamera;

        public CameraController(IPlayerTankList playerTankList)
        {
            _playerTankList = playerTankList;
            _mainCamera = Camera.main;
            _cameraPosition = new CameraPosition(playerTankList);
        }

        public void LateUpdate(float deltaTime)
        {
            if (_playerTankList.current == null)
            {
                return;
            }
            _mainCamera.transform.position = _cameraPosition.GetNormalCameraPosition();
            _mainCamera.transform.LookAt(_playerTankList.current.view.transform);
        }
    }
}
