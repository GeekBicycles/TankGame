using System;
using UnityEngine;

namespace Tank_Game
{
    public interface IFireGunSeries : IUpdate
    {
        void SetActionDamage(Action<RaycastHit> actionDamage);
        void SetActionEndShooting(Action actionEndShooting);
        void SetFire(bool fire, int fireCount);
    }
}