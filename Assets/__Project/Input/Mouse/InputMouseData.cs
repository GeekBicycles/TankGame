using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class InputMouseData : IInputMouseData
    {
        public bool mouse0 { get; set; }
        public bool mouse1 { get; set; }
        
        public InputMouseData()
        {
            mouse0 = false;
            mouse1 = false;
        }
    }
}
