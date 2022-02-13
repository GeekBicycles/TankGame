using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface ILateUpdate : IUpdatable
    {
        public void LateUpdate(float deltaTime);

    }
}
