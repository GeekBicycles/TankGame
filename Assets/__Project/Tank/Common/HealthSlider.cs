using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tank_Game
{
    public class HealthSlider : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        
        public float Value { set{
            if (value >= 0)
            {
                _healthSlider.value = value;
            } ; } }
    }
}
