namespace Tank_Game
{
    public interface IHelicopterController
    {
        public IHelicopterList GetHelicopterList();
        public void SetTargets(IPlayerTankList playerTankList);
    }
}
