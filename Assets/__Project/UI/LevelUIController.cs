using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class LevelUIController : ILevelUIController
    {
        public ILevelUIBehavior levelUIBehavior { get; set; }
        public Transform canvasTransform { get; set; }
    }
}
