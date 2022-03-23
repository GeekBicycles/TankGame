using UnityEngine;

namespace Tank_Game
{
    public interface IHelicopterMoveController : IUpdate
    {
        void SetDestination(Transform transform);
        bool OnPosition();
    }
}