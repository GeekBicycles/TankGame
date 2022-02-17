using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class EnemyTankController : IUpdate, IEnemyTankController
    {
        private IBulletController bulletController;
        private IEnemyTankList enemyTankList;
        private IEnemyTankFactory enemyTankFactory;
        public EnemyTankController(IBulletController bulletController)
        {
            this.enemyTankList = new EnemyTankList();
            this.enemyTankFactory = new EnemyTankFactory();
            this.bulletController = bulletController;
            
        }

        public IEnemyTankList GetEnemyTankList()
        {
            return enemyTankList;
        }

        public void Update(float deltaTime)
        {

            foreach (IEnemyTank enemyTank in enemyTankList.enemyTanks)
            {
                var direction = enemyTank.view.collider.transform.position - enemyTank.view.transform.position;

                if (Physics.Raycast(enemyTank.view.transform.position + Vector3.up, direction, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        enemyTank.view._pursuitPoint = enemyTank.view.collider.transform;
                        return;
                    }
                }
                enemyTank.model.timeToFire += deltaTime;
                if (enemyTank.model.timeToFire >= enemyTank.model.maxTimeToFire)
                {
                    enemyTank.model.timeToFire -= enemyTank.model.maxTimeToFire;
                    //Transform bulletSpawnPoint = enemyTank.view.transform.GetComponentInChildren<EnemyTankBehavior>().bulletSpawnPoint;
                    bulletController.Fire(enemyTank.view.bulletSpawnTransform.position, enemyTank.view.bulletSpawnTransform.rotation, enemyTank.model.bulletforce);
                }

            }
        }

        private void Pursuit(IEnemyTank enemyTank)
        {
            enemyTank.view.navMeshAgent.SetDestination(enemyTank.view._pursuitPoint.position);
        }
    }
}
