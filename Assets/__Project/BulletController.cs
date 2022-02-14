using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletController : IUpdate
    {
        private BulletsData bulletsdata;
        public BulletController(BulletsData bulletsData)
        {
            bulletsdata = bulletsData;
        }

        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
        public void PlayParticleDamage()
        {

        }
    }
}
