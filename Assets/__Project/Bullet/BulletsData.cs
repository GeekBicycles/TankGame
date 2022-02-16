using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletsData
    {
        public List<IBullet> bullets;

        public BulletsData()
        {
            bullets = new List<IBullet>();
        }
    }
}
