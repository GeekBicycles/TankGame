using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class EndGameModel : IEndGameModel
    {
        private const string WIN_GAME = "YOU ARE WIN!";
        private const string LOSE_GAME = "YOU ARE LOSE!";
        
        public string WinGame { get => WIN_GAME; }
        public string LoseGame { get => LOSE_GAME; }
    }
}
