using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class BulletParameters
    {
        public static readonly Vector3 COLLIDER_CENTER = new Vector3(0f, 0f, 0.2f);
        public const float COLLIDER_RADIUS = 0.15f;
        public const float COLLIDER_HEIGHT = 0.55f;
        public const float RIGIDBODY_MASS = 1f;
        public const float RIGIDBODY_DRAG = 0f;
        public const float RIGIDBODY_ANGULAR_DRAG = 0.05f;
    }
}
