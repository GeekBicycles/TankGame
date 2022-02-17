using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class CameraSettings : ICameraSettings
    {
        public Vector3 offSet { get; set; } = new Vector3(0, 10, -10);

        //Added
        public Camera mainCamera { get; }
        public Vector3 camOffset { get; set; }
        public Transform target { get; set; }
        public Transform mainCameraPosition { get; set; }
    }
}
