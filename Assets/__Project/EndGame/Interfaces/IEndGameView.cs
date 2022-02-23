using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tank_Game
{
    public interface IEndGameView
    {
        public event Action OnRestartButtonClick;
        public void SetText(string value);
    }
}
