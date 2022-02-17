namespace Tank_Game
{
    public interface IBulletPowerFire
    {
        public bool isBulletReady { get; set; }
        float GetFirePower();
        void Update(float deltaTime);
    }
}