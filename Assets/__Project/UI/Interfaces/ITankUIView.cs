using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tank_Game
{
    public interface ITankUIView
    {
        public float PlayerTankCount { get; set; }
        public float EnemyTankCount { get; set; }
        public Text PlayerCountText { get; set; }
        public Text EnemyCountText { get; set; }
        public Transform canvas { get; }
    }
}
