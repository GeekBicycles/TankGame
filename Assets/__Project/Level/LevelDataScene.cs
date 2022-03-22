using UnityEngine;

namespace Tank_Game
{
    public class LevelDataScene : MonoBehaviour, ILevelDataScene
    {
        public ILevelData levelData { get; set; }
    }
}
