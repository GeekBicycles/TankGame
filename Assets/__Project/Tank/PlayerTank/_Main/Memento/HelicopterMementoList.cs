using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace Tank_Game
{
    public sealed class HelicopterMementoList
    {
        public List<HelicopterMemento> helicopterMementos;
        public HelicopterMemento current;

        public HelicopterMementoList()
        {
            helicopterMementos = new List<HelicopterMemento>();
        }

       
    }
}