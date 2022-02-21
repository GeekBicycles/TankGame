using UnityEngine;

namespace Tank_Game
{
    public interface ITankAutoRotator
    {
        public void RotateBoth(Transform tank1, Transform tank2);
        public void RotateToTarget(Transform tank, Transform target);
    }
}