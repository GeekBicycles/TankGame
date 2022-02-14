using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace Tank_Game
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlayerTankBehavior : MonoBehaviour
    {
        public PlayerTankController PlayerTankController;

        public void OnTriggerEnter(Collider other)
        {
            if (GetComponent<Collider>())
            {
                throw new NotImplementedException();
            }
        }
    }
}
