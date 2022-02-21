using UnityEngine;

namespace Tank_Game
{
    public interface IKeySetControl
    {
        public KeyCode up { get; }
        public KeyCode down { get; }
        public KeyCode left { get; }
        public KeyCode right { get; }
        public KeyCode fire { get; }
    }
}
