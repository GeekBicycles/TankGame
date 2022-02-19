namespace Tank_Game
{
    public class Bullet : IBullet
    {
        public IBulletModel model { get; }
        public IBulletView view { get;  }

        public Bullet(IBulletModel model, IBulletView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
