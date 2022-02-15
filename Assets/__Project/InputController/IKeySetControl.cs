using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IKeySetControl
    {
        public KeyCode up { get; set; }
        public KeyCode down { get; set; }
        public KeyCode left { get; set; }
        public KeyCode right { get; set; }
        public KeyCode fire { get; set; }
    }
}
