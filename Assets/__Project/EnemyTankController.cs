using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class EnemyTankController : IUpdate
    {
        private float time = 3;
        private float speedfire;
        private BulletFactory bulletFactory;
        GameObject[] Fire = GameObject.FindGameObjectsWithTag("FireBot");
        private IEnemyTank enemyTank;
        public EnemyTankController(IEnemyTank enemyTank, BulletFactory bulletFactory)
        {
            this.bulletFactory = bulletFactory;
            this.enemyTank = enemyTank;
            
        }

        public void Update(float deltaTime)
        {
            time -= deltaTime;
            if (time <= 0)
            {
                foreach (GameObject FireTransform in Fire)
                {
                    Transform bulletSpawnPoint = enemyTank.transform.GetComponentInChildren<EnemyTankBehavior>().bulletSpawnPoint;
                    bulletFactory.Fire(bulletSpawnPoint.position, speedfire, bulletSpawnPoint.rotation);
                }
                 
            }
        }
    }
}
