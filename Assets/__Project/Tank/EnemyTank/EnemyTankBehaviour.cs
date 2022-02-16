using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyTankBehaviour : MonoBehaviour
    {

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
