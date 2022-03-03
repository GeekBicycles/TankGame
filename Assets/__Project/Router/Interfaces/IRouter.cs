using UnityEngine;

namespace Tank_Game
{
    public interface IRouter
    {
        Transform GetNextPoint();
    }
}