namespace Tank_Game
{
    public interface ITwinController : IUpdate
    {
        void SetTwinSpeed(float speed);

        bool SpeedReached();
    }
}