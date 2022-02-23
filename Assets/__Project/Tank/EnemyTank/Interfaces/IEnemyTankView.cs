using UnityEngine;
using UnityEngine.AI;


namespace Tank_Game
{
    public interface IEnemyTankView
    {
        public Transform transform { get; }
        public Transform bulletSpawnTransform { get; }
        public NavMeshAgent navMeshAgent { get; }
        public IEnemyTankBehaviour enemyTankBehaviour { get; }
        public Collider collider { get; }
        public Transform _pursuitPoint { get; }
        public HealthSlider healthSlider { get; set; }
    }
}