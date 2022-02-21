using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface ITankUIBehevior
    {
        public ITankCount tankCount{ get; set; }
    }
}
