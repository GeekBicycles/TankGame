using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public class AttermptsData : IAttermptsData
    {
        public float Attermpts_count { get; set; }

        public AttermptsData(float Attermpts)
        {
            this.Attermpts_count = Attermpts;
        }
    }
}
