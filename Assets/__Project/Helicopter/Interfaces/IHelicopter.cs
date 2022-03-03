namespace Tank_Game
{
    public interface IHelicopter
    {
        public IHelicopterModel model { get; }
        public IHelicopterView view { get; }
        public float health { get; set; }
        public float currentTwinSpeed { get; set; }
    }
}
