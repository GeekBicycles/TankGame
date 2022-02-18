using UnityEngine;

namespace Tank_Game
{
    public class InputMouseData : IInputMouseData
    {
        public bool mouse0 { get; set; }
        public bool mouse1 { get; set; }
        public Vector3 mousePosition { get; set; }

        public InputMouseData()
        {
            mouse0 = false;
            mouse1 = false;
            mousePosition = Vector3.zero;
        }
    }
}
