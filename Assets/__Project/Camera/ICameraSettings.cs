using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface ICameraSettings
    {
        public Camera mainCamera { get; }
        public Vector3 camOffset { get; set; }
        public Transform target { get; set; }
        public Transform mainCameraPosition { get; set; }

       
    }
}