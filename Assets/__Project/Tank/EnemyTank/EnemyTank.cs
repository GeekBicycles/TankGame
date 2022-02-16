using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class EnemyTank : IEnemyTank
    {
        public IEnemyTankModel model { get; set; }
        public IEnemyTankView view { get; set; }
        public float timeToFire { get; set; }

        public EnemyTank(IEnemyTankModel model, IEnemyTankView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
