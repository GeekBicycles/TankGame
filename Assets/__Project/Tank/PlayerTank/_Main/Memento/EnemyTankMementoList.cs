using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class EnemyTankMementoList 
    {

        public List<EnemyTankMemento> enemyTankMementos;
        public EnemyTankMemento current;

        public EnemyTankMementoList()
        {
            enemyTankMementos = new List<EnemyTankMemento>();
        }

    }
}