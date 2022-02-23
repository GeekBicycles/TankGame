using UnityEngine;

namespace Tank_Game
{
    public interface ITankCountController
    {
        public IPlayerTankList playerTankList { get; set; }
        public ITankUIBehaviour tankUIBehaviour { get; set; }
        public IEnemyTankList enemyTankList { get; set; }
        public Transform canvasTransform { get; set; }
    }
}
