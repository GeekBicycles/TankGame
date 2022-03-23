namespace Tank_Game
{
    public class Helicopter : IHelicopter
    {
        public IHelicopterModel model { get; }
        public IHelicopterView view { get; }
        public float health { get; set; }

        public float currentTwinSpeed { get; set; }

        public Helicopter(IHelicopterModel model, IHelicopterView view)
        {
            this.model = model;
            this.view = view;
            health = model.health;
            currentTwinSpeed = 0;
        }
    }
}
