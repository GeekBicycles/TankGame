namespace Tank_Game
{
    public interface IPlayerTankModel
    {
        public float health { get; }
        public float speed { get; }
        public float maxBulletSpeed { get; }
        public float gravity { get; }
        public float maxTimeToFire { get; }
        public float rotateSpeed { get; }
    }
}