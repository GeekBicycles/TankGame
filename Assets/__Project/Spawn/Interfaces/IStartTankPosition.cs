namespace Tank_Game
{
    public interface IStartTankPosition
    {
        public void SetStartupPosition(IPlayerTankList playerTankList, IEnemyTankList enemyTankList);
    }
}