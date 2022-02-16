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

                //enemyTank.timeToFire += deltaTime;
                //if (enemyTank.timeToFire >= enemyTank.maxTimeToFire)
                //{
                //    enemyTank.timeToFire -= enemyTank.maxTimeToFire;
                //    Transform bulletSpawnPoint = enemyTank.transform.GetComponentInChildren<EnemyTankBehavior>().bulletSpawnPoint;
                //    bulletController.Fire(bulletSpawnPoint.position, bulletSpawnPoint.rotation, enemyTank.bulletforce);
                //}

            }
        }
    }
}
