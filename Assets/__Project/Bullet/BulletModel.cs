namespace Tank_Game
{
    internal class BulletModel : IBulletModel
    {
        public float Speed { get; set; }
        public int Damage { get; set; }
        public BulletModel(float speed, int damage)
        {
            Speed = speed;
            Damage = damage;
        }

    }
}