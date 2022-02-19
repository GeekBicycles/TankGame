using UnityEngine;

namespace Tank_Game
{
    public sealed class TankAutoRotator
    {

        public TankAutoRotator(Transform tank1, Transform tank2)
        {
            tank1.LookAt(tank2);
            tank2.LookAt(tank1);
        }
    }
}
