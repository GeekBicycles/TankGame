using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IChooseTank 
    {
        event Action<IPlayerTank> actionChoosePlayer;

        void Update(float deltaTime);
    }
}
