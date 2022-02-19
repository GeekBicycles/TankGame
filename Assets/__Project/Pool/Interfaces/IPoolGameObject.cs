using UnityEngine;

namespace Tank_Game
{
    public interface IPoolGameObject
    {
        GameObject Pop();

        void Push(GameObject gameObject);
    }
}