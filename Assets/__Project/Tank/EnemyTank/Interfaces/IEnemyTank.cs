using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTank
    {
        public IEnemyTankModel model { get; set; }
        public IEnemyTankView view { get; set; }
    }
}
