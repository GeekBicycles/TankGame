using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IUnscaledUpdate : IUpdatable
    {
        public void UnscaledUpdate(float unscaledDeltaTime);
    }
}

