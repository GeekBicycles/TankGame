using UnityEngine;

namespace Tank_Game
{
    public interface IFireGun
    {
        bool Fire(out RaycastHit hitInfo);
    }
}