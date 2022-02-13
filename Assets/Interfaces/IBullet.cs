using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IBullet
    {
        // Комментарий для теста
        public float Speed { get; }
        public int Damage { get; }
        void PlayParticleDamage();
    }
}
