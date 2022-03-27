using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Tank_Game
{
    public class EnemyTankView : IEnemyTankView
    {
        public Transform transform { get; private set; }
        public Transform bulletSpawnTransform { get; private set; }
        public NavMeshAgent navMeshAgent { get; private set; }
        public IEnemyTankBehaviour enemyTankBehaviour { get; private set; }
        public Collider collider { get; }
        public Transform _pursuitPoint { get; }
        public HealthSlider healthSlider { get; set; }
        
        public EnemyTankView()
        {

        }

        private void CalculateComponents()
        {
            bulletSpawnTransform = transform.GetComponentInChildren<IBulletSpawnTransform>().bulletSpawnTransform;
            navMeshAgent = transform.GetComponent<NavMeshAgent>();
            enemyTankBehaviour = transform.gameObject.GetComponent<EnemyTankBehaviour>();
            if (enemyTankBehaviour == null)
            {
                enemyTankBehaviour = transform.gameObject.AddComponent<EnemyTankBehaviour>();
            }
            healthSlider = transform.GetComponent<HealthSlider>();
        }

        public void AttachTransform(Transform transform)
        {
            this.transform = transform;
            CalculateComponents();
        }
        public void AttachTransform(Transform transform, IEnemyTank enemyTank)
        {
            AttachTransform(transform);
            enemyTankBehaviour.enemyTank = enemyTank;
        }

        public EnemyTankView(Transform transform)
        {
            AttachTransform(transform);
        }

        public object Clone()
        {
            EnemyTankView newEnemyTankView = new EnemyTankView();
            return newEnemyTankView;
        }
    }
}
