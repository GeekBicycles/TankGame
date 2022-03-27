using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public sealed class PlayerTankMementoList
    {
        public List<PlayerTankMemento> playerTankMementos;
        public PlayerTankMemento current;

        public PlayerTankMementoList()
        {
            playerTankMementos = new List<PlayerTankMemento>();
        }
    }
}
