using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankController : IUpdate
    {
        public PlayerTankController(IInputData inputData, ITank tank, BulletFactory bulletFactory)
        {

        }
        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
