using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Tank_Game
{
    public class BulletController : IFixedUpdate
    {
        private IBullet _bulletModel;
        private BulletView _bulletView;

        public BulletController(IBullet bullet, BulletView bulletView)
        {
            _bulletModel = bullet;
            _bulletView = bulletView;
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _bulletView.Fire(_bulletModel.Speed * fixedDeltaTime);
        }
    }
}
