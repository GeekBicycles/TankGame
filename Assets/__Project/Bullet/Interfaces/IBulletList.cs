using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IBulletList
    {
        public List<IBullet> bullets { get; set; }
    }
}
