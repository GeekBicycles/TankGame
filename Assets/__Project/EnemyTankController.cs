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
        public EnemyTankController(/*IEnemyTank enemyTank, */BulletFactory bulletFactory)
        {
            this.bulletFactory = bulletFactory;
            
        }

        public void Update(float deltaTime)
        {
            time -= deltaTime;
            if (time <= 0)
            {
                foreach (GameObject FireTransform in Fire)
                {
                    bulletFactory.Fire(FireTransform.transform.position, speedfire, FireTransform.transform.rotation);
                }
                 
            }
        }
    }
}
