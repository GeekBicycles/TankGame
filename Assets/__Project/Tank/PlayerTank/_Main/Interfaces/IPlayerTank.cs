namespace Tank_Game
{
    public interface IPlayerTank
    {
        public IPlayerTankModel model { get; }
        public IPlayerTankView view { get; }
        public float timeToFire { get; set; }
        public float health { get; set; }
    }
}