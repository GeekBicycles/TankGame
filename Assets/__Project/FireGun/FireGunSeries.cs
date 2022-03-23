using System;
using UnityEngine;

namespace Tank_Game
{
    public sealed class FireGunSeries : IFireGunSeries
    {
        private IFireGun _fireGun;
        private bool _isFiring;
        private int _fireLeft;
        private float _timeNoNextFire;
        private float _oneShootTime;

        private Action<RaycastHit> _actionDamage;
        private Action _actionEndShooting;

        public FireGunSeries(Transform transform, float distance, float spread, float shootPerSec)
        {
            _fireGun = new FireGun(transform, distance, spread);
            _isFiring = false;
            _oneShootTime = 1f / shootPerSec;
        }

        public void SetFire(bool fire, int fireCount)
        {
            _fireLeft = fireCount;
            _isFiring = true;
            _timeNoNextFire = 0;
        }

        public void SetActionDamage(Action<RaycastHit> actionDamage)
        {
            _actionDamage = actionDamage;
        }

        public void SetActionEndShooting(Action actionEndShooting)
        {
            _actionEndShooting = actionEndShooting;
        }

        public void Update(float deltaTime)
        {
            if (!_isFiring) return;

            _timeNoNextFire -= deltaTime;

            if (_timeNoNextFire <= 0)
            {
                _timeNoNextFire += _oneShootTime;
                _fireLeft--;

                if (_fireGun.Fire(out RaycastHit hitInfo))
                {
                    _actionDamage?.Invoke(hitInfo);
                }

                if (_fireLeft <= 0)
                {
                    _isFiring = false;
                    _actionEndShooting?.Invoke();
                }
            }
        }
    }
}
