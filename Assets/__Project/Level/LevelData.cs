namespace Tank_Game
{
    public sealed class LevelData : ILevelData
    {
        public int levelNumber { get; set; }

        public LevelData(int levelNumber)
        {
            this.levelNumber = levelNumber;
        }
    }
}
