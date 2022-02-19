namespace Tank_Game
{
    public sealed class SpawnPositionSettings : ISpawnPositionSettings
    {
        public float fieldMinX { get; } = -50f;
        public float fieldMaxX { get; } = 50f;
        public float fieldMinY { get; } = -50f;
        public float fieldMaxY { get; } = 50f;
        public float radiusOverlapSphere { get; } = 5;
        public string groundNameGameObject { get; } = "GroundPlane";
    }
}
