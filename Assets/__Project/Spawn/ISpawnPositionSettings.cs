namespace Tank_Game
{
    public interface ISpawnPositionSettings
    {
        string groundNameGameObject { get; }
        float fieldMaxX { get; }
        float fieldMaxY { get; }
        float fieldMinX { get; }
        float fieldMinY { get; }
        float radiusOverlapSphere { get; }
    }
}