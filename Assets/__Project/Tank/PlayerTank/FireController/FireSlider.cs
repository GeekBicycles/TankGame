using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tank_Game
{
    public class FireSlider : MonoBehaviour
    {
        [SerializeField] private Slider _fireSlider;
        
        public float Value { set{
            if (value >= 0)
            {
                _fireSlider.value = value;
            } ; } }
    }
}
