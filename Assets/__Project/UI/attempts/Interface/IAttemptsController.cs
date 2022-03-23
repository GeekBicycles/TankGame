using UnityEngine;

namespace Tank_Game
{
    public interface IAttemptsController
    {
        public IPlayerTankList playerTankList { get; set; }
        public IEnemyTankList enemyTankList { get; set; }
        public IAttermptsBehavior attermptsBehavior { get; set; }
        public Transform canvasTransform { get; set; }
    }
}
