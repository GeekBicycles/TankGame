namespace Tank_Game
{
    public interface IHelicopterModel
    {
        public float health { get; }
        public float moveSpeed { get; }
        public float rotateSpeed { get; }
        public float maxFlyHeight { get; }
        public float maxTwinSpeed { get; }
        public float changeTwinSpeed { get; }
    }
}
