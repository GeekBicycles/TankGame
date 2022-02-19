using UnityEngine;

namespace Tank_Game
{
    public sealed class TankAutoRotator : ITankAutoRotator
    {

        public TankAutoRotator()
        {

        }

        public void RotateBoth(Transform tank1, Transform tank2)
        {
            tank1.LookAt(tank2);
            tank2.LookAt(tank1);
        }

        public void RotateToTarget(Transform tank, Transform target)
        {
            tank.LookAt(target);
        }
    }
}
