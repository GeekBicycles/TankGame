using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    // Комментарий для теста
    public float Speed { get; }
    public int Damage { get; }
    void PlayParticleDamage();
}
