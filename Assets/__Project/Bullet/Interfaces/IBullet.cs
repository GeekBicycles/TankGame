using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IBullet
    {
        public IBulletModel model { get; set; }
        public IBulletView view { get; set; }
}
}
