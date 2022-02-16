using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class SpawnPositionSettings : ISpawnPositionSettings
    {
        public float fieldMinX { get; set; } = -50f;
        public float fieldMaxX { get; set; } = 50f;
        public float fieldMinY { get; set; } = -50f;
        public float fieldMaxY { get; set; } = 50f;
        public float radiusOverlapSphere { get; set; } = 5;
        public string groundNameGameObject { get; set; } = "GroundPlane";
    }
}
