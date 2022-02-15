using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class BulletBehavior : MonoBehaviour
    {
        [RequireComponent(typeof(BoxCollider))]
        public class PlayerTankBehavior : MonoBehaviour
        {
            public BulletController BulletController;

            public void OnTriggerEnter(Collider other)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
