using System.Collections.Generic;

namespace Tank_Game
{
    internal class BulletList : IBulletList
    {
        public List<IBullet> bullets { get; set; }

        public BulletList()
        {
            bullets = new List<IBullet>();
        }
    }
}