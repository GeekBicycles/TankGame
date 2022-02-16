using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IBulletSpawnTransform
    {
        public Transform bulletSpawnTransform { get; set; }
    }
}
