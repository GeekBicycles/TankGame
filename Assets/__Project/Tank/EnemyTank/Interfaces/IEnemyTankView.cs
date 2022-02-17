using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTankView
    {
<<<<<<< Updated upstream:Assets/__Project/Tank/EnemyTank/Interfaces/IEnemyTankView.cs
=======
        public float Speed { get; set;  }
        public int Damage { get; set; }
>>>>>>> Stashed changes:Assets/__Project/Interfaces/IBullet.cs
        public Transform transform { get; set; }
        public Transform bulletSpawnTransform { get; set; }
    }
}