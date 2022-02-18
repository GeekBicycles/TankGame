using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IChooseEnemy
    {
        event Action<Transform> actionChooseEnemy;
    }
}
