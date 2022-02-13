using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IFixedUpdate : IUpdatable
    {
        public void FixedUpdate(float fixedDeltaTime);
    }
}

