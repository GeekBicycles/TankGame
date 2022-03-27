using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class SmoothRouterMemento
    {
        public Vector3 position;
        public Quaternion rotation;

        public SmoothRouterMemento(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }
}
