using UnityEngine;

namespace Tank_Game
{
    public interface ITankCountController
    {
        public IPlayerTankList PlayerTankList { get; set; }
        public ITankUIBehevior TankUIBehevior { get; set; }
        public IEnemyTankList EnemyTankList { get; set; }
        public Transform CanvasTransform { get; set; }
    }
}
