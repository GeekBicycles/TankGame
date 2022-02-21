using UnityEngine;

namespace Tank_Game
{
    public class StartupPosition : MonoBehaviour, IStartupPosition
    {
        [SerializeField] private Transform _playerGroup1Tank1;
        [SerializeField] private Transform _playerGroup2Tank1;
        [SerializeField] private Transform _playerGroup2Tank2;
        [SerializeField] private Transform _playerGroup3Tank1;
        [SerializeField] private Transform _playerGroup3Tank2;
        [SerializeField] private Transform _playerGroup3Tank3;

        [SerializeField] private Transform _enemyGroup1Tank1;
        [SerializeField] private Transform _enemyGroup2Tank1;
        [SerializeField] private Transform _enemyGroup2Tank2;
        [SerializeField] private Transform _enemyGroup3Tank1;
        [SerializeField] private Transform _enemyGroup3Tank2;
        [SerializeField] private Transform _enemyGroup3Tank3;

        public Transform playerGroup1Tank1 { get { return _playerGroup1Tank1; } }
        public Transform playerGroup2Tank1 { get { return _playerGroup2Tank1; } }
        public Transform playerGroup2Tank2 { get { return _playerGroup2Tank2; } }
        public Transform playerGroup3Tank1 { get { return _playerGroup3Tank1; } }
        public Transform playerGroup3Tank2 { get { return _playerGroup3Tank2; } }
        public Transform playerGroup3Tank3 { get { return _playerGroup3Tank3; } }

        public Transform enemyGroup1Tank1 { get { return _enemyGroup1Tank1; } }
        public Transform enemyGroup2Tank1 { get { return _enemyGroup2Tank1; } }
        public Transform enemyGroup2Tank2 { get { return _enemyGroup2Tank2; } }
        public Transform enemyGroup3Tank1 { get { return _enemyGroup3Tank1; } }
        public Transform enemyGroup3Tank2 { get { return _enemyGroup3Tank2; } }
        public Transform enemyGroup3Tank3 { get { return _enemyGroup3Tank3; } }
    }
}
