using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IUpdate : IUpdatable
    {
        public void Update(float deltaTime);

    }
}

