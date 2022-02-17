using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class CameraSettings : ICameraSettings
    {
        public Vector3 offSet { get; set; } = new Vector3(0, 10, -10);
    }
}
