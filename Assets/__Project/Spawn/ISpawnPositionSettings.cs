namespace Tank_Game
{
    public interface ISpawnPositionSettings
    {
        string groundNameGameObject { get; set; }
        float fieldMaxX { get; set; }
        float fieldMaxY { get; set; }
        float fieldMinX { get; set; }
        float fieldMinY { get; set; }
        float radiusOverlapSphere { get; set; }
    }
}