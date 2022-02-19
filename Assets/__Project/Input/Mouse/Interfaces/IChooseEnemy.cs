using System;
using UnityEngine;

namespace Tank_Game
{
    public interface IChooseEnemy
    {
        event Action<Transform> actionChooseEnemy;

        void Update(float deltaTime);
    }
}