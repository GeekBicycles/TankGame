using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IHelicopterView
    {
        public Transform transform { get; set; }
        public Transform bulletSpawnTransform { get; }
        public IHelicopterBehaviour helicopterBehaviour { get; }
        public Collider collider { get; }
    }
}
