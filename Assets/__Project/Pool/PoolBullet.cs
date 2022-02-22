using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PoolBullet : PoolGameObject
    {

        public PoolBullet(GameObject prefab, string prefabGameName, string poolName) : base(prefab, prefabGameName, poolName)
        {
        }

        protected override GameObject InstantiatePrefab()
        {

            BulletBuilder bulletBuilder = new BulletBuilder(_prefab);
            GameObject gameObject = bulletBuilder
                .Name(_prefabGameName)
                .CapsuleCollider(BulletParameters.COLLIDER_CENTER, BulletParameters.COLLIDER_RADIUS, BulletParameters.COLLIDER_HEIGHT)
                .RigidBody(BulletParameters.RIGIDBODY_MASS, BulletParameters.RIGIDBODY_DRAG, BulletParameters.RIGIDBODY_ANGULAR_DRAG, true, false)
                .Behaviour();

            return gameObject;
        }
    }
}
