using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class EnemyTankBehavior : MonoBehaviour
    {
        [RequireComponent(typeof(BoxCollider))]
        public class PlayerTankBehavior : MonoBehaviour
        {
            public EnemyTankController EnemyTankController;

            public void OnTriggerEnter(Collider other)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
