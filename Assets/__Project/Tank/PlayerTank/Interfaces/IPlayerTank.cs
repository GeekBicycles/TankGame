using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IPlayerTank
    {
        public IPlayerTankModel model { get; set; }
        public IPlayerTankView view { get; set; }
        public float timeToFire { get; set; }
    }
}