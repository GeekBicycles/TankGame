using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class CameraPosition : ICameraPosition
    {
        private IPlayerTank playerTank;
        private ICameraSettings cameraSettings;
        public CameraPosition(IPlayerTank playerTank)
        {
            this.playerTank = playerTank;
            this.cameraSettings = new CameraSettings();
        }

        public Vector3 GetNormalCameraPosition()
        {
            Vector3 cameraGlobalOffSet = Vector3.zero;
            cameraGlobalOffSet += playerTank.view.transform.forward * cameraSettings.offSet.z;
            cameraGlobalOffSet += playerTank.view.transform.up * cameraSettings.offSet.y;
            cameraGlobalOffSet += playerTank.view.transform.right * cameraSettings.offSet.x;
            

            return playerTank.view.transform.position + cameraGlobalOffSet;
        }
    }
}
