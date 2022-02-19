using UnityEngine;
using UnityEngine.AI;

namespace Tank_Game
{
    public class EnemyTankView : IEnemyTankView
    {
        public Transform transform { get; }
        public Transform bulletSpawnTransform { get; }
        public NavMeshAgent navMeshAgent { get; }
        public IEnemyTankBehaviour enemyTankBehaviour { get; }
        public Collider collider { get; }
        public Transform _pursuitPoint { get; }

        public EnemyTankView(Transform transform)
        {
            this.transform = transform;
            bulletSpawnTransform = transform.GetComponentInChildren<IBulletSpawnTransform>().bulletSpawnTransform;
            navMeshAgent = transform.GetComponent<NavMeshAgent>();
            enemyTankBehaviour = transform.gameObject.AddComponent<EnemyTankBehaviour>();
        }
    }
}
