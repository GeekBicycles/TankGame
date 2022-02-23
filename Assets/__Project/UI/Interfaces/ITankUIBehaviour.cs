using UnityEngine.UI;

namespace Tank_Game
{
    public interface ITankUIBehaviour
    {
        public Text playerCount { get; }
        public Text enemyCount { get; }
    }
}
