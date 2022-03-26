using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class AttermptsData : IAttermptsData
    {
        public int Attermpts_count { get; set; }

        public AttermptsData(int Attermpts)
        {
            this.Attermpts_count = Attermpts;
        }
    }
}
