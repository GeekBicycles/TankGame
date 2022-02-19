namespace Tank_Game
{
    public interface IBulletPowerFire
    {
        public bool isBulletReady { get; set; }

        public float GetFirePower();
        public void Update(float deltaTime);
    }
}