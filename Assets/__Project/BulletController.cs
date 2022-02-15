using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletController : IFixedUpdate
    {
        private BulletsData _bulletModel;
        private BulletView _bulletView;

        public BulletController(BulletsData bullet, BulletView bulletView)
        {
            _bulletModel = bullet;
            _bulletView = bulletView;
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _bulletView.Fire(_bulletModel.bullets[0].Speed * fixedDeltaTime);
        }
    }
}
