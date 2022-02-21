using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class TankCount : ITankCount
    {
        public ITankUIView  view { get; }
        public TankCount(ITankUIView view)
        {
            this.view = view;
        }
    }
}
