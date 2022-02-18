using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class EnemyTankSpawn : IEnemyTankSpawn
    {
        private IEnemyTankFactory enemyTankFactory;
        public EnemyTankSpawn(IEnemyTankFactory enemyTankFactory)
        {
            this.enemyTankFactory = enemyTankFactory;
        }
        public void SpawnPoint(IEnemyTank enemyTank)
        {
            Vector3 position1 = new Vector3(8.6f, 0f, 2.62f);
            Quaternion quaternion1 = Quaternion.Euler(0f, 156.025f, 0f);
            enemyTank = enemyTankFactory.GetEnemyTank(position1, quaternion1);
            enemyTank.view.transform.position = position1;
            enemyTank.view.transform.rotation = quaternion1;


        }
    }
}
