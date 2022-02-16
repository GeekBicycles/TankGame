using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class TankSpawner
    {
        
        public Transform playerTank;
        public Transform ememyTank;

        public void Spawn(Vector3 playerPosition, Vector3 enemyPosition)
        {
            //GameObject playerTankPrefab = Resources.Load<GameObject>(ResourcesPathes.playerTank);
            //playerTank = GameObject.Instantiate(playerTankPrefab, playerPosition, Quaternion.identity).transform;
            //playerTank.name = PrefabsNames.playerTankName;

            //GameObject enemyTankPrefab = Resources.Load<GameObject>(ResourcesPathes.enemyTank);
            //ememyTank = GameObject.Instantiate(enemyTankPrefab, enemyPosition, Quaternion.identity).transform;
            //ememyTank.name = PrefabsNames.enemyTankName;

        }

    }
}
