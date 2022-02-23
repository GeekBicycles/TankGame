using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IEndGameModel
    {
        public string WinGame { get; }
        public string LoseGame { get; }
    }
}
