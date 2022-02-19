namespace Tank_Game
{
    public interface IEnemyTankModel
    {
        public float health { get; }
        public float speed { get; }
        public float maxBulletSpeed { get; }
        public float maxAccuracy { get; }
        public float currentAccuracy { get; }
        public float changeAccuracy { get; }
        public float maxTimeToFire { get; }
        public float bulletforce { get; }
        public float rotateSpeed { get; }
    }
}
