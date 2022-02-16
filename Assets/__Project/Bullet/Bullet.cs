using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class Bullet : IBullet
    {
        public IBulletModel model { get; set; }
        public IBulletView view { get; set; }

        public Bullet(IBulletModel model, IBulletView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
