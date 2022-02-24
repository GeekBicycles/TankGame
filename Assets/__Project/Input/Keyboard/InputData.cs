namespace Tank_Game
{
    public sealed class InputData : IInputData
    {
        public bool up { get; set; }
        public bool down { get; set; }
        public bool left { get; set; }
        public bool right { get; set; }
        public bool fire { get; set; }
        public bool FireUp { get; set; }

        public InputData()
        {
            up = false;
            down = false;
            left = false;
            right = false;
            fire = false;
            FireUp = false;
        }
    }
}
