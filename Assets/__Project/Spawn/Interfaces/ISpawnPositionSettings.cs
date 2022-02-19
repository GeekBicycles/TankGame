namespace Tank_Game
{
    public interface ISpawnPositionSettings
    {
        public string groundNameGameObject { get; }
        public float fieldMaxX { get; }
        public float fieldMaxY { get; }
        public float fieldMinX { get; }
        public float fieldMinY { get; }
        public float radiusOverlapSphere { get; }
    }
}