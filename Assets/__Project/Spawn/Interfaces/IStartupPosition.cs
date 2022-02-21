using UnityEngine;

namespace Tank_Game
{
    public interface IStartupPosition
    {
        public Transform enemyGroup1Tank1 { get; }
        public Transform enemyGroup2Tank1 { get; }
        public Transform enemyGroup2Tank2 { get; }
        public Transform enemyGroup3Tank1 { get; }
        public Transform enemyGroup3Tank2 { get; }
        public Transform enemyGroup3Tank3 { get; }
        public Transform playerGroup1Tank1 { get; }
        public Transform playerGroup2Tank1 { get; }
        public Transform playerGroup2Tank2 { get; }
        public Transform playerGroup3Tank1 { get; }
        public Transform playerGroup3Tank2 { get; }
        public Transform playerGroup3Tank3 { get; }
    }
}