using UnityEngine;

namespace Tank_Game
{
    public sealed class CameraSettings : ICameraSettings
    {
        public Vector3 offSet { get; } = new Vector3(0, 20, -10);
    }
}
