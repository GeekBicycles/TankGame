using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class CameraController : ILateUpdate
    {
        private IPlayerTank playerTank;
        private ICameraPosition cameraPosition;
        private Transform cameraTransform;
        public CameraController(IPlayerTank playerTank)
        {
            cameraTransform = Camera.main.transform;
            this.playerTank = playerTank;
            cameraPosition = new CameraPosition(playerTank);

        }

        public void LateUpdate(float deltaTime)
        {
            cameraTransform.position = cameraPosition.GetNormalCameraPosition();
            cameraTransform.LookAt(playerTank.view.transform.position);
        }
    }
}
