using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class TankSpawner
    {
        
        public GameObject playerTank;
        public GameObject ememyTank;

        public void Spawn(GameObject playerPosition, GameObject enemyPosition)
        {
            GameObject playerTankPrefab = Resources.Load<GameObject>(ResourcesPathes.playerTank);
            playerTank = GameObject.Instantiate(playerTankPrefab, playerPosition.transform.position, Quaternion.identity);
            playerTank.name = PrefabsNames.playerTankName;

            GameObject enemyTankPrefab = Resources.Load<GameObject>(ResourcesPathes.enemyTank);
            ememyTank = GameObject.Instantiate(enemyTankPrefab, enemyPosition.transform.position, Quaternion.identity);
            ememyTank.name = PrefabsNames.enemyTankName;

        }

    }
}
