using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IInputMouseData
    {
        public bool mouse0 { get; set; }
        public bool mouse1 { get; set; }
        public Vector3 mousePosition { get; set; }
    }
}
