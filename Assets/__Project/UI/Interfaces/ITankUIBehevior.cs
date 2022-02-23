using UnityEngine.UI;

namespace Tank_Game
{
    public interface ITankUIBehevior
    {
        public Text PlayerCount { get; }
        public Text EnemyCaount { get; }
    }
}
